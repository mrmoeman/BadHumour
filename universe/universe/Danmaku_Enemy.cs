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
    class Danmaku_Enemy
    {
        double basetimer;
        int initx;
        int inity;
        int xpos;
        int ypos;
        float speed;
        int maxhealth;
        int health;
        int width;
        int height;
        public int centerx;
        public int centery;
        int timer;
        int timer_two;
        int tempx;
        int tempy;
        double temp;
        int setup;
        int wave;
        float h_bar;
        int h_colour;
        int noexplo = 0;
        int showbar = 0;
        Bullet bullet;
        public List<Bullet> Bulletlist = new List<Bullet>();
        List<Bullet> Bulletlist_Two = new List<Bullet>();
        Rectangle Boundary;
        Rectangle Temp;
        Effect explosion = new Effect();
        Vector2 tempvect;
        int bombed;
        int sethit;
        int powergive = 1;
        Boolean timerreset = false;

        public Danmaku_Enemy(int x, int y, float spee, int heal, int wid, int hei)
        {
            initx = x;
            inity = y;
            xpos = x;
            ypos = y;
            width = wid;
            height = hei;
            health = heal;
            maxhealth = heal;
            speed = spee;
            Boundary = new Rectangle(x, y, wid, hei);
        }

        public int GetOffTop()
        {
            if (ypos < 0)
            {
                return 1;
            }
            return 0;
        }

        public int GetOffBottom()
        {
            if (ypos > 480)
            {
                return 1;
            }
            return 0;
        }

        public int GetOffScreen()
        {
            if (ypos > 480 || ypos < 0 || xpos < 0 || xpos > 800)
            {
                return 1;
            }
            return 0;
        }

        public int GetHealth()
        {
            return health;
        }

        public float GetSpeed()
        {
            return speed;
        }

        public int GetXpos()
        {
            return xpos;
        }

        public int GetYpos()
        {
            return ypos;
        }

        public void SetExplosion(int number)
        {
            noexplo = 1;
        }

        public void Invincible()
        {
            health = maxhealth;
        }

        public void SetBar(int number, int colour)
        {
            showbar = number;
            h_colour = colour;
        }

        public int GetBombed()
        {
            if (Game1.Dan_Data.GetBomb() == 1)
            {
                tempvect = Game1.Dan_Data.GetBombVector();
                if (Math.Sqrt((centerx + 25 - tempvect.X) * (centerx + 25 - tempvect.X) + (centery + 25 - tempvect.Y) * (centery + 25 - tempvect.Y)) <= Game1.Dan_Data.GetBombRadius())
                {
                    return 1;
                }
                else { return 0; }
            }
            else
            {
                return 0;
            }
        }

        public virtual void update()
        {
            h_bar = ((429000 / maxhealth) * health)/1000;
            centerx = xpos + width / 2;
            centery = ypos + height / 2;
            Boundary.X = xpos;
            Boundary.Y = ypos;
            basetimer+=0.01;
            if (GetBombed() == 1 && bombed == 0)
            {
                health -= 50;
                bombed = 1;
            }
            if (bombed == 1 && Game1.Dan_Data.GetBomb() == 0)
            {
                bombed = 0;
            }

            if (sethit == 0 && health <= 0)
            {
                Game1.Dan_Data.IncEnemyHit(powergive);
                sethit = 1;
            }

        }

        public void SetPowerGive(int number)
        {
            powergive = number;
        }

        public virtual void PlayerBulletCheck(int x, int y)
        {
            Temp = new Rectangle(x, y, 6, 6);
            if (Boundary.Intersects(Temp))
            {
                health -= 1;
            }
        }


        public virtual void AddBullet(int time)
        {
            timer++;
            if (timer > time && health > 0)
            {
                bullet = new Bullet(centerx, centery);
                Bulletlist.Add(bullet);
                timer = 0;
            }
        }

        public virtual void MoveOscilateX(int variation, int speedy)
        {
            if (setup == 0)
            {
                basetimer = 0;
                tempx = centerx;
                tempy = centery;
                temp = basetimer;
                setup = 1;
            }
            SetXpos(tempx + (float)Math.Sin((basetimer - temp) * speedy) * (variation));
        }

        public virtual void MoveOscilateY(int variation, int speedy)
        {
            if (setup == 0)
            {
                basetimer = 0;
                tempx = xpos;
                tempy = ypos;
                temp = basetimer;
                setup = 1;
            }
            SetYpos(tempy + (((float)Math.Sin((basetimer - temp) * speedy) * (variation)) - ((float)Math.Sin((basetimer - temp) * speedy) * (variation))/2));
        }

        public virtual void RemoveBullet()
        {
            Bulletlist.ForEach(i => { if (i.GetOffTop() == 1) { Bulletlist.Remove(i); } });
        }

        public virtual void MoveXpos()
        {
            xpos += (int)speed;
        }

        public virtual void MoveYpos()
        {
            ypos += (int)speed;
        }

        public virtual void SetHealth(int number)
        {
            health = number;
        }

        public virtual void SetMaxHealth(int number)
        {
            maxhealth = number;
        }

        public virtual void SetXpos(float number)
        {
            xpos =(int) number;
        }

        public virtual void SetYpos(float number)
        {
            ypos =(int) number;
        }

        public virtual void SetSpeed(int number)
        {
            speed = number;
        }

        public virtual void draw(SpriteBatch spriteBatch, int x, int y)
        {
            
                Bulletlist.ForEach(i => i.draw(spriteBatch));

                Bulletlist_Two.ForEach(i =>{
                   // if (i.GetWave() <= wave)
                   // {
                        i.draw(spriteBatch);
                   // }
                });

                if (health > 0)
                {
                    spriteBatch.Draw(Game1.eship, new Vector2(xpos, ypos), new Rectangle(x, y, width, height), Color.White);
                }

                if (health <= 0 && noexplo == 0)
                {
                    explosion.draw(centerx - 35, centery -35, spriteBatch, 2);
                }

                if (showbar > 0 && health > 0)
                {
                    spriteBatch.Draw(Game1.Health_Bar, new Vector2(770, 20), new Rectangle(0, 0, 25, 440), Color.White);

                    for (int i = 0; i < h_bar; i++)
                    {
                        spriteBatch.Draw(Game1.Health_Bar, new Vector2(775, 25+i +(int)((429-h_bar)/2)), new Rectangle(25, h_colour, 15, 1), Color.White);
                    }

                   // spriteBatch.DrawString(Game1.Arial, "" + h_bar, new Vector2(50, 30), Color.White);
                   // spriteBatch.DrawString(Game1.Arial, "" + health, new Vector2(50, 40), Color.White);
                   // spriteBatch.DrawString(Game1.Arial, "" + maxhealth, new Vector2(50, 50), Color.White);


                }
            
        }

        public virtual void drawship(SpriteBatch spriteBatch)
        {
        }

        public void reset()
        {
            health = maxhealth;
            xpos = initx;
            ypos = inity;
        }

        public void resetpos()
        {
            xpos = initx;
            ypos = inity;
        }

    }
}
