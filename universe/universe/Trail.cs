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
    
    class Trail
    {
        particle NewParticle;
        List<particle> particlelist = new List<particle>();
        int type;
        int timer = 100;
        int oldx = 0;
        int oldy = 0;
        Random rnd = new Random();

        public void AddParticle(int x, int y, int fade)
        {
            NewParticle = new particle(x, y, fade);
            particlelist.Add(NewParticle);
        }

        public void BubbleParticles(int x, int y, int fade, int oldx, int oldy)
        {
            type = 2;
            particlelist.ForEach(i =>
            {
                i.SetPosition(x, y);
            });
            timer++;
            if (timer > fade)
            {
                NewParticle = new particle(x, y, fade + rnd.Next(0, fade*2));
                NewParticle.SetDiff(rnd.Next(-5, 5), rnd.Next(-4, 4));
                particlelist.Add(NewParticle);
                NewParticle = new particle(x, y, fade + rnd.Next(0, fade*2));
                NewParticle.SetDiff(rnd.Next(-5, 5), rnd.Next(-4, 4));
                particlelist.Add(NewParticle);
                timer = 0;
            }
           
        }

        public void SetType(int number)
        {
            type = number;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            particlelist.ForEach(i =>{
                i.update();
                if (i.GetTrans() == 1)
                {
                    particlelist.Remove(i);
                }

            });
            if (type == 1)
            {
                particlelist.ForEach(i =>{
                spriteBatch.Draw(Game1.bullet, new Vector2(i.GetX()+1, i.GetY()+1), new Rectangle(189, 75, 3, 3), Color.White * (1-i.GetTrans()));
                });
            }

            if (type == 2)
            {
                particlelist.ForEach(i =>
                {
                    if (i.GetTrans() > 0.8){
                        spriteBatch.Draw(Game1.bullet, new Vector2(i.GetX() + i.GetDiffX(), i.GetY() + i.GetDiffY()), new Rectangle(195, 95, 3, 3), Color.White * (1 - i.GetTrans()/2));
                    }

                    if (i.GetTrans() > 0.6 && i.GetTrans() <= 0.8)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(i.GetX() + i.GetDiffX(), i.GetY() + i.GetDiffY()), new Rectangle(190, 95, 3, 3), Color.White * (1 - i.GetTrans()/2));
                    }

                    if (i.GetTrans() > 0.4 && i.GetTrans() <= 0.6)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(i.GetX() + i.GetDiffX(), i.GetY() + i.GetDiffY()), new Rectangle(185, 95, 3, 3), Color.White * (1 - i.GetTrans()/2));
                    }

                    if (i.GetTrans() > 0.2 && i.GetTrans() <= 0.4)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(i.GetX() + i.GetDiffX(), i.GetY() + i.GetDiffY()), new Rectangle(180, 95, 3, 3), Color.White * (1 - i.GetTrans()/2));
                    }

                    if (i.GetTrans() <= 0.2)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(i.GetX() + i.GetDiffX(), i.GetY() + i.GetDiffY()), new Rectangle(175, 95, 3, 3), Color.White * (1 - i.GetTrans()/3));
                    }
                });
            }

        }



    }

    class particle
    {
        int initx;
        int inity;
        int diffx;
        int diffy;
        int oldx;
        int oldy;
        int timer;
        float trans;
        int fadetime;
        public particle(int x, int y, int fade)
        {
            initx = x;
            inity = y;
            fadetime = fade;
        }

        public void SetPosition(int x, int y)
        {
            initx = x;
            inity = y;
        }

        public void SetDiff(int x, int y)
        {
            diffx = x;
            diffy = y;
        }

        public void update()
        {
            timer++;
            if (timer >= fadetime)
            {
                trans += 0.1f;
                timer = 0;
            }
        }


        public void SetOld(int x, int y)
        {
            oldx = x;
            oldy = y;
        }

        public int GetX()
        {
            return initx;
        }

        public int GetDiffX()
        {
            return diffx;
        }

        public int GetDiffY()
        {
            return diffy;
        }

        public int GetY()
        {
            return inity;
        }

        public float GetTrans()
        {
            return trans;
        }
    }
}
