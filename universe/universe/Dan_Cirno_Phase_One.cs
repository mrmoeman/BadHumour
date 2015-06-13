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
    class Dan_Cirno_Phase_One : Danmaku_Enemy
    {
        int waves;
        int anitimer;
        Bullet_Spell BS_Spell;
        Bullet_Spell Death_Spell;
        Bullet_Spell BS2_Spell;
        public Dan_Cirno_Phase_One()
            : base (800, 240, -2, 4000, 67, 44)
        {
            BS_Spell = new Bullet_Spell(0);
            BS2_Spell = new Bullet_Spell(0);
            Death_Spell = new Bullet_Spell(1);
            base.SetExplosion(1);
            SetPowerGive(2);
        }


        public override void update()
        {
            base.update();
            SetBar(1,0);
            if (centerx > 400)
            {
                MoveXpos();
                Invincible();
                
            }

            if (GetHealth() > 0)
            {
                Game1.Dan_Data.SetTempVector(GetXpos(), GetYpos());
            }

            if (centerx <= 400)
            {
                waves++;
                if (GetHealth() > 500)
                {
                    BS_Spell.AddBulletBlastSpin(10, waves, 16, 2, 0.1f, centerx, centery);
                    BS2_Spell.AddBulletBlastSpin(10, waves, 16, 2, -0.1f, centerx, centery);
                }
                if (GetHealth() <= 500)
                {
                    BS_Spell.AddBulletBlastSpin(10, waves, 16, 2, 0.2f, centerx, centery);
                    BS2_Spell.AddBulletBlastSpin(10, waves, 16, 2, -0.2f, centerx, centery);
                }

                BS_Spell.SetHealth(GetHealth());
                BS_Spell.SetSpecial(2);
                BS_Spell.SetColour(1);
                BS2_Spell.SetHealth(GetHealth());
                BS2_Spell.SetSpecial(2);
                BS2_Spell.SetColour(1);
            }

            Death_Spell.SetHealth(GetHealth());
            Death_Spell.AddBulletCircle(10, 4, centerx, centery);
            Death_Spell.SetSize(1);
            Death_Spell.SetSpecial(1);
            

        }


        public override void drawship(SpriteBatch spriteBatch)
        {
            
            BS_Spell.draw(spriteBatch);
            BS2_Spell.draw(spriteBatch);
            Death_Spell.draw(spriteBatch);
            anitimer++;
            if (anitimer < 10)
            {
                base.draw(spriteBatch, 169, 0);
            }
            if (anitimer >= 10 && anitimer <20){
                base.draw(spriteBatch, 169, 44);
            }
            if (anitimer == 19)
            {
                anitimer = 0;
            }
        }

    }
}
