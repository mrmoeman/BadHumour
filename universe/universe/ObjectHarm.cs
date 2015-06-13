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
    class ObjectHarm
    {
        int xpos;
        int ypos;
        int type;
        int damage;
        int areareq;
        int applied;
        int timer;
        int allowed;

        Rectangle boundary;
        //1 - wire

        public ObjectHarm(int xposition, int yposition, int objecttype, int damag, int areare)
        {
            xpos = xposition;
            ypos = yposition;
            type = objecttype;
            damage = damag;
            areareq = areare;
            if (type == 1)
            {
                boundary = new Rectangle(xpos, ypos, 62, 138);
            }
        }

        public void update(int area)
        {
            if (area == areareq){
                if (type == 1)
                {
                    if (boundary.Intersects(Game1.manboundary) && allowed == 0)
                    {
                        if (applied == 0)
                        {
                            Game1.playerdata[13] = 1;
                            Game1.playerdata[11] += damage;
                            applied = 1;
                        }
                    }
                    else {applied = 0;}
                }




            }
        }

        public void objectdraw(SpriteBatch spriteBatch, int area)
        {
            if (area == areareq)
            {
                timer++;
                if (type == 1)
                {
                    if (timer < 10 || allowed == 1)
                    {
                        spriteBatch.Draw(Game1.wire, new Vector2(xpos, ypos), new Rectangle(0, 0, 62, 138), Color.White);
                    }
                    if (timer >= 10 && allowed == 0)
                    {
                        spriteBatch.Draw(Game1.wire, new Vector2(xpos, ypos), new Rectangle(62, 0, 62, 138), Color.White);
                    }
                    if (timer > 20 && allowed == 0)
                    {
                        timer = 0;
                    }
                }

            }
        }


        public void SetPower(int number)
        {
            allowed = number;
        }

        public void SetDamage(int number)
        {
            damage = number;
        }
    }
}
