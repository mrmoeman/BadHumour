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
    class Enemy
    {
        public int xpos;
        public int ypos;
        int timer;
        int maxhealth;
        int health;
        int strength;
        int areareq;
        int applied;
        int collided;
        int movetemp;
        int movebob = 0;
        int height;
        int width;
        int swidth;
        int sheight;
        int initx;
        int inity;
        Rectangle boundary;
        Rectangle manboundary;
        Rectangle manleftboundary;
        Rectangle manrightboundary;
        Rectangle manleftmoveboundary;
        Rectangle manrightmoveboundary;
        Rectangle manbottomboundary;
        Rectangle mantopboundary;

        public Enemy(int x, int y, int swid, int shei, int heal, int stre, int hei, int wid)
        {
            xpos = x;
            ypos = y;
            maxhealth = heal;
            health = heal;
            strength = stre;
            height = hei;
            width = wid;
            sheight = shei;
            swidth = swid;
            initx = x;
            inity = y;
            boundary = new Rectangle(x + (wid / 2 - swid / 2), y + (hei - shei), swid, shei);
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

        public virtual void collision()
        {
            boundary.X = (int)(xpos + Platform_Data.GetOffsetX() + 400) + (width / 2 - swidth / 2);
            boundary.Y = (int)(ypos + Platform_Data.GetOffsetY() + 240) + height - sheight;

           // boundary.X = xpos + (width / 2 - swidth / 2);
           // boundary.Y = ypos + height - sheight;

            //collision
            if (boundary.Intersects(manboundary))
            {
                collided = 1;
                if (applied == 0)
                {
                    Platform_Data.playerdata[13] = 1;
                    Platform_Data.playerdata[11] += strength;
                    applied = 1;
                }
            }
            else { applied = 0; collided = 0; }
        }

        public virtual void gravity(int bottom)
        {
            if (ypos < (bottom - boundary.Height))
            {
                ypos += 1;
            }
        }

        public virtual void DealDamage(int damage)
        {
            Platform_Data.playerdata[11] += damage;
        }

        public virtual void SetHealth(int number)
        {
            health = number;
        }

        public virtual void Takedamage()
        {
            if ((Platform_Data.playerdata[7] == 1 && boundary.Intersects(manrightboundary)) || (Platform_Data.playerdata[7] == -1 && boundary.Intersects(manleftboundary)))
            {
                if (Platform_Data.playerdata[6] == 1)
                {
                    health -= 8;
                }
            }
        }

        public double GetDistance()
        {
            return Math.Sqrt((xpos + 400 + Platform_Data.GetOffsetX() - Platform_Data.playerdata[0]) * (xpos + 400 + Platform_Data.GetOffsetX() - Platform_Data.playerdata[0]) + (ypos + 240 + Platform_Data.GetOffsetY() - Platform_Data.playerdata[1]) * (ypos + 240 + Platform_Data.GetOffsetY() - Platform_Data.playerdata[1]));
        }

        public int GetCollision()
        {
            if (boundary.Intersects(manboundary))
            {
                return 1;
            }
            else { return 0; }
        }

        public int GetHit()
        {
            if ((Platform_Data.playerdata[7] == 1 && boundary.Intersects(manrightboundary)) || (Platform_Data.playerdata[7] == -1 && boundary.Intersects(manleftboundary)))
            {
            return 1;
            }
            else { return 0;}
        }

         public int AreaCheck(int area)
        {
            if (area == areareq)
            {
                return 1;
            }
            else { return 0; }
        }

         public int HealthCheck()
         {
             return health;
         }

         public virtual void draw(SpriteBatch spriteBatch)
         {

         }

        public virtual void MoveBob(int variation)
        {
            if (movetemp == 0)
            {
                if (movebob < variation)
                {
                    movebob++;
                    ypos++;
                }
                if (movebob == variation)
                {
                    movetemp = 1;
                    movebob = 0;
                }
            }
            if (movetemp == 1)
            {
                if (movebob < variation)
                {
                    movebob++;
                    ypos--;
                }
                if (movebob == variation)
                {
                    movetemp = 0;
                    movebob = 0;
                }
            }
        }

        public virtual void charge(int speed)
        {
            if (xpos > Platform_Data.playerdata[0] + 20)
            {
                xpos-= speed;
            }
            if (xpos < Platform_Data.playerdata[0] + 20)
            {
                xpos += speed;
            }
            if (ypos > Platform_Data.playerdata[1] + 30)
            {
                ypos -= speed;
            }
            if (ypos < Platform_Data.playerdata[1] + 30)
            {
                ypos += speed;
            }

        }

        public virtual void reset()
        {
            health = maxhealth;
            xpos = initx;
            ypos = inity;
            movetemp = 0;
            movebob = 0;
        }

    }
}
