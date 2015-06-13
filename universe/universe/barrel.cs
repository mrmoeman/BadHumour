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
    class barrel : PhyObj
    {

        static int weight = 30;
        static int strengt = 24;
        static int sheight = 29;
        static int swidth = 25;
        static int sprites = 2;
        Effect smoke = new Effect();

        public barrel(int x, int y, int move)
            : base(1, x, y, 40, 40, weight, strengt, 40, swidth, sheight, sprites, 0, move)
        {
        }
        public barrel(int x, int y)
            : base(1, x, y, 40, 40, weight, strengt, 40, swidth, sheight, sprites, 0)
        {
        }

        public override void update()
        {
            base.update();


        }


        public override void draw(SpriteBatch spriteBatch)
        {

            base.draw(spriteBatch);
            if (strength <= 0)
            {
                smoke.draw((int)(oldxpos + 400 + Platform_Data.GetOffsetX()), (int)(oldypos + 240 + Platform_Data.GetOffsetY()), spriteBatch, 3, 40, 40);
            }
        }

    }
}
