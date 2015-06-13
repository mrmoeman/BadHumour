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
    class Dan_Cirno_Phase_Six : Danmaku_Enemy
    {
        int waves;
        int anitimer;
        float angle = 90;
        Bullet_Spell BS_Spell_Arc;
        Bullet_Spell BS_Spell_Arc_2;
        Bullet_Spell BS_Spell_Arc_3;
        Bullet_Spell BS_Spell_Point;
        Bullet_Spell Death_Spell;

        public Dan_Cirno_Phase_Six()
            : base((int)Game1.Dan_Data.GetTempX(), (int)Game1.Dan_Data.GetTempY(), 2, 4000, 67, 44)
        {
            Death_Spell = new Bullet_Spell(1);
            BS_Spell_Arc = new Bullet_Spell(0);
            BS_Spell_Arc_2 = new Bullet_Spell(0);
            BS_Spell_Arc_3 = new Bullet_Spell(0);
            BS_Spell_Point = new Bullet_Spell(0);
            SetPowerGive(2);
        }

        public override void update()
        {
            base.update();
            SetBar(1, 11);
            waves++;
            if (GetHealth() > 0)
            {
                Game1.Dan_Data.SetTempVector(GetXpos(), GetYpos());
            }
            if (centery >= 244)
            {
                SetSpeed(-2);
                MoveYpos();
                Invincible();
            }
            if (centery <= 236)
            {
                SetSpeed(2);
                MoveYpos();
                Invincible();
            }
            if (centery < 244 && centery > 236)
            {

                BS_Spell_Arc.AddBulletCircleSpin(2, waves, 12, 2, 0.3f, centerx, centery, false);
                BS_Spell_Arc.SetHealth(GetHealth());
                BS_Spell_Arc.SetColour(1);

                BS_Spell_Arc_2.AddBulletCircleSpin(2, waves, 12, 2, 0.3f, centerx, centery, false);
                BS_Spell_Arc_2.SetDirection(-1);
                BS_Spell_Arc_2.SetHealth(GetHealth());
                BS_Spell_Arc_2.SetColour(1);

                BS_Spell_Arc_3.AddBulletSectorBlast(10, waves, 20, 2, centerx, centery, 180, 120);
                BS_Spell_Arc_3.SetHealth(GetHealth());
                BS_Spell_Arc_3.SetSpecial(2);
                BS_Spell_Arc_3.SetColour(2);

                BS_Spell_Point.AddBulletBlastPoint(8, waves, 250, 1, centerx, centery, 200, (int)(Game1.Dan_Data.GetData().X), (int)(Game1.Dan_Data.GetData().Y), 5);
                BS_Spell_Point.SetHealth(GetHealth());
                BS_Spell_Point.SetSpecial(1);
                BS_Spell_Point.SetSize(1);

            }



            Death_Spell.SetHealth(GetHealth());
            Death_Spell.AddBulletCircle(10, 4, centerx, centery);
            Death_Spell.SetSize(1);
            Death_Spell.SetSpecial(1);

        }


        public override void drawship(SpriteBatch spriteBatch)
        {
            BS_Spell_Arc.draw(spriteBatch);
            BS_Spell_Arc_2.draw(spriteBatch);
            BS_Spell_Arc_3.draw(spriteBatch);
            BS_Spell_Point.draw(spriteBatch);
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
