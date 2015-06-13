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
    class Silax_Gun_Ship : Danmaku_Enemy
    {
        int direction;
        int StopPoint;
        int waves;
        Bullet_Spell Circle;
        Bullet_Spell Blast;

        public Silax_Gun_Ship(int x, int y, int directio, int stoppoint)
            : base(x, y, 2 * directio, 150, 79, 91)
        {
            direction = directio;
            StopPoint = stoppoint;
            Circle = new Bullet_Spell(0);
            Blast = new Bullet_Spell(1);
        }


        public override void update()
        {
            base.update();

            waves++;
            if ((centery >= StopPoint && direction == 1) || (direction == -1 && centery <= StopPoint))
            {
                //Circle.AddBulletCircleSpin(8, waves, 5, 1, 0.05f, centerx, centery);
                Circle.AddBulletCircleSpin(4, waves, 10, 1.5f, 0.5f*direction, centerx, centery, false);
                Circle.SetHealth(GetHealth());
            }
            else { base.MoveYpos(); }

            Blast.SetHealth(GetHealth());
            Blast.AddBulletSectorBlast(15, 1, 1, 2, centerx, centery, 180, 120);
            Blast.SetSpecial(2);

            if (direction == -1)
            {
                if (GetOffTop() == 1)
                {
                    base.resetpos();
                }
            }
            if (direction == 1)
            {
                if (GetOffBottom() == 1)
                {
                    base.resetpos();
                }
            }

        }


        public override void drawship(SpriteBatch spriteBatch)
        {

            base.draw(spriteBatch, 236, 3);

            Circle.draw(spriteBatch);
            Blast.draw(spriteBatch);

        }

    }
}
