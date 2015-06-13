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
    public enum Direction { Up, Left, Right, Down };
    public enum FadeState { On, FadeOut, FadeIn, Off };

    class Laser
    {
        int X;
        int Y;
        Direction direction;
        int colour;
        float alpha;
        FadeState laserstate;
        int timer = 0;
        int health;

        public Laser(FadeState startstate)
        {
            laserstate = startstate;
        }

        public void SetHealth(int heal)
        {
            health = heal;
        }



        public void Update(int x, int y, Direction dir, int color)
        {
            X = x;
            Y = y;
            direction = dir;
            colour = color;

            if (alpha > 0.4f && health > 0)
            {
                if (direction == Direction.Up)
                {
                    if (Game1.Dan_Data.GetData().X > X - 4.5f && Game1.Dan_Data.GetData().X < X + 4.5)
                    {
                        if (Game1.Dan_Data.GetData().Y < Y && Game1.Dan_Data.GetData().Y > 0)
                        {
                            Game1.Dan_Data.SetHit(1);
                        }
                    }
                }
                if (direction == Direction.Down)
                {
                    if (Game1.Dan_Data.GetData().X > X - 4.5f && Game1.Dan_Data.GetData().X < X + 4.5)
                    {
                        if (Game1.Dan_Data.GetData().Y > Y && Game1.Dan_Data.GetData().Y < 480)
                        {
                            Game1.Dan_Data.SetHit(1);
                        }
                    }
                }
                if (direction == Direction.Left)
                {
                    if (Game1.Dan_Data.GetData().X < X && Game1.Dan_Data.GetData().X > 0)
                    {
                        if (Game1.Dan_Data.GetData().Y > Y - 4.5f && Game1.Dan_Data.GetData().Y < Y + 4.5f)
                        {
                            Game1.Dan_Data.SetHit(1);
                        }
                    }
                }
                if (direction == Direction.Right)
                {
                    if (Game1.Dan_Data.GetData().X > X && Game1.Dan_Data.GetData().X < 800)
                    {
                        if (Game1.Dan_Data.GetData().Y > Y - 4.5f && Game1.Dan_Data.GetData().Y < Y + 4.5f)
                        {
                            Game1.Dan_Data.SetHit(1);
                        }
                    }
                }


            }

        }

        public void laserfade(int OnTime, int OffTime, float FadeTime)
        {
            if (laserstate == FadeState.FadeIn)
            {
                alpha += (1 / FadeTime);
                if (alpha >= 1)
                {
                    laserstate = FadeState.On;
                }
            }

            if (laserstate == FadeState.FadeOut)
            {
                alpha -= (1 / FadeTime);
                if (alpha <= 0)
                {
                    laserstate = FadeState.Off;
                }
            }
            if (laserstate == FadeState.On)
            {
                timer++;
                alpha = 1.0f;
                if (timer >= OnTime)
                {
                    timer = 0;
                    laserstate = FadeState.FadeOut;
                }
            }

            if (laserstate == FadeState.Off)
            {
                timer++;
                alpha = 0.0f;
                if (timer >= OffTime)
                {
                    timer = 0;
                    laserstate = FadeState.FadeIn;
                }
            }

        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (health > 0)
            {
                if (direction == Direction.Up)
                {
                    for (int i = Y; i > 0; i--)
                    {
                        if (colour == 1)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(X - 4.5f, i), new Rectangle(200, 0, 9, 1), Color.White * alpha);
                        }
                        if (colour == 2)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(X - 4.5f, i), new Rectangle(200, 2, 9, 1), Color.White * alpha);
                        }
                        if (colour == 3)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(X - 4.5f, i), new Rectangle(200, 4, 9, 1), Color.White * alpha);
                        }
                        if (colour == 4)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(X - 4.5f, i), new Rectangle(200, 6, 9, 1), Color.White * alpha);
                        }
                    }
                }

                if (direction == Direction.Left)
                {
                    for (int i = X; i > 0; i--)
                    {
                        if (colour == 1)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(i, Y - 4.5f), new Rectangle(200, 8, 1, 9), Color.White * alpha);
                        }
                        if (colour == 2)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(i, Y - 4.5f), new Rectangle(202, 8, 1, 9), Color.White * alpha);
                        }
                        if (colour == 3)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(i, Y - 4.5f), new Rectangle(204, 8, 1, 9), Color.White * alpha);
                        }
                        if (colour == 4)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(i, Y - 4.5f), new Rectangle(206, 8, 1, 9), Color.White * alpha);
                        }

                    }

                }

                if (direction == Direction.Right)
                {
                    for (int i = X; i < 800; i++)
                    {
                        if (colour == 1)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(i, Y - 4.5f), new Rectangle(200, 8, 1, 9), Color.White * alpha);
                        }
                        if (colour == 2)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(i, Y - 4.5f), new Rectangle(202, 8, 1, 9), Color.White * alpha);
                        }
                        if (colour == 3)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(i, Y - 4.5f), new Rectangle(204, 8, 1, 9), Color.White * alpha);
                        }
                        if (colour == 4)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(i, Y - 4.5f), new Rectangle(206, 8, 1, 9), Color.White * alpha);
                        }

                    }

                }


                if (direction == Direction.Down)
                {
                    for (int i = Y; i < 480; i++)
                    {
                        if (colour == 1)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(X - 4.5f, i), new Rectangle(200, 0, 9, 1), Color.White * alpha);
                        }
                        if (colour == 2)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(X - 4.5f, i), new Rectangle(200, 2, 9, 1), Color.White * alpha);
                        }
                        if (colour == 3)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(X - 4.5f, i), new Rectangle(200, 4, 9, 1), Color.White * alpha);
                        }
                        if (colour == 4)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(X - 4.5f, i), new Rectangle(200, 8, 9, 1), Color.White * alpha);
                        }
                    }
                }

            }

        }
    }
}
