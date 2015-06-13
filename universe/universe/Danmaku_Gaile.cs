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
    class Danmaku_Gaile : Danmaku_level
    {
        float ptimer;

        Random RND = new Random();
        int temp;

        public Danmaku_Gaile()
            : base()
        {
            //phase = 7;
            Game1.Dan_Data.SetChar(Danmaku_Character.Gaile);
            
        }

        public override void update()
        {
            base.update();
            ptimer -= 0.07f;




            if (phase == 0 && GetTimer() > 100)
            {
               enemy = new Silax_Laser_Ship(500, 0, 1, 180);
                EnemyList.Add(enemy);
                enemy = new Silax_Laser_Ship(500, -80, 1, 80);
                EnemyList.Add(enemy);
                enemy = new Silax_Laser_Ship(500, 480, -1, 480 - 180);
                EnemyList.Add(enemy);
                enemy = new Silax_Laser_Ship(500, 560, -1, 480 - 80);
                EnemyList.Add(enemy);

                enemy = new Silax_Gun_Ship(650, -80, 1, 100);
                EnemyList.Add(enemy);
                enemy = new Silax_Gun_Ship(650, 500, -1, 480 - 100);
                EnemyList.Add(enemy);
                phase++;
                SetTimer(0);
            }

            if (phase == 1)
            {
                if (GetTimer() > 300)
                {
                    phase++;
                    SetTimer(0);
                }
            }

            if (phase == 2)
            {
                if (GetTimer() > 300)
                {
                    phase++;
                    SetTimer(0);
                }
            }

            if (phase == 3)
            {
                if (AllGone() == 1)
                {
                    phase++;
                    SetTimer(0);
                }
            }
            if (phase == 4)
            {
                if (GetTimer() % 250 == 0)
                {
                    temp = RND.Next(0, 200);
                    enemy = new Silax_Psion_Ship(temp + 300, -50, Direction.Down, 2);
                    EnemyList.Add(enemy);

                    enemy = new Silax_Psion_Ship(temp + 360, -80, Direction.Down, 2);
                    EnemyList.Add(enemy);

                    if (GetTimer() % 750 != 0)
                    {
                        enemy = new Silax_Psion_Ship(temp + 420, -110, Direction.Down, 2);
                        EnemyList.Add(enemy);
                    }
                    else
                    {
                        enemy = new Silax_Laser_Ship(500, -80, 1, 80);
                        EnemyList.Add(enemy);
                        enemy = new Silax_Laser_Ship(500, 560, -1, 480 - 80);
                        EnemyList.Add(enemy);
                    }

                    temp = RND.Next(0, 200);
                    enemy = new Silax_Psion_Ship(temp + 300, 480, Direction.Up, 2);
                    EnemyList.Add(enemy);

                    enemy = new Silax_Psion_Ship(temp + 360, 510, Direction.Up, 2);
                    EnemyList.Add(enemy);

                    if (GetTimer() % 750 != 0)
                    {
                        enemy = new Silax_Psion_Ship(temp + 420, 540, Direction.Up, 2);
                        EnemyList.Add(enemy);
                    }
                    //phase++;
                }
                if (GetTimer() > 3500)
                {
                    phase++;
                    SetTimer(0);
                }

            }

            if (phase == 5)
            {
                if (GetTimer() > 300)
                {
                    phase++;
                    SetTimer(0);
                }
            }

            if (phase == 6)
            {
                if (GetTimer() % 250 == 0)
                {
                    temp = RND.Next(0, 200);
                    enemy = new Silax_Psion_Ship(temp + 300, -50, Direction.Down, 2);
                    EnemyList.Add(enemy);
                    enemy = new Silax_Psion_Ship(temp + 320, -110, Direction.Down, 2);
                    EnemyList.Add(enemy);

                    temp = RND.Next(0, 200);
                    enemy = new Silax_Psion_Ship(temp + 300, 480, Direction.Up, 2);
                    EnemyList.Add(enemy);
                    enemy = new Silax_Psion_Ship(temp + 320, 540, Direction.Up, 2);
                    EnemyList.Add(enemy);

                    if (GetTimer() % 750 == 0)
                    {
                        enemy = new Silax_Gun_Ship_V2(650, -80, 1, 200);
                        EnemyList.Add(enemy);
                    }

                    if (GetTimer() > 1800)
                    {
                        phase++;
                        SetTimer(0);
                    }
                

                }

            }

            if (phase == 7)
            {
                if (GetTimer() > 300)
                {
                    phase++;
                    SetTimer(0);
                }
            }

            if (phase == 8)
            {
                if (GetTimer() > 300)
                {
                    phase++;
                    SetTimer(0);
                    enemy = new Silax_Breeder_Ship();
                    EnemyList.Add(enemy);
                }
            }

            if (phase == 9)
            {
                if (GetTimer() > 300)
                {
                    phase++;
                    SetTimer(0);
                }
            }

            if (phase == 10)
            {
                if (Game1.Dan_Data.GetPass() > 3)
                {
                    phase++;
                    SetTimer(0);
                }
            }

            if (phase == 11)
            {
                if (GetTimer() > 300)
                {
                    phase++;
                    SetTimer(0);
                }
            }

            if (phase == 12)
            {
                if (GetTimer() > 300)
                {
                    phase++;
                    SetTimer(0);
                }
            }

            if (phase == 13)
            {
                if (GetTimer() > 300)
                {
                    phase++;
                    SetTimer(0);
                }
            }

            if (phase == 14)
            {
                if (GetTimer() > 300)
                {
                    phase++;
                    SetTimer(0);
                }
            }

            if (phase == 15)
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
            spriteBatch.Draw(Game1.Planet_B, new Vector2(500 + ptimer, 0), new Rectangle(0, 350, 800, 450), Color.White * 0.9f);
            base.draw(spriteBatch);

            if (phase == 1)
            {
                PopUp_Dialog.draw(spriteBatch, "Gah, looks like they are", "already here! All crew to", "combat readiness!", 9, 1, 0, 0, 1);
            }

            if (phase == 2)
            {
                PopUp_Dialog.draw(spriteBatch, "I'll prepare my fighter", "now, Captain.", " ", 10, 1, 0, 0, 1);
            }

            if (phase == 4 && GetTimer() > 1850 && GetTimer() < 2150)
            {
                PopUp_Dialog.draw(spriteBatch, "These Blasted Psionic ships", "dont stop coming!", "", 9, 1, 0, 0, 1);
            }

            if (phase == 5)
            {
                PopUp_Dialog.draw(spriteBatch, "If the fleet doesn't come", "soon, we'll be overwhelmed.", " ", 10, 1, 0, 0, 1);
            }

            if (phase == 6 && GetTimer() > 1550 && GetTimer() < 1850)
            {
                PopUp_Dialog.draw(spriteBatch, "What's that up ahead Captain", "Gaile?", " ", 10, 1, 0, 0, 1);
            }
            if (phase == 7)
            {
                PopUp_Dialog.draw(spriteBatch, "Oh god, this isn't good!", "", "", 9, 1, 0, 0, 1);
            }
            if (phase == 8)
            {
                PopUp_Dialog.draw(spriteBatch, "What is it?", "", "", 10, 1, 0, 0, 1);
            }
            if (phase == 9)
            {
                PopUp_Dialog.draw(spriteBatch, "A breeder ship, if that", "thing gets close to the planet,", "it's all over!", 9, 1, 0, 0, 1);
            }

            if (phase == 11)
            {
                PopUp_Dialog.draw(spriteBatch, "This is Admiral Cirno of the", "HDF, is anyone there?", "", 0, 0, 1, 2, 2);
            }

            if (phase == 12)
            {
                PopUp_Dialog.draw(spriteBatch, "Took you're sweet time lady!", "", "", 9, 1, 1, 2, 1);
            }

            if (phase == 13)
            {
                PopUp_Dialog.draw(spriteBatch, "Thank goodness, you're alive.", "All ships eradicate the silax", "threat!", 9, 1, 1, 2, 2);
            }

            if (phase == 14)
            {
                PopUp_Dialog.draw(spriteBatch, "Well i guess we can finally", "take a break.", "", 10, 1, 0, 0, 1);
            }

        }

    }
}
