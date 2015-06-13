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
    class Collision
    {
        int lcollided;
        int rcollided;
        int bcollided;
        Rectangle boundary;

        public Collision(int x, int y, int width, int height)
        {
            boundary = new Rectangle(x, y, width, height);
        }

        public void update(int area, int areareq)
        {

            

                if (boundary.Intersects(Game1.manleftmoveboundary))
                {
                    if (lcollided == 0 && area == areareq)
                    {
                        Game1.playerdata[8]++;
                    }
                    lcollided = 1;
                }
                else
                {
                    if (lcollided == 1)
                    {
                        Game1.playerdata[8]--;
                    }
                    lcollided = 0;
                }
                if (boundary.Intersects(Game1.manrightmoveboundary))
                {
                    if (rcollided == 0 && area == areareq)
                    {
                        Game1.playerdata[9]++;
                    }
                    rcollided = 1;
                }
                else
                {
                    if (rcollided == 1)
                    {
                        Game1.playerdata[9]--;
                    }
                    rcollided = 0;
                }
                if (boundary.Intersects(Game1.manbottomboundary))
                {
                    if (bcollided == 0 && area == areareq)
                    {
                        Game1.playerdata[10]++;
                    }
                    bcollided = 1;
                }
                else
                {
                    if (bcollided == 1)
                    {
                        Game1.playerdata[10]--;
                    }
                    bcollided = 0;
                }

            


        }

    }
}
