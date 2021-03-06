﻿using System;
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

namespace universe{
    class player
    {


        public int timer;
        int frame = 0;
        int animation = 0;
        int anitimer = 0;
        int aniatacktimer = 0;
        int direction = 1;
        int attacking = 0;
        int runon = 1;
        int character = 1;
        int charchangedw = 0;
        int charchangeup = 0;
        int stamtime;
        int jumping = 0;
        int jumptimer = 0;
        int ground = 1;
        int nxtup;
        int nxtdw;
        int incr = 0;
        int[] nextchar;
        int leftbound;
        int rightbound;
        int bottombound;
        int health = 100;
        int healthold = 100;
        int healthtimer = 0;
        int diatimer = 0;
        int knocktimer = 0;
 
        public int stamina = 100;
        public Vector2 PlayerPos = new Vector2(400, 240);
        public Vector2 PlayerPosOld = new Vector2(400, 240);
        public Vector2 PlayerPosOldOld = new Vector2(400, 240);
        Vector2 staminabar = new Vector2(10, 400);
        Vector2 uipos = new Vector2(0, 0);
        Vector2 uipos2 = new Vector2(18, 18);

        public void playersetup()
        {
            nextchar = new int[14];
            for (int x = 0; x < 14; x++)
            {
                nextchar[x] = 0;
            }
        }



        public void update()
        {
            KeyboardState keyboard = Keyboard.GetState();

            // level start
            if (Game1.playerstart[0] == 1)
            {
                Game1.playerstart[0] = 0;
                leftbound = Game1.playerstart[1];
                rightbound = Game1.playerstart[2];
                bottombound = Game1.playerstart[3];
                PlayerPos.X = Game1.playerstart[4];
                PlayerPos.Y = Game1.playerstart[5];
                character = Game1.playerstart[6];
            }

            if (health > 0)
            {

                //prevent collisoon spazzyness
                if (Game1.playerdata[8] < 0)
                {
                    Game1.playerdata[8] = 0;
                }
                if (Game1.playerdata[9] < 0)
                {
                    Game1.playerdata[9] = 0;
                }
                if (Game1.playerdata[10] < 0)
                {
                    Game1.playerdata[10] = 0;
                }

                // variable stuff
                incr = 0;
                PlayerPosOldOld = PlayerPosOld;
                PlayerPosOld = PlayerPos;
                if (Game1.playerdata[6] == 1)
                {
                    Game1.playerdata[6] = 0;
                }

                //character
                if (character > 12) { character = 1; }
                if (character < 1) { character = 12; }
                // next character
                for (int x = 6; x < 18; x++)
                {
                    if (Game1.playerallowance[x] == 1)
                    {
                        nextchar[incr + 1] = x - 5;
                        incr++;
                    }
                }
                for (int z = 0; z < 14; z++)
                {
                    if (z > incr)
                    {
                        nextchar[z] = 0;
                    }
                }
                for (int y = 0; y < 12; y++)
                {
                    if (nextchar[y] == character)
                    {
                        nxtdw = nextchar[y - 1];
                        nxtup = nextchar[y + 1];
                    }
                }
                if (nxtdw == 0)
                {
                    for (int x = 0; x < 12; x++)
                    {
                        if (nextchar[x] > 0)
                        {
                            nxtdw = nextchar[x];
                        }
                    }
                }
                if (nxtup == 0)
                {
                    nxtup = nextchar[1];
                }

                //health
                healthold = health;
                if (Game1.playerdata[11] > 0)
                {
                    health = health - Game1.playerdata[11];
                    Game1.playerdata[11] = 0;
                    healthtimer = 0;
                }
                else { healthtimer++; }
                if (healthold == health && health < 100 && healthtimer > 50)
                {
                    health++;
                    healthtimer = 0;
                }
                if (health > 100) { health = 100; }
                if (health < 0) { health = 0; }

                //stamina
                stamtime++;
                if (stamtime > 10)
                {
                    stamina++;
                    stamtime = 0;
                }
                if (stamina > 100) { stamina = 100; }
                if (stamina < 0) { stamina = 0; }




                // controls
                if (keyboard.IsKeyDown(Keys.X) && timer > 5)
                {
                    Game1.playerdata[3] = 1;
                }
                else { Game1.playerdata[3] = 0; }
                if (keyboard.IsKeyDown(Keys.Down) && timer > 5 && Game1.playerallowance[2] == 1)
                {
                    if (charchangedw == 0 && attacking == 0)
                    {
                        character = nxtdw;
                        animation = 0;
                        anitimer = 0;
                        aniatacktimer = 0;
                        frame = 0;
                        diatimer = 0;
                    }
                    charchangedw = 1;
                }
                else { charchangedw = 0; }
                if (keyboard.IsKeyDown(Keys.Up) && timer > 5 && Game1.playerallowance[2] == 1)
                {
                    if (charchangeup == 0 && attacking == 0)
                    {
                        character = nxtup;
                        animation = 0;
                        anitimer = 0;
                        aniatacktimer = 0;
                        frame = 0;
                        diatimer = 0;
                    }
                    charchangeup = 1;
                }
                else { charchangeup = 0; }



                if (keyboard.IsKeyDown(Keys.Left) && timer > 5 && attacking == 0 && Game1.playerallowance[0] == 1 && Game1.playerdata[13] == 0)
                {
                    if (Game1.playerdata[8] < 1)
                    {
                        PlayerPos.X = PlayerPos.X - 2 * runon;
                    }
                    animation = -1;
                    direction = -1;
                    if (runon == 2)
                    {
                        stamina -= 2;
                    }
                }
                if (keyboard.IsKeyDown(Keys.Right) && timer > 5 && attacking == 0 && Game1.playerallowance[0] == 1 && Game1.playerdata[13] == 0)
                {
                    if (Game1.playerdata[9] < 1)
                    {
                        PlayerPos.X = PlayerPos.X + 2 * runon;
                    }
                    animation = 1;
                    direction = 1;
                    if (runon == 2)
                    {
                        stamina -= 2;
                    }
                }


                if (keyboard.IsKeyDown(Keys.Z) && timer > 5 && stamina > 15 && Game1.playerallowance[3] == 1 && Game1.playerdata[13] == 0)
                {
                    if (attacking == 0) { stamina -= 15; }
                    attacking = 1;
                }


                if (keyboard.IsKeyDown(Keys.Space) && timer > 5 && jumping == 0 && (ground == 1 || Game1.playerdata[10] == 1) && Game1.playerallowance[1] == 1 && Game1.playerdata[13] == 0)
                {
                    jumping = 1;
                    ground = 0;
                }


                if (keyboard.IsKeyDown(Keys.C) && timer > 5 && stamina > 0 && Game1.playerallowance[4] == 1)
                {
                    if (runon == 1 && stamina > 15) { anitimer = 0; }
                    if (stamina > 15)
                    {
                        runon = 2;
                    }
                    if (stamina < 2)
                    {
                        runon = 1;
                    }
                }
                else { runon = 1; }


                if (keyboard.IsKeyDown(Keys.Right) && keyboard.IsKeyDown(Keys.Left))
                {
                    frame = 0;
                    animation = 0;
                }


                //knockback
                if (Game1.playerdata[13] == 1)
                {
                    knocktimer++;
                    if (direction == 1 && Game1.playerdata[8] == 0)
                    {
                        animation = 1;
                        PlayerPos.X -= 2;
                    }
                    if (direction == -1 && Game1.playerdata[9] == 0)
                    {
                        PlayerPos.X += 2;
                        animation = -1;
                    }
                    if (knocktimer <= 1) { jumping = 1; }
                    if (knocktimer > 30) { knocktimer = 0; Game1.playerdata[13] = 0; }
                }


                // atacking animation
                if (attacking == 1)
                {
                    if (direction == -1)
                    {
                        animation = 2;
                        aniatacktimer++;
                        if (aniatacktimer < 15)
                        {
                            frame = -4;
                        }
                        if (aniatacktimer >= 15)
                        {
                            frame = -5;
                        }
                        if (aniatacktimer > 30)
                        {
                            aniatacktimer = 0;
                            attacking = 0;
                            animation = -1;
                            anitimer = 0;
                            Game1.playerdata[6] = 1;
                        }
                    }
                    if (direction == 1)
                    {
                        animation = 2;
                        aniatacktimer++;
                        if (aniatacktimer < 15)
                        {
                            frame = 4;
                        }
                        if (aniatacktimer >= 15)
                        {
                            frame = 5;
                        }
                        if (aniatacktimer > 30)
                        {
                            aniatacktimer = 0;
                            attacking = 0;
                            animation = 1;
                            anitimer = 0;
                            Game1.playerdata[6] = 1;
                        }
                    }
                }


                // walkign animation
                if (animation == -1)
                {
                    anitimer++;
                    if (anitimer < 15 / runon)
                    {
                        frame = -1;
                    }
                    if (anitimer == 15 / runon && frame == -1)
                    {
                        frame = -2;
                    }
                    if (anitimer == 30 / runon && frame == -2)
                    {
                        frame = -1;
                    }
                    if (anitimer == 45 / runon && frame == -1)
                    {
                        frame = -3;
                    }
                    if (anitimer == 60 / runon && frame == -3)
                    {
                        frame = -1;
                        anitimer = 0;
                    }
                }

                if (animation == 1)
                {
                    anitimer++;
                    if (anitimer < 15 / runon)
                    {
                        frame = 1;
                    }
                    if (anitimer == 15 / runon && frame == 1)
                    {
                        frame = 2;
                    }
                    if (anitimer == 30 / runon && frame == 2)
                    {
                        frame = 1;
                    }
                    if (anitimer == 45 / runon && frame == 1)
                    {
                        frame = 3;
                    }
                    if (anitimer == 60 / runon && frame == 3)
                    {
                        frame = 1;
                        anitimer = 0;
                    }
                }

                if (animation == 0)
                {
                    frame = 0;
                    anitimer = 0;
                }

                

                //jumping
                if (jumping == 1)
                {
                    jumptimer++;
                    if (jumptimer < 24)
                    {
                        PlayerPos.Y -= 3;
                    }
                    else { jumping = 0; jumptimer = 0; }
                }
                else
                {
                    if (Game1.playerdata[10] == 0)
                    {
                        PlayerPos.Y += 4;
                    }
                }



                //boundary
                if (PlayerPos.Y > bottombound - 73)
                {
                    PlayerPos.Y = bottombound - 73;
                    ground = 1;
                }
                if (PlayerPos.X > rightbound - 50)
                {
                    PlayerPos.X = rightbound - 50;
                }
                if (PlayerPos.X < leftbound - 30)
                {
                    PlayerPos.X = leftbound - 30;
                }

                animation = 0;
                timer++;

                //variable
                Game1.playerdata[0] = (int)PlayerPos.X;
                Game1.playerdata[1] = (int)PlayerPos.Y;
                Game1.playerdata[2] = character;
                Game1.playerdata[4] = jumping;
                Game1.playerdata[5] = runon;
                Game1.playerdata[7] = direction;
                Game1.playerdata[12] = health;

                Game1.playerstart[6] = character;
            }

            if (health < 1)
            {
                Game1.reset = 1;
            }

        }


        public void playerdraw(SpriteBatch spriteBatch)
        {

            
            // animation
            if (frame == 0)
            {
                spriteBatch.Draw(Game1.spritesheet, PlayerPos, new Rectangle(0, character * 80 - 80, 80, 80), Color.White);
            }
            if (frame == -1)
            {
                spriteBatch.Draw(Game1.spritesheet, PlayerPos, new Rectangle(80, character * 80 - 80, 80, 80), Color.White);
            }
            if (frame == -2)
            {
                spriteBatch.Draw(Game1.spritesheet, PlayerPos, new Rectangle(160, character * 80 - 80, 80, 80), Color.White);
            }
            if (frame == -3)
            {
                spriteBatch.Draw(Game1.spritesheet, PlayerPos, new Rectangle(240, character * 80 - 80, 80, 80), Color.White);
            }

            if (frame == 3)
            {
                spriteBatch.Draw(Game1.spritesheet, PlayerPos, new Rectangle(640, character * 80 - 80, 80, 80), Color.White);
            }
            if (frame == 2)
            {
                spriteBatch.Draw(Game1.spritesheet, PlayerPos, new Rectangle(720, character * 80 - 80, 80, 80), Color.White);
            }
            if (frame == 1)
            {
                spriteBatch.Draw(Game1.spritesheet, PlayerPos, new Rectangle(800, character * 80 - 80, 80, 80), Color.White);
            }


            if (frame == -4)
            {
                spriteBatch.Draw(Game1.spritesheet, PlayerPos, new Rectangle(320, character * 80 - 80, 80, 80), Color.White);
            }
            if (frame == -5)
            {
                spriteBatch.Draw(Game1.spritesheet, PlayerPos, new Rectangle(400, character * 80 - 80, 80, 80), Color.White);
            }
            if (frame == 4)
            {
                spriteBatch.Draw(Game1.spritesheet, PlayerPos, new Rectangle(560, character * 80 - 80, 80, 80), Color.White);
            }
            if (frame == 5)
            {
                spriteBatch.Draw(Game1.spritesheet, PlayerPos, new Rectangle(480, character * 80 - 80, 80, 80), Color.White);
            }  


        }

        public void playeruidraw(SpriteBatch spriteBatch)
        {


            //ui
            spriteBatch.Draw(Game1.ui, uipos, Color.White);
            spriteBatch.Draw(Game1.spritesheet, uipos2, new Rectangle(0, character * 80 - 80, 80, 80), Color.White);
            // ui info
            if (Game1.playerallowance[18] == 1)
            {
                spriteBatch.DrawString(Game1.Arial, "Stamina: " + stamina, new Vector2(120, 38), Color.White);
            }
            if (Game1.playerallowance[19] == 1)
            {
                spriteBatch.DrawString(Game1.Arial, "Health: " + health, new Vector2(115, 23), Color.White);
            }

            diatimer++;
            if (Game1.dialogueplay == 0 & diatimer < 100)
            {
                Dialogue.charentrance(spriteBatch, character);
            }

            //character name
            if (character == 1)
            {
                spriteBatch.DrawString(Game1.Arial, "Moeman \"The White Knight\" ", new Vector2(100, 5), Color.White);
            }
            if (character == 2)
            {
                spriteBatch.DrawString(Game1.Arial, "Eloise \"Child of earth\" ", new Vector2(100, 5), Color.White);
            }
            if (character == 3)
            {
                spriteBatch.DrawString(Game1.Arial, "Cirno \"of the Lighting Blade\" ", new Vector2(100, 5), Color.White);
            }
            if (character == 4)
            {
                spriteBatch.DrawString(Game1.Arial, "Cyria \"The Lore Walker\" ", new Vector2(100, 5), Color.White);
            }
            if (character == 5)
            {
                spriteBatch.DrawString(Game1.Arial, "Michael \"The Human Ape\" ", new Vector2(100, 5), Color.White);
            }
            if (character == 6)
            {
                spriteBatch.DrawString(Game1.Arial, "Gerbs \"Lil' Sapling\" ", new Vector2(100, 5), Color.White);
            }
            if (character == 7)
            {
                spriteBatch.DrawString(Game1.Arial, "Gaile \"The Gear Grinder\" ", new Vector2(100, 5), Color.White);
            }
            if (character == 8)
            {
                spriteBatch.DrawString(Game1.Arial, "Simon \"Heavens Puppet\" ", new Vector2(100, 5), Color.White);
            }
            if (character == 9)
            {
                spriteBatch.DrawString(Game1.Arial, "Kagami V3.0 \"The Illusion\" ", new Vector2(100, 5), Color.White);
            }
            if (character == 10)
            {
                spriteBatch.DrawString(Game1.Arial, "TBA \"The Unannounced\" ", new Vector2(100, 5), Color.White);
            }
            if (character == 11)
            {
                spriteBatch.DrawString(Game1.Arial, "TBA Prime \"of the Unexisted\" ", new Vector2(100, 5), Color.White);
            }
            if (character == 12)
            {
                spriteBatch.DrawString(Game1.Arial, "Elizabeth \"The Holy Light\" ", new Vector2(100, 5), Color.White);
            }


        }

        public void playerreset()
        {
            stamina = 100;
            health = 100;
            frame = 0;
            Game1.playerdata[13] = 0;
            Game1.playerdata[11] = 0;
        }
    }

}
