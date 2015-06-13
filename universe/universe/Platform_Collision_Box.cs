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
    class Platform_Collision_Box
    {

        Rectangle manboundary;
        Rectangle manleftboundary;
        Rectangle manrightboundary;
        Rectangle manleftmoveboundary;
        Rectangle manrightmoveboundary;
        Rectangle manbottomboundary;
        Rectangle mantopboundary;
        int lcollided;
        int rcollided;
        int bcollided;
        int ucollided;
        Rectangle boundary;
        int xpos;
        int ypos;

        public Platform_Collision_Box(int x, int y, int width, int height)
        {
            xpos = x;
            ypos = y;
            boundary = new Rectangle(x, y, width, height);


            manboundary = new Rectangle(0, 0, 24, 58);
            manleftboundary = new Rectangle(0, 0, 24, 54);
            manrightboundary = new Rectangle(0, 0, 24, 54);
            manleftmoveboundary = new Rectangle(0, 0, 2, 54);
            manrightmoveboundary = new Rectangle(0, 0, 2, 54);
            mantopboundary = new Rectangle(0, 0, 18, 2);
            manbottomboundary = new Rectangle(0, 0, 18, 2);
        }

        public Rectangle GetBoundary()
        {
            return boundary;
        }

        public void update()
        {


            if (boundary.Intersects(manleftmoveboundary))
            {
                if (lcollided == 0)
                {
                    Platform_Data.playerdata[8]++;
                }
                lcollided = 1;
            }
            else
            {
                if (lcollided == 1)
                {
                    Platform_Data.playerdata[8]--;
                }
                lcollided = 0;
            }
            if (boundary.Intersects(manrightmoveboundary))
            {
                if (rcollided == 0)
                {
                    Platform_Data.playerdata[9]++;
                }
                rcollided = 1;
            }
            else
            {
                if (rcollided == 1)
                {
                    Platform_Data.playerdata[9]--;
                }
                rcollided = 0;
            }
            if (boundary.Intersects(manbottomboundary))
            {
                if (bcollided == 0)
                {
                    Platform_Data.playerdata[10]++;
                }
                bcollided = 1;
            }
            else
            {
                if (bcollided == 1)
                {
                    Platform_Data.playerdata[10]--;
                }
                bcollided = 0;
            }

            if (boundary.Intersects(mantopboundary))
            {
                if (ucollided == 0)
                {
                    Platform_Data.playerdata[14]++;
                }
                ucollided = 1;
            }
            else
            {
                if (ucollided == 1)
                {
                    Platform_Data.playerdata[14]--;
                }
                ucollided = 0;
            }





            boundary.X = (int)(xpos + Platform_Data.GetOffsetX() + 400);
            boundary.Y = (int)(ypos + Platform_Data.GetOffsetY() + 240);

            manboundary.X = (int)Platform_Data.playerdata[0] + 27;
            manboundary.Y = (int)Platform_Data.playerdata[1] + 12;
            manleftboundary.X = (int)Platform_Data.playerdata[0] + 3;
            manleftboundary.Y = (int)Platform_Data.playerdata[1] + 12;
            manrightboundary.X = (int)Platform_Data.playerdata[0] + 51;
            manrightboundary.Y = (int)Platform_Data.playerdata[1] + 12;
            manleftmoveboundary.X = (int)Platform_Data.playerdata[0] + 25;
            manleftmoveboundary.Y = (int)Platform_Data.playerdata[1] + 12;
            manrightmoveboundary.X = (int)Platform_Data.playerdata[0] + 51;
            manrightmoveboundary.Y = (int)Platform_Data.playerdata[1] + 12;
            manbottomboundary.X = (int)Platform_Data.playerdata[0] + 31;
            manbottomboundary.Y = (int)Platform_Data.playerdata[1] + 73;
            mantopboundary.X = (int)Platform_Data.playerdata[0] + 31;
            mantopboundary.Y = (int)Platform_Data.playerdata[1] + 12;
        }

    }
}
