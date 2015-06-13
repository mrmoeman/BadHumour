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
    class PhyObj
    {

        public int xpos;
        public int ypos;
        public int oldxpos;
        public int oldypos;
        int shape;
        int width;
        int height;
        int bottom;
        int weight;
        public int strength;
        int displacement;
        public int displaced = 0;
        Rectangle boundary;
        int lcollided;
        int rcollided;
        int bcollided;
        int swidth;
        int sheight;
        int speed;
        int moving;
        int oldmoving;
        public int maxstrength;
        int sprites;
        int ydisplaced;
        int moveable;
        int initx;
        int inity;
        Rectangle manboundary;
        Rectangle manleftboundary;
        Rectangle manrightboundary;
        Rectangle manleftmoveboundary;
        Rectangle manrightmoveboundary;
        Rectangle manbottomboundary;
        Rectangle mantopboundary;


        public PhyObj(int sha, int x, int y, int wid, int hei, int wei, int stre, int displace, int swid, int shei, int spri, int ydis, int move)
        {
            initx = x;
            inity = y;
            shape = sha;
            xpos = x;
            ypos = y;
            width = wid;
            height = hei;
            weight = wei;
            strength = stre;
            displacement = displace;
            swidth = swid;
            sheight = shei;
            maxstrength = stre;
            sprites = spri;
            ydisplaced = ydis;
            moveable = move;
            boundary = new Rectangle(x+(displace/2 - swid/2), y+(height-shei), swid, shei);
            manboundary = new Rectangle(0, 0, 24, 58);
            manleftboundary = new Rectangle(0, 0, 24, 54);
            manrightboundary = new Rectangle(0, 0, 24, 54);
            manleftmoveboundary = new Rectangle(0, 0, 2, 54);
            manrightmoveboundary = new Rectangle(0, 0, 2, 54);
            mantopboundary = new Rectangle(0, 0, 18, 2);
            manbottomboundary = new Rectangle(0, 0, 18, 2);
        }

        public PhyObj(int sha, int x, int y, int wid, int hei, int wei, int stre, int displace, int swid, int shei, int spri, int ydis)
        {
            shape = sha;
            xpos = x;
            ypos = y;
            width = wid;
            height = hei;
            weight = wei;
            strength = stre;
            displacement = displace;
            swidth = swid;
            sheight = shei;
            maxstrength = stre;
            sprites = spri;
            ydisplaced = ydis;
            boundary = new Rectangle(x + (displace / 2 - swid / 2), y + (height - shei), swid, shei);
            manboundary = new Rectangle(0, 0, 24, 58);
            manleftboundary = new Rectangle(0, 0, 24, 54);
            manrightboundary = new Rectangle(0, 0, 24, 54);
            manleftmoveboundary = new Rectangle(0, 0, 2, 54);
            manrightmoveboundary = new Rectangle(0, 0, 2, 54);
            mantopboundary = new Rectangle(0, 0, 18, 2);
            manbottomboundary = new Rectangle(0, 0, 18, 2);
        }


        public virtual void update()
        {

                boundary.X = (int)(xpos + Platform_Data.GetOffsetX() + 400) + (displacement / 2 - swidth / 2);
                boundary.Y = (int)(ypos + Platform_Data.GetOffsetY() + 240) + height - sheight;

               // boundary.X = xpos + (displacement / 2 - swidth / 2);
               // boundary.Y = ypos + height - sheight;

                speed = (int)(weight * 9.8) / 25;

                oldmoving = moving;


                //gravity
             /*   if (ypos < (bottom - height))
                {
                    ypos += speed;
                    moving = 1;
                }
                if (ypos > (bottom - height))
                {
                    ypos = bottom - height;
                    moving = 0;
                }

                //hit ground
                if (oldmoving > moving)
                {
                    if (weight > strength)
                    {
                        strength -= (weight + 6 - strength);
                    }
                }
            */
                //damage showing
                for (int x = sprites - 1; x > 0; x--)
                {
                    if (strength <= (maxstrength / sprites) * x)
                    {
                        displaced = displacement * (sprites - x);
                    }
                }

                /*
                if (strength < (maxstrength / sprites) * 2)
                {
                    displaced = displacement;
                }
                if (strength < (maxstrength / sprites))
                {
                    displaced = displacement * 2;
                }
                */

                //destroyed
                if (strength <= 0)
                {
                    if (ypos > -400)
                    {
                    oldxpos = xpos;
                    oldypos = ypos;
                    }
                    ypos = -500;
                }

                //moveable object
                if (moveable == 1)
                {
                    if (boundary.Intersects(manleftmoveboundary) && strength > 0) // left
                    {
                        xpos--;
                    }
                    if (boundary.Intersects(manrightmoveboundary) && strength > 0)
                    {
                        xpos++;
                    }

                }

                //collison
                if (boundary.Intersects(manleftmoveboundary) && strength > 0)//right
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
                if (boundary.Intersects(manrightmoveboundary) && strength > 0)
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
                if (boundary.Intersects(manbottomboundary) && strength > 0)
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

                //being hit by player?
                if ((Platform_Data.playerdata[7] == 1 && boundary.Intersects(manrightboundary)) || (Platform_Data.playerdata[7] == -1 && boundary.Intersects(manleftboundary)))
                {
                    if (Platform_Data.playerdata[6] == 1)
                    {
                        strength -= 8;
                    }
                }

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

        public virtual void draw(SpriteBatch spriteBatch)
        {

               // spriteBatch.DrawString(Game1.Arial, "ypos: " + strength, new Vector2(250, 23), Color.White);
               // spriteBatch.DrawString(Game1.Arial, "xpos: " + displaced, new Vector2(250, 38), Color.White);

            spriteBatch.Draw(Game1.phyobj, new Vector2(xpos + 400 + Platform_Data.GetOffsetX(), ypos + 240 + Platform_Data.GetOffsetY()), new Rectangle(displaced, ydisplaced, 40, 40), Color.White);

        }


        public void reset()
        {
            strength = maxstrength;
            displaced = 0;
            xpos = initx;
            ypos = inity;


        }

    }


}
