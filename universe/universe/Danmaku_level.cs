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
    class Danmaku_level
    {
        public int phase;
        int oldphase;
        int timer;
        int offscreen;
        public int wave;
        public int enterpressed;
        int playerreset;
        int mtimer;
        Boolean AllReleased = false;

        Danmaku_Player player;

        public Danmaku_Enemy enemy;
        public List<Danmaku_Enemy> EnemyList = new List<Danmaku_Enemy>();
        List<Danmaku_Enemy> EnemyListDead = new List<Danmaku_Enemy>();


        public Danmaku_level()
        {
            player = new Danmaku_Player();

        }

        public virtual void update()
        {
            if (player.GetHealth() > 0)
            {
                if (Input.GetEnter() == 0 && enterpressed == 1)
                {
                    enterpressed = 0;
                }
                offscreen = 0;
                timer++;

                oldphase = phase;
                EnemyList.ForEach(i => i.update());
                EnemyListDead.ForEach(i => i.update());
                HealthCheck();

                player.Update();



                player.Bulletlist.ForEach(i =>
                {
                    //i.GetBullet();
                    EnemyList.ForEach(p => { p.PlayerBulletCheck((int)i.GetBullet().X, (int)i.GetBullet().Y); });
                });

            }

            if (player.GetHealth() == 0)
            {
                mtimer++;
                if (Input.GetZ() == 0 && Input.GetX() == 0 && Input.GetC() == 0)
                {
                    AllReleased = true;
                }
                if (AllReleased == true)
                {
                    if (Input.GetZ() == 1)
                    {
                        Game1.gamestate = 1;
                        AllReleased = false;
                        mtimer = 0;
                    }
                    if (Input.GetX() == 1)
                    {
                        Game1.dan_reset = 1;
                        AllReleased = false;
                        mtimer = 0;
                    }
                    if (Input.GetC() == 1)
                    {
                        player = new Danmaku_Player();
                        playerreset++;
                        AllReleased = false;
                        mtimer = 0;
                    }
                }
            }
           
        }

        protected void SetTimer(int number)
        {
            timer = number;
        }

        protected int GetTimer()
        {
            return timer;
        }

        public void LevelEnd()
        {
            Game1.gamestate = 1;
        }

        public void RemoveAll()
        {
            EnemyList.ForEach(i =>
            {
                    EnemyList.Remove(i);
            });
            EnemyListDead.ForEach(i =>
            {
                EnemyListDead.Remove(i);
            });

        }

        public void RemoveDead()
        {
            EnemyListDead.ForEach(i =>
            {
                EnemyListDead.Remove(i);
            });

        }

        public int AllGone()
        {
            EnemyList.ForEach(i =>
            {
                if (i.GetOffScreen() == 0)
                {
                    offscreen++;
                }
            });
            if (offscreen == 0)
            {
                return 1;
            }
            else { return 0; }
        }

        public int GetCount()
        {
            return EnemyList.Count;
        }

        public void HealthCheck()
        {
            EnemyList.ForEach(i =>{
                if (i.GetHealth() <= 0)
                {
                    EnemyListDead.Add(i);
                    EnemyList.Remove(i);
                }
            });
        }

        public int PhaseSwitch()
        {
            if (phase != oldphase)
            {
                return 1;
            }
            return 0;
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            
            //spriteBatch.DrawString(Game1.Arial, "" + phase, new Vector2(50, 23), Color.White);
            EnemyList.ForEach(i => i.drawship(spriteBatch));
            EnemyListDead.ForEach(i => i.drawship(spriteBatch));
            player.draw(spriteBatch);

            if (player.GetHealth() == 0)
            {
                spriteBatch.Draw(Game1.Dan_R_Menu, new Vector2(150, 100), Color.White);
            }
        }

    }
}
