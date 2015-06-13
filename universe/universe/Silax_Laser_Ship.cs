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
    class Silax_Laser_Ship : Danmaku_Enemy
    {
        int direction;
        int StopPoint;
        Bullet_Spell Circle;
        Bullet_Spell Blast;
        Bullet_Spell Stream;
        Laser laser;

        public Silax_Laser_Ship(int x, int y, int directio, int stoppoint)
            : base(x, y, 2 * directio, 150, 60, 45)
        {
            direction = directio;
            StopPoint = stoppoint;
            Blast = new Bullet_Spell(1);
            laser = new Laser(FadeState.On);
        }


        public override void update()
        {
            base.update();
            

            laser.Update(centerx, centery, Direction.Left, 3);
            laser.laserfade(400, 150, 80);
            laser.SetHealth(GetHealth());

          
            if ((centery >= StopPoint && direction == 1) || (direction == -1 && centery <= StopPoint))
            {
               
            }
            else { base.MoveYpos(); }

            Blast.SetHealth(GetHealth());
            Blast.AddBulletSectorBlast(10, 1, 1, 2, centerx, centery, 180, 120);
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
            laser.draw(spriteBatch);

            base.draw(spriteBatch, 114, 94);

            Blast.draw(spriteBatch);

        }

    }
}
