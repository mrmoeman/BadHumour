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
    class DamageField
    {
        int dps;
        int areareq;
        Rectangle boundary;
        int timer;

        public DamageField(int dp, int area)
        {
            dps = dp;
            areareq = area;
            boundary = new Rectangle(0, 0, 800, 480);
        }

        public DamageField(int dp, int area, int x, int y, int wid, int hei)
        {

            dps = dp;
            areareq = area;
            boundary = new Rectangle(x, y, wid, hei);

        }


        public void update(int area)
        {
            if (areareq == area)
            {
                timer++;

                if (boundary.Intersects(Game1.manboundary) && timer > 10)
                {

                    Game1.playerdata[11] += dps;
                    timer = 0;

                }

            }
        }


        public void SetDps(int number)
        {
            dps = number;
        }

    }
}
