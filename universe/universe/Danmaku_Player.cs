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
    class Danmaku_Player
    {
        int xpos = 0;
        int ypos = 240;
        int speed = 5;
        int healthold;
        int health = 5;
        Bullet bullet;
        Bullet_Spell BS_Spell;
        int timer = 10;
        int invintimer = 100;
        int bomb;
        int bombs = 3;
        int rad;
        int btimer;
        int power;
        public List<Bullet> Bulletlist = new List<Bullet>();

        public Danmaku_Player(){
            BS_Spell = new Bullet_Spell(0);
        }

        public int GetXpos()
        {
            return xpos;
        }
        public int GetYpos()
        {
            return ypos;
        }

        public int GetHealth()
        {
            return health;
        }


        public void Update()
        {
            timer++;
            btimer++;
            if ((Input.GetUp() == 1 ) && ypos > 0)
            {
                ypos-= speed;
            }
            if ((Input.GetDown() == 1 ) && ypos < 440)
            {
                ypos+= speed;
            }
            if ((Input.GetLeft() == 1 ) && xpos > 0)
            {
                xpos-= speed;
            }
            if ((Input.GetRight() == 1 ) && xpos < 770)
            {
                xpos+= speed;
            }
            if (Input.GetC() == 1)
            {
                speed = 3;
            }
            else { speed = 5; }

            if (Input.GetZ() == 1 && timer >= 4)
            {
                if (power < 2)
                {
                    bullet = new Bullet(xpos + 20, ypos + 15, "player");
                    Bulletlist.Add(bullet);
                }
                if (power >= 2 && power < 5)
                {
                    bullet = new Bullet(xpos + 20, ypos + 10, "player");
                    Bulletlist.Add(bullet);
                    bullet = new Bullet(xpos + 20, ypos + 20, "player");
                    Bulletlist.Add(bullet);
                }
                if (power >= 5)
                {
                    bullet = new Bullet(xpos + 20, ypos + 10, "player");
                    Bulletlist.Add(bullet);
                    bullet = new Bullet(xpos + 20, ypos + 20, "player");
                    Bulletlist.Add(bullet);
                    bullet = new Bullet(xpos + 10, ypos + 0, "player");
                    Bulletlist.Add(bullet);
                    bullet = new Bullet(xpos + 10, ypos + 30, "player");
                    Bulletlist.Add(bullet);
                }
                timer = 0;
            }

            if (Input.GetX() == 1 && bomb == 0 && bombs > 0 &&btimer > 10)
            {
                BS_Spell = new Bullet_Spell(0);
                BS_Spell.SetWave(1);
                bomb = 1;
                bombs--;
            }
            if (bomb == 1)
            {
                rad += 3;
            }
            if (rad > 500)
            {
                bomb = 0;
                rad = 0;
                //BS_Spell = new Bullet_Spell(0);
            }
            Game1.Dan_Data.SetBomb(bomb, rad);
            Game1.Dan_Data.SetData(xpos + 20, ypos + 15);
            Game1.Dan_Data.SetInvun(invintimer);

            healthold = health;
            if (invintimer > 0)
            {
                invintimer--;
                Game1.Dan_Data.SetHit(0);
                
            }
            if (Game1.Dan_Data.GetHit() == 1 && invintimer == 0)
            {
                if (health == 1 && bombs > 0)
                {
                    BS_Spell = new Bullet_Spell(0);
                    BS_Spell.SetWave(1);
                    bomb = 1;
                    bombs--;
                    invintimer = 50;
                }
                else
                {
                    health--;
                    if (health > 0)
                    {
                        positionreset();
                        invintimer = 100;
                    }
                }
                Game1.Dan_Data.SetHit(0);
            }

            if (health <= 0)
            {
               // Game1.dan_reset = 1;
            }
            //power

            if (Game1.Dan_Data.GetEnemyHit() > 0)
            {
                power += Game1.Dan_Data.GetEnemyHit();
                Game1.Dan_Data.ResetEnemyHit();
            }
            

            //bullet stream
            Bulletlist.ForEach(i => i.MoveXpos(8));
            Bulletlist.ForEach(i => i.SetColour(3));
            Bulletlist.ForEach(i => { if (i.GetOffSides() == 1) { Bulletlist.Remove(i); } });

            BS_Spell.SetHealth(health);
            BS_Spell.AddBulletCircle(40, 0, xpos + 20, ypos + 15);
            BS_Spell.SetSize(1);
            BS_Spell.SetRadius(rad);
            BS_Spell.SetOwner("player");
            BS_Spell.SetColour(1);

        }

        public void positionreset()
        {
            xpos = 0;
            ypos = 240;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (bomb == 1)
            {
                BS_Spell.draw(spriteBatch);
            }
            //bullet stream
            Bulletlist.ForEach(i => i.draw(spriteBatch));
            //spriteBatch.DrawString(Game1.Arial, "" + health , new Vector2(50, 23), Color.White);
            //spriteBatch.DrawString(Game1.Arial, "" + bombs , new Vector2(50, 35), Color.White);
            if (health > 0)
            {
                if (Game1.Dan_Data.GetChar() == Danmaku_Character.Moeman)
                {
                    spriteBatch.Draw(Game1.ship, new Vector2(xpos, ypos), Color.White);
                }
                if (Game1.Dan_Data.GetChar() == Danmaku_Character.Gaile)
                {
                    spriteBatch.Draw(Game1.eship, new Vector2(xpos, ypos), new Rectangle(67, 103, 38, 27), Color.White);
                }
            }

            if (invintimer > 0)
            {
               spriteBatch.Draw(Game1.eship, new Vector2(xpos - 15, ypos - 17), new Rectangle(103, 0, 64, 64), Color.White * 0.5f);
            }


            for (int i = 0; i < health; i++){
                spriteBatch.Draw(Game1.Health_Bar, new Vector2(7 + (i*21), 7), new Rectangle(50, 0, 20, 13), Color.White);
            }

            for (int i = 0; i < bombs; i++)
            {
                spriteBatch.Draw(Game1.Health_Bar, new Vector2(7 + (i * 18), 28), new Rectangle(70, 0, 17, 13), Color.White);
            }



            spriteBatch.Draw(Game1.Health_Bar, new Vector2(2, 2), new Rectangle(50, 13, 138, 44), Color.White);


        }


    }
}
