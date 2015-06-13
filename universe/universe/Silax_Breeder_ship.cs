using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace universe
{
    class Silax_Breeder_Ship : Danmaku_Enemy
    {
        int waves;
        int anitimer;
        float temprot;
        float rotation = -0.314f;
        Boolean PhaseChange = false;
        int phase;
        int timer;
        Bullet_Spell BS_Spell;
        Bullet_Spell Death_Spell;
        Bullet_Spell BS2_Spell;
        Bullet_Spell BS3_Spell;
        Bullet_Spell BS4_Spell;
        Bullet_Spell BS5_Spell;
        Bullet_Spell BS6_Spell;
        Bullet_Spell Temp;
        List<Bullet_Spell> BulletSpelllistA = new List<Bullet_Spell>();
        List<Bullet_Spell> BulletSpelllistB = new List<Bullet_Spell>();
        Laser LaserA;
        Laser LaserB;
        Laser LaserC;
        Laser LaserD;
        Laser LaserE;
        Laser LaserF;
        Laser LaserG;
        public Silax_Breeder_Ship()
            : base(800, 200, -2, 4000, 154, 150)
        {
            BS_Spell = new Bullet_Spell(0);
            BS2_Spell = new Bullet_Spell(0);
            BS3_Spell = new Bullet_Spell(0);
            BS4_Spell = new Bullet_Spell(0);
            BS5_Spell = new Bullet_Spell(0);
            BS6_Spell = new Bullet_Spell(0);
            Death_Spell = new Bullet_Spell(1);

            LaserA = new Laser(FadeState.Off);
            LaserB = new Laser(FadeState.Off);
            LaserC = new Laser(FadeState.Off);
            LaserD = new Laser(FadeState.Off);
            LaserE = new Laser(FadeState.Off);
            LaserF = new Laser(FadeState.Off);
            LaserG = new Laser(FadeState.Off);

            base.SetExplosion(1);
            SetPowerGive(2);
        }


        public override void update()
        {

            base.update();
            SetBar(1, 0);
            if (centerx > 600)
            {
                MoveXpos();
                Invincible();

            }

            if (GetHealth() > 0)
            {
                Game1.Dan_Data.SetTempVector(GetXpos(), GetYpos());
            }

            if (centerx <= 600)
            {
               MoveOscilateY(300, 1);

                waves++;
                if (phase > 0)
                {
                    BS_Spell.SetCreationAllowed(false);
                    BS2_Spell.SetCreationAllowed(false);
                }

                if (GetHealth() > 500)
                {
                    BS_Spell.AddBulletBlastSpin(10, waves, 25, 2, 0.1f, centerx, centery);
                    BS2_Spell.AddBulletBlastSpin(10, waves, 25, 2, -0.1f, centerx, centery);
                }
                if (GetHealth() <= 500)
                {
                    BS_Spell.AddBulletBlastSpin(10, waves, 25, 2, 0.2f, centerx, centery);
                    BS2_Spell.AddBulletBlastSpin(10, waves, 25, 2, -0.2f, centerx, centery);
                }
                BS_Spell.SetHealth(GetHealth());
                BS_Spell.SetSpecial(5);
                BS2_Spell.SetHealth(GetHealth());
                BS2_Spell.SetSpecial(5);

                if (phase != 1)
                {
                    BS3_Spell.SetCreationAllowed(false);
                    BS4_Spell.SetCreationAllowed(false);
                }

                BS3_Spell.AddBulletSpray(centerx, centery, 4, 12, waves, 0.8f, true);
                BS3_Spell.LimitBulletRadius(250, true);
                BS3_Spell.SetSecondary(true);
                BS3_Spell.SetCreationAllowed(false);
                BS3_Spell.RotateAboutPoint(400, 240, 500, true);
                BS3_Spell.AdjustRotationWithPosition(new Vector2(-3f, 0), true);
                BS3_Spell.SetCreationAllowed(true);
                BS3_Spell.SetSecondary(false);

                BS4_Spell.AddBulletSpray(centerx, centery, 3, 6, waves, 0.8f, false);
                BS4_Spell.SetSpecial(2);
                BS4_Spell.SetColour(2);
                BS4_Spell.SetCreationAllowed(true);
                BS4_Spell.SetHealth(GetHealth());
                
                BS3_Spell.SetHealth(GetHealth());
                BS3_Spell.SetSpecial(5);
                BS3_Spell.SetColour(1);


                if (phase != 2)
                {
                    BulletSpelllistA.ForEach(i =>
                   {
                       i.SetCreationAllowed(false);
                   });
                    BulletSpelllistB.ForEach(i =>
                    {
                        i.SetCreationAllowed(false);
                    });
                }
                else
                {
                    timer++;
                    if (timer % 40 == 0 && timer % 80 != 0)
                    {
                        Temp = new Bullet_Spell(0);
                        BulletSpelllistA.Add(Temp);
                    }
                    if (timer % 80 == 0)
                    {
                        Temp = new Bullet_Spell(0);
                        BulletSpelllistB.Add(Temp);
                    }
                }
                BulletSpelllistA.ForEach(i =>
                {
                    i.AddBulletSectorBlast(18, 6, 10, 2f, centerx, centery, 180, 120);
                    i.SetHealth(GetHealth());
                    i.SetSpecial(2);
                    i.SetColour(2);
                    i.SetSize(0);
                    i.SetCreationAllowed(true);
                });

                BulletSpelllistB.ForEach(i =>
                {
                    i.SetHealth(GetHealth());
                    if ((i.CheckAllRadius(140) == true && i.GetBulletCount() > 1) || i.GetCheck() == true)
                    {
                        i.SetSecondary(true);
                        i.SetSize(1);
                        i.AddBulletPoint((int)(Game1.Dan_Data.GetData().X), (int)(Game1.Dan_Data.GetData().Y), 2f, false);
                        i.SetCheck(true);
                        i.SetSpecial(5);
                    }
                    else
                    {
                        i.AddBulletCircleSpin(2, 15, 10, 1.5f, -0.2f, centerx, centery, false);
                        i.LimitBulletRadius(150, false);
                        i.SetColour(1);
                        i.SetSize(0);
                    }
                    i.SetCreationAllowed(true);
                });

                if (phase >= 3)
                {
                    BS5_Spell.AddBulletBlastSpin(16, waves, 60, 1, 0.02f, centerx, centery);
                    BS6_Spell.AddBulletBlastSpin(16, waves, 120, 1, -0.02f, centerx, centery);
                }
                BS5_Spell.SetCreationAllowed(true);
                BS6_Spell.SetCreationAllowed(true);
                BS5_Spell.SetSpecial(2);
                BS6_Spell.SetSpecial(2);
                BS5_Spell.SetColour(2);
                BS6_Spell.SetColour(0);
                BS5_Spell.SetHealth(GetHealth());
                BS6_Spell.SetHealth(GetHealth());

            }

            if (phase == 3)
            {
                LaserA.SetHealth(GetHealth());
                LaserB.SetHealth(GetHealth());
                LaserC.SetHealth(GetHealth());
                LaserD.SetHealth(GetHealth());
                LaserE.SetHealth(GetHealth());
                LaserF.SetHealth(GetHealth());
                LaserG.SetHealth(GetHealth());

                LaserA.Update(100, 0, Direction.Down, 3);
                LaserB.Update(200, 0, Direction.Down, 3);
                LaserC.Update(300, 0, Direction.Down, 3);
                LaserD.Update(400, 0, Direction.Down, 3);
                LaserE.Update(500, 0, Direction.Down, 3);
                LaserF.Update(600, 0, Direction.Down, 3);
                LaserG.Update(700, 0, Direction.Down, 3);

                LaserA.laserfade(150, 300, 10);
                LaserB.laserfade(150, 300, 10);
                LaserC.laserfade(150, 300, 10);
                LaserD.laserfade(150, 300, 10);
                LaserE.laserfade(150, 300, 10);
                LaserF.laserfade(150, 300, 10);
                LaserG.laserfade(150, 300, 10);
            }
            else
            {
                BS5_Spell.SetCreationAllowed(false);
                BS6_Spell.SetCreationAllowed(false);
            }
           
           

            Death_Spell.SetHealth(GetHealth());
            Death_Spell.AddBulletCircle(10, 4, centerx, centery);
            Death_Spell.SetSize(1);
            Death_Spell.SetSpecial(5);
            Death_Spell.SetColour(2);

            if (GetHealth() < 50 && PhaseChange == false && phase < 7)
            {
                phase++;
                PhaseChange = true;
            }
            if (PhaseChange == true)
            {
                rotation += 0.01f;
                temprot += 0.01f;
                if (phase < 4)
                {
                    SetHealth(4000 + phase * 1000);
                    SetMaxHealth(4000 + phase * 1000);
                }
            }
            if (temprot > 1.256f)
            {
                PhaseChange = false;
                temprot = 0;
            }


            Game1.Dan_Data.SetPass(phase);
        }


        public override void drawship(SpriteBatch spriteBatch)
        {
            if (phase == 3)
            {
                LaserA.draw(spriteBatch);
                LaserB.draw(spriteBatch);
                LaserC.draw(spriteBatch);
                LaserD.draw(spriteBatch);
                LaserE.draw(spriteBatch);
                LaserF.draw(spriteBatch);
                LaserG.draw(spriteBatch);
            }

            BulletSpelllistA.ForEach(i =>
            {
                i.draw(spriteBatch);
            });
            BulletSpelllistB.ForEach(i =>
            {
                i.draw(spriteBatch);
            });
            
            BS_Spell.draw(spriteBatch);
            BS2_Spell.draw(spriteBatch);
            BS3_Spell.draw(spriteBatch);
            BS4_Spell.draw(spriteBatch);
            BS5_Spell.draw(spriteBatch);
            BS6_Spell.draw(spriteBatch);
            Death_Spell.draw(spriteBatch);
            anitimer++;
            if (GetHealth() > 0)
            {
                if (anitimer < 10)
                {
                    spriteBatch.Draw(Game1.eship, new Vector2(centerx, centery), new Rectangle(317, 1, 154, 150), Color.White, rotation, new Vector2(77, 75), 1.0f, SpriteEffects.None, 0.0f);
                }
                if (anitimer >= 10 && anitimer < 20)
                {
                    spriteBatch.Draw(Game1.eship, new Vector2(centerx, centery), new Rectangle(477, 1, 154, 150), Color.White, rotation, new Vector2(77, 75), 1.0f, SpriteEffects.None, 0.0f);

                }
                if (anitimer >= 20 && anitimer < 30)
                {
                    spriteBatch.Draw(Game1.eship, new Vector2(centerx, centery), new Rectangle(637, 1, 154, 150), Color.White, rotation, new Vector2(77, 75), 1.0f, SpriteEffects.None, 0.0f);
                }

                if (anitimer == 29)
                {
                    anitimer = 0;
                }
            }

            base.draw(spriteBatch, 0, 200);
        }

    }
}
