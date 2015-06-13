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
    class Danmaku_VShip : Danmaku_Enemy
    {
        int direction;
        int StopPoint;
        int waves = 5;
        Bullet_Spell Circle;
        Bullet_Spell Blast;
        Bullet_Spell Stream;
        Laser laser;

        public Danmaku_VShip(int x, int y, int directio, int stoppoint)
            : base(x, y, 2 * directio, 50, 30, 50)
        {
            direction = directio;
            StopPoint = stoppoint;
            Circle = new Bullet_Spell(0);
            Stream = new Bullet_Spell(0);
            Blast = new Bullet_Spell(1);
            laser = new Laser(FadeState.Off);
        }
        

        public override void update()
        {
            base.update();
           // base.AddBullet(10);
            //base.RemoveBullet();

            laser.Update(centerx, centery, Direction.Left, 3);
            laser.laserfade(400, 150, 80);
            laser.SetHealth(GetHealth());

            Stream.AddBulletStreamSplit(10, centerx, centery, 1);
            Stream.SetHealth(GetHealth());

            if ((centery >= StopPoint && direction == 1) || (direction == -1 && centery <= StopPoint))
            {
                waves++;
                //AddBulletCircle(5, 10, 5, 6);
                Circle.AddBulletCircleSpin(5, waves, 25, 1, 0.01f,  centerx, centery, false);
                //Circle.AddBulletCircle(50, 1, centerx, centery);
                Circle.SetHealth(GetHealth());
                Circle.SetDirection(direction);
                Circle.SetSpecial(2);
                // Circle.AddBulletCircle(5, 50, 10, 1, centerx, centery);
            }
            else { base.MoveYpos(); }

            if (Circle.GetWave() > 25)
            {
                MoveOscilateX(10, 2);
            }

            Blast.SetHealth(GetHealth());
          // Blast.AddBulletBlastSpin(10, 50, 3, 2, 0.5f, centerx, centery);
           // Blast.AddBulletBlast(10, 10, 3, 2, centerx, centery);
            Blast.AddBulletCascadingBlast(10, 2, centerx, centery, 100, 10);
            Blast.SetSpecial(1);
            


            Bulletlist.ForEach(i => i.MoveXpos(-5));
            Bulletlist.ForEach(i => i.BulletSine(30, 5, 1));
            //Bulletlist.ForEach(i => i.DoubleBulletSplitSine(30, 30, 5, 1, 10, 1, 1));

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

            base.draw(spriteBatch, 0, 0);

            Circle.draw(spriteBatch);
            Blast.draw(spriteBatch);
            Stream.draw(spriteBatch);
            
        }

    }
}
