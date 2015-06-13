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
    class NPC
    {
        int xpos;
        int ypos;
        int character;
        int direction;
        String dialogue;
        int timer;
        int Layer;
        int ShowDialogue;
        int DiaTimer;

        //charcaters
        // 1 - bunny

        public NPC(int x, int y, int chara, int dir, String dia, int layer)
        {
            xpos = x;
            ypos = y;
            character = chara;
            direction = dir;
            dialogue = dia;
            Layer = layer;
        }

        public void update()
        {
            timer++;

            if (Platform_Data.playerdata[3] == 1)
            {
                if (xpos + 400 + Platform_Data.GetOffsetX() > 420 && xpos + 400 + Platform_Data.GetOffsetX() < 460)
                {
                    if (ypos + 240 + Platform_Data.GetOffsetY() > 100 && ypos + 240 + Platform_Data.GetOffsetY() < 380)
                    {
                        ShowDialogue = 1;
                    }
                }
            }
            if (ShowDialogue == 1)
            {
                DiaTimer++;
            }
            if (DiaTimer > 100)
            {
                ShowDialogue = 0;
                DiaTimer = 0;
            }
            
        }

        public int GetDialogue()
        {
            return ShowDialogue;
        }

        public int GetLayer()
        {
            return Layer;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            
            //which character
                if (character == 1) // bunny
                {
                    if (direction == 1) // right
                    {
                        if (timer < 20)
                        {
                            spriteBatch.Draw(Game1.npc, new Vector2(xpos + 400 + Platform_Data.GetOffsetX() - 40, ypos - 80 + 240 + Platform_Data.GetOffsetY()), new Rectangle(240, 0, 80, 80), Color.White);
                        }
                        if (timer >= 20 && timer <= 35)
                        {
                            spriteBatch.Draw(Game1.npc, new Vector2(xpos + 400 + Platform_Data.GetOffsetX() - 40, ypos - 80 + 240 + Platform_Data.GetOffsetY()), new Rectangle(160, 0, 80, 80), Color.White);
                        }
                    }

                    if (direction == -1) // left
                    {
                        if (timer < 20)
                        {
                            spriteBatch.Draw(Game1.npc, new Vector2(xpos + 400 + Platform_Data.GetOffsetX() - 40, ypos - 80 + 240 + Platform_Data.GetOffsetY()), new Rectangle(0, 0, 80, 80), Color.White);
                        }
                        if (timer >= 20 && timer <= 35)
                        {
                            spriteBatch.Draw(Game1.npc, new Vector2(xpos + 400 + Platform_Data.GetOffsetX() - 40, ypos - 80 + 240 + Platform_Data.GetOffsetY()), new Rectangle(80, 0, 80, 80), Color.White);
                        }
                    }

                    if (direction == 0) // forward
                    {
                        spriteBatch.Draw(Game1.npc, new Vector2(xpos - 40 + 400 + Platform_Data.GetOffsetX(), ypos - 80 + 240 + Platform_Data.GetOffsetY()), new Rectangle(320, 0, 80, 80), Color.White);
                    }

                    if (timer >= 35)
                    {
                        timer = 0;
                    }
                }

                if (character == 2) // soldier - no helm
                {
                        spriteBatch.Draw(Game1.npc, new Vector2(xpos - 40 + 400 + Platform_Data.GetOffsetX(), ypos - 80 + 240 + Platform_Data.GetOffsetY()), new Rectangle(400, 0, 80, 80), Color.White);
                }


                if (character == 3) // soldier -  helm
                {
                        spriteBatch.Draw(Game1.npc, new Vector2(xpos - 40 + 400 + Platform_Data.GetOffsetX(), ypos - 80 + 240 + Platform_Data.GetOffsetY()), new Rectangle(480, 0, 80, 80), Color.White);
                }
        }

        public void Dialogue(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Game1.Arial_12, dialogue, new Vector2(xpos - 20 + 400 + Platform_Data.GetOffsetX() - dialogue.Length/2, ypos - 100 + 240 + Platform_Data.GetOffsetY()), Color.White);

        }


    }
}
