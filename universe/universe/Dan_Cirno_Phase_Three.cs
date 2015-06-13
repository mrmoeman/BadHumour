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
    class Dan_Cirno_Phase_Three : Danmaku_Enemy
    {
        int waves;
        int timer;
        int anitimer;
        Bullet_Spell BS_Spell;
        Bullet_Spell BS_Spell_2;
        Bullet_Spell Death_Spell;

        public Dan_Cirno_Phase_Three()
            : base((int)Game1.Dan_Data.GetTempX(), (int)Game1.Dan_Data.GetTempY(), 2, 4000, 67, 44)
        {
            Death_Spell = new Bullet_Spell(1);
            BS_Spell = new Bullet_Spell(0);
            BS_Spell_2 = new Bullet_Spell(0);
            base.SetExplosion(1);
            SetPowerGive(2);
        }

        public override void update()
        {
            base.update();
            SetBar(1, 6);
            //BS_Spell.LimitRadius(200);
            waves++;
            timer++;
            if (GetHealth() > 0)
            {
                Game1.Dan_Data.SetTempVector(GetXpos(), GetYpos());
            }
            if (centerx < 700)
            {
                MoveXpos();
                Invincible();

            }
            if (centerx >= 700 && timer > 200)
            {
                BS_Spell.AddBulletBlastPoint(16, waves, 100, 2, centerx, centery, 100, (int)(Game1.Dan_Data.GetData().X), (int)(Game1.Dan_Data.GetData().Y), 5);
                /* if (BS_Spell.GetTemp() > 100)
                 {
                     BS_Spell.AddBulletPoint((int)(Game1.Dan_Data.GetData().X), (int)(Game1.Dan_Data.GetData().Y), 0.8f);
                 } */
                BS_Spell.SetHealth(GetHealth());
                //BS_Spell.MoveBulletXpos(-2);
                BS_Spell.SetColour(2);
                //BS_Spell.SetSpecial(1);
                BS_Spell.SetSize(1);

                BS_Spell_2.AddBulletBlastSpin(10, 15, 30, 1, 0.2f, centerx, centery);
                BS_Spell_2.SetHealth(GetHealth());
                BS_Spell_2.SetColour(2);
                BS_Spell_2.SetSpecial(2);
            }
            else
            {
                SetHealth(1000);
            }

            Death_Spell.SetHealth(GetHealth());
            Death_Spell.AddBulletCircle(10, 4, centerx, centery);
            Death_Spell.SetSize(1);
            Death_Spell.SetSpecial(1);

        }


        public override void drawship(SpriteBatch spriteBatch)
        {

            BS_Spell.draw(spriteBatch);
            BS_Spell_2.draw(spriteBatch);
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
