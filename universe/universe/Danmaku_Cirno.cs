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
    class Danmaku_Cirno : Danmaku_level
    {
        float ptimer;
        public Danmaku_Cirno() : base()
        {
           // phase = 6;
            Game1.Dan_Data.SetChar(Danmaku_Character.Moeman);
        }
        
        public override void update()
        {
            base.update();
            ptimer-= 0.07f;

            if (phase == 12 && Input.GetEnter() == 1 && enterpressed == 0)
            {
                enterpressed = 1;
                phase++;
                RemoveAll();
                enemy = new Dan_Cirno_Phase_Six();
                EnemyList.Add(enemy);
                
            }

            if (phase == 11 && AllGone() == 1)
            {
                RemoveDead();
                phase++;

                enemy = new Dan_Cirno_Phase_Five();
                EnemyList.Add(enemy);
            }

            if (phase == 10 && AllGone() == 1)
            {
                RemoveDead();
                phase++;
                enemy = new Dan_Cirno_Phase_Four();
                EnemyList.Add(enemy);
            }

            if (phase == 9 && AllGone() == 1)
            {
                //RemoveAll();
                RemoveDead();
                phase++;
                enemy = new Dan_Cirno_Phase_Three();
                EnemyList.Add(enemy);
            }

            if (phase == 8 && AllGone() == 1)
            {
                phase++;
                enemy = new Dan_Cirno_Phase_Two();
                EnemyList.Add(enemy);
            }

            if (phase == 7 && Input.GetEnter() == 1 && enterpressed == 0)
            {
                enterpressed = 1;
                phase++;
                
                enemy = new Dan_Cirno_Phase_One();
                EnemyList.Add(enemy);
            }

            if (phase == 6 && Input.GetEnter() == 1 && enterpressed == 0)
            {
                enterpressed = 1;
                phase++;
            }

            if (phase == 5 && GetTimer() > 800)
            {
                phase++;
                SetTimer(0);
            }

            if (phase == 4 && AllGone() == 1 && wave == 20)
            {
                phase++;
                SetTimer(0);
            }

            if (phase == 3 && GetTimer() > 500)
            {
                phase++;
                SetTimer(0);
            }

            if (phase == 2 && GetCount() == 0)
            {
                phase++;
                SetTimer(0);
            }

            if (phase == 1 && GetCount() == 0)
            {
                enemy = new Danmaku_VShip_V2(500, 0, 1, 240);
                EnemyList.Add(enemy);
                enemy = new Danmaku_VShip_V2(600, 480, -1, 240);
                EnemyList.Add(enemy);
                phase++;
            }

            if (phase == 0 && GetTimer() > 100)
            {
                enemy = new Danmaku_VShip(500, 0, 1, 180);
                EnemyList.Add(enemy);
                enemy = new Danmaku_VShip(500, -80, 1, 80);
                EnemyList.Add(enemy);
                enemy = new Danmaku_VShip(500, 480, -1, 480 - 180);
                EnemyList.Add(enemy);
                enemy = new Danmaku_VShip(500, 560, -1, 480 - 80);
                EnemyList.Add(enemy);
                phase++;
            }

            if (phase == 4 && wave < 20 && GetTimer() > 100)
            {
                enemy = new Dan_Mine(-1f, 999);
                EnemyList.Add(enemy);
                SetTimer(0);
                wave++;
            }

            if (phase == 7)
            {
                RemoveAll();
            }

            if (phase == 13)
            {
                if (AllGone() == 1)
                {
                    phase++;
                    SetTimer(0);
                }
            }

            if (phase == 14)
            {
                if (GetTimer() > 150)
                {
                    LevelEnd();
                }
            }

        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game1.black, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(Game1.Planet_A, new Vector2(500 + ptimer,0), new Rectangle(0, 350, 800, 450), Color.White * 0.9f);
            base.draw(spriteBatch);

            if (phase == 6)
            {
                PopUp_Dialog.draw(spriteBatch, "All ships stand down!", "Leave him to me, Da Ze.","", 0, 1, 1, 2, 2);
            }

            if (phase == 7)
            {
                PopUp_Dialog.draw(spriteBatch, "Your Naviety always ends in", "recklessness. Will you never", "learn little Miss C?", 2, 1, 1, 2, 1);
            }

            if (phase == 12)
            {
                PopUp_Dialog.draw(spriteBatch, "All crew prepare to evacuate!", "", "", 0, 1, 1, 2, 2);
            }

        }
    
    }
}
