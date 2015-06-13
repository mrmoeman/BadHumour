using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace universe
{
    class Mine : Enemy
    {

        Effect explo = new Effect();
        int explosize = 1;

        public Mine(int x, int y)
            : base(x, y, 20, 20, 5, 25, 20, 20)
        {
           
        }


        public override void update(){
            if (HealthCheck() > 0)
            {
                base.update();
                base.collision();
                base.MoveBob(100);
                base.Takedamage();

                
                if (GetCollision() == 1)
                {
                    explosize = 2;
                    DealDamage(22);
                    SetHealth(0);
                }

               

            }




        }


        public override void draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.DrawString(Game1.Arial, "Distance: " + GetDistance(), new Vector2(250, 150), Color.White);

            if (HealthCheck() <= 0)
            {
                explo.draw((int)(xpos + 400 + Platform_Data.GetOffsetX()),(int)( ypos + 240 + Platform_Data.GetOffsetY()), spriteBatch, explosize, 20, 20);
            }

            

                spriteBatch.Draw(Game1.mine, new Vector2(xpos + 400 + Platform_Data.GetOffsetX(), ypos + 240 + Platform_Data.GetOffsetY()), new Rectangle(0, 0, 20, 20), Color.White);

        }

        public override void reset()
        {
            base.reset();
            explo.SetTimer(0);
            explosize = 1;
        }

    }
}
