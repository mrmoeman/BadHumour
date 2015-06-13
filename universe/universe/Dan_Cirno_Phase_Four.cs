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
    class Dan_Cirno_Phase_Four : Danmaku_Enemy
    {
        int waves;
        int spell2;
        int spell3;
        int anitimer;
        Bullet_Spell BS_Spell;
        Bullet_Spell BS_Spell_2;
        Bullet_Spell BS_Spell_3;
        Bullet_Spell BS_Spell_Arc;
        Bullet_Spell BS_Spell_Arc_2;
        Bullet_Spell Death_Spell;

        public Dan_Cirno_Phase_Four()
            : base((int)Game1.Dan_Data.GetTempX(), (int)Game1.Dan_Data.GetTempY(), 2, 1000, 67, 44)
        {
            Death_Spell = new Bullet_Spell(1);
            BS_Spell = new Bullet_Spell(0);
            BS_Spell_2 = new Bullet_Spell(0);
            BS_Spell_3 = new Bullet_Spell(0);
            BS_Spell_Arc = new Bullet_Spell(0);
            BS_Spell_Arc_2 = new Bullet_Spell(0);
            base.SetExplosion(1);
            SetPowerGive(2);
        }

        public override void update()
        {
            base.update();
            base.MoveOscilateY(100, 2);
            SetBar(1, 6);
            waves++;
            BS_Spell.AddBulletRotatingBlastStar(6, waves, 40, 1, 0.5f, centerx, centery);
            BS_Spell.SetHealth(GetHealth());
            BS_Spell.LimitRadius(200);
            BS_Spell_2.SetHealth(GetHealth());
            BS_Spell_2.LimitRadius(200);
            BS_Spell_3.SetHealth(GetHealth());
            BS_Spell_3.LimitRadius(200);
            if (BS_Spell.GetTemp() == 200)
            {
                BS_Spell.MoveBulletXpos(-4);
                spell2 = 1;
            }
            else
            {
                BS_Spell.SetInit(centerx, centery);
            }

            if (BS_Spell_2.GetTemp() == 200)
            {
                BS_Spell_2.MoveBulletXpos(-4);
                spell3 = 1;
            }
            else
            {
                BS_Spell_2.SetInit(centerx, centery);
            }

            if (BS_Spell_3.GetTemp() == 200)
            {
                BS_Spell_3.MoveBulletXpos(-4);
                
            }
            else
            {
                BS_Spell_3.SetInit(centerx, centery);
            }

            Death_Spell.SetHealth(GetHealth());
            Death_Spell.AddBulletCircle(10, 4, centerx, centery);
            Death_Spell.SetSize(1);
            Death_Spell.SetSpecial(1);

             if (spell2 == 1){
                 BS_Spell_2.AddBulletRotatingBlastStar(6, waves, 40, 1, 0.5f, centerx, centery);
             }
             if (spell3 == 1)
             {
                 BS_Spell_3.AddBulletRotatingBlastStar(6, waves, 40, 1, 0.5f, centerx, centery);
             }

             if (BS_Spell.GetBullet_InitX() < 0 - BS_Spell.GetTemp() && BS_Spell_3.GetTemp() == 200)
             {
                BS_Spell = new Bullet_Spell(0);
            }
             if (BS_Spell_2.GetBullet_InitX() < 0 - BS_Spell_2.GetTemp() && BS_Spell.GetTemp() == 200)
             {
                BS_Spell_2 = new Bullet_Spell(0);
            }
             if (BS_Spell_3.GetBullet_InitX() < 0 - BS_Spell_3.GetTemp() && BS_Spell_2.GetTemp() == 200)
             {
                BS_Spell_3 = new Bullet_Spell(0);
            }


                BS_Spell_Arc.AddBulletCircleSpin(2, waves, 12, 2, 0.2f, centerx, centery, false);
                BS_Spell_Arc.SetHealth(GetHealth());
                BS_Spell_Arc.SetColour(2);
                BS_Spell_Arc.SetSpecial(3);

                BS_Spell_Arc_2.AddBulletCircleSpin(2, waves, 12, 2, 0.2f, centerx, centery, false);
                BS_Spell_Arc_2.SetDirection(-1);
                BS_Spell_Arc_2.SetHealth(GetHealth());
                BS_Spell_Arc_2.SetColour(2);
                BS_Spell_Arc_2.SetSpecial(3);


             if (GetHealth() > 0)
             {
                 Game1.Dan_Data.SetTempVector(GetXpos(), GetYpos());
             }


        }


        
        public override void drawship(SpriteBatch spriteBatch)
        {
            BS_Spell_Arc.draw(spriteBatch);
            BS_Spell_Arc_2.draw(spriteBatch);
            BS_Spell.draw(spriteBatch);
            BS_Spell_2.draw(spriteBatch);
            BS_Spell_3.draw(spriteBatch);
            Death_Spell.draw(spriteBatch);
            anitimer++;
            if (anitimer < 10)
            {
                base.draw(spriteBatch, 169, 0);
            }
            if (anitimer >= 10 && anitimer < 20)
            {
                base.draw(spriteBatch, 169, 44);
            }
            if (anitimer == 19)
            {
                anitimer = 0;
            }
        }

    }
}
