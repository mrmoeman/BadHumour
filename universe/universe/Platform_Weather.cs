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
    class Platform_Weather
    {
        Weather_Particle part;
        List<Weather_Particle> Part_List = new List<Weather_Particle>();
        float XSpeed;
        float YSpeed;
        int Density;
        int Type;
        int start;
        int timer;
        Random rnd = new Random();

        public Platform_Weather(int density, float xspeed, float yspeed, int type, int startpos)
        {
            XSpeed = xspeed;
            YSpeed = yspeed;
            Density = density;
            Type = type;
            start = startpos;
        }


        public void update()
        {
            timer++;
            if (start == 1)
            {
                for (int i = 0; i < Density; i++)
                {

                    part = new Weather_Particle(rnd.Next(6000) - 1000 , 200);
                    //if (part.GetXpos() > -600 && part.GetXpos() < 1400)
                   // {
                        Part_List.Add(part);
                    //}
                }
            }

            if (Type == 1 || Type == 2)
            {
                Part_List.ForEach(i => i.RectSet(5, 9));
            }

            Part_List.ForEach(i => i.MoveX(XSpeed));
            Part_List.ForEach(i => i.MoveY(YSpeed));
        }

        public void CheckCol(Rectangle Temp_Bound)
        {
            Part_List.ForEach(i =>
                {
                    i.CheckCol(Temp_Bound);
                    if (i.GetCollided() == 1)
                    {
                        Part_List.Remove(i);
                    }
                    if (i.GetYpos() > 480)
                    {
                        Part_List.Remove(i);
                    }
                    if (Type == 2 && timer > 15 && Platform_Data.GetLevelStart() == 1)
                    {
                        if (i.CheckPlayer() == 1)
                        {
                            Platform_Data.playerdata[15] = 1;
                            timer = 0;
                        }
                    }
                });
        }


        public void draw(SpriteBatch spriteBatch)
        {
            Part_List.ForEach(i =>
                {
                    if (i.GetCollided() == 0 && i.GetYpos() > 0 && i.GetYpos() < 480 && i.GetXpos() > 0 && i.GetXpos() < 800)
                    {
                        if (Type == 1)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(i.xpos + Platform_Data.GetOffsetX() + 400, i.ypos + Platform_Data.GetOffsetY() + 240), new Rectangle(75, 89, 5, 9), Color.White * 0.5f);
                        }
                        if (Type == 2)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(i.xpos + Platform_Data.GetOffsetX() + 400, i.ypos + Platform_Data.GetOffsetY() + 240), new Rectangle(81, 89, 5, 9), Color.White * 0.5f);
                        }
                    }
                });
           // spriteBatch.DrawString(Game1.Arial, "" + Part_List.Count, new Vector2(50, 23), Color.White);
        }

    }




    class Weather_Particle
    {

        public float xpos;
        public float ypos;
        int collided;
        Rectangle part_bound;
        Rectangle playerb;

        public Weather_Particle(int x, int y)
        {
            xpos = x;
            ypos = y;
            playerb = new Rectangle(0, 0, 24, 58);
            playerb.X = 400 + 27;
            playerb.Y = 240 + 12;
        }

        public int GetYpos()
        {
            return (int)(ypos + Platform_Data.GetOffsetY() + 240);
        }

        public int GetXpos()
        {
            return (int)(xpos + Platform_Data.GetOffsetX() + 400);
        }

        public void RectSet(int width, int height)
        {
            part_bound = new Rectangle((int)(xpos + Platform_Data.GetOffsetX() + 400), (int)(ypos + Platform_Data.GetOffsetY() + 240), width, height);
        }

        public void MoveY(float number)
        {
            ypos += number;
        }

        public void MoveX(float number)
        {
            xpos += number;
        }

        public void CheckCol(Rectangle Temp_Bound)
        {
            if (part_bound.Intersects(Temp_Bound))
            {
                collided = 1;
            }
        }

        public int CheckPlayer()
        {
            if (part_bound.Intersects(playerb))
            {
                return 1;
            }
            else return 0;
        }


        public int GetCollided()
        {
            return collided;
        }

    }

}
