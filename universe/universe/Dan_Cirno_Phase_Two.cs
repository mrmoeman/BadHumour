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
    class Dan_Cirno_Phase_Two : Danmaku_Enemy
    {
        int waves;
        int anitimer;
        Bullet_Spell BS_Spell;
        Bullet_Spell BS_Spell_Arc;
        Bullet_Spell BS_Spell_Arc_2;
        Bullet_Spell Death_Spell;

         public Dan_Cirno_Phase_Two()
            : base((int)Game1.Dan_Data.GetTempX(), (int)Game1.Dan_Data.GetTempY(), 2, 4000, 67, 44)
        {
            Death_Spell = new Bullet_Spell(1);
            BS_Spell = new Bullet_Spell(0);
            BS_Spell_Arc = new Bullet_Spell(0);
            BS_Spell_Arc_2 = new Bullet_Spell(0);
            base.SetExplosion(1);
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
             if (centerx < 700)
             {
                 MoveXpos();
                 Invincible();

             }
             if (centerx >= 700)
             {
                 BS_Spell.AddBulletCircleSpinOld(8, waves, 10, 1, 0.2f, centerx, centery);
                 BS_Spell.SetHealth(GetHealth());
                 BS_Spell.MoveBulletXpos(-2);
                 BS_Spell.SetColour(1);
                 //BS_Spell.SetSpecial(3);

                 BS_Spell_Arc.AddBulletSectorBlast(10, waves, 20, 2f, centerx, centery, 90, 110);
                 BS_Spell_Arc.SetHealth(GetHealth());
                 BS_Spell_Arc.SetColour(0);
                 BS_Spell_Arc.SetSpecial(2);

                 BS_Spell_Arc_2.AddBulletSectorBlast(10, waves, 20, 2f, centerx, centery, 270, 110);
                 BS_Spell_Arc_2.SetHealth(GetHealth());
                 BS_Spell_Arc_2.SetColour(0);
                 BS_Spell_Arc_2.SetSpecial(2);
             }

             Death_Spell.SetHealth(GetHealth());
             Death_Spell.AddBulletCircle(10, 4, centerx, centery);
             Death_Spell.SetSize(1);
             Death_Spell.SetSpecial(1);

         }


         public override void drawship(SpriteBatch spriteBatch)
         {

             BS_Spell.draw(spriteBatch);
             BS_Spell_Arc.draw(spriteBatch);
             BS_Spell_Arc_2.draw(spriteBatch);
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
