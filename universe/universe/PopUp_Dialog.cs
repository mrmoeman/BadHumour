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
    public static class PopUp_Dialog
    {

        static String Name;
        static int timer;

        private static void WhichChar(int CharNumber)
        {
            if (CharNumber == 1)
            {
                Name = "Admiral Cirno";
            }
            if (CharNumber == 2)
            {
                Name = "Moeman";
            }
            if (CharNumber == 3)
            {
                Name = "Eloise";
            }
            if (CharNumber == 4)
            {
                Name = "Kagami V2.0";
            }

            if (CharNumber == 9)
            {
                Name = "Captain Gaile";
            }

            if (CharNumber == 10)
            {
                Name = "Simon";
            }
        }

        public static void draw(SpriteBatch spriteBatch, String line1, String line2, String line3, int leftchar, int Lemotion, int rightchar, int Remotion, int which)
        {
            timer++;

            if (timer >= 100)
            {
                timer = 0;
            }

            //spriteBatch.Draw(Game1.dialogue, new Vector2(0, 380), Color.White);
            if (leftchar > 0 && Lemotion > 0)
            {
                spriteBatch.Draw(Game1.chardialog, new Vector2(10, 348), new Rectangle (Lemotion * 120 - 120,leftchar * 120 - 120, 120, 120), Color.White);
                if (which == 1)
                {
                    spriteBatch.Draw(Game1.chardialogbox, new Vector2(2, 340), new Rectangle(0 ,0, 350, 140), Color.White);
                    spriteBatch.DrawString(Game1.Arial_12, line1, new Vector2(135, 415), Color.White);
                    spriteBatch.DrawString(Game1.Arial_12, line2, new Vector2(135, 428), Color.White);
                    spriteBatch.DrawString(Game1.Arial_12, line3, new Vector2(135, 441), Color.White);
                    WhichChar(leftchar);
                    spriteBatch.DrawString(Game1.Arial_12, Name, new Vector2(143, 456), Color.White);
                    if (timer < 20)
                    {
                        spriteBatch.Draw(Game1.chardialogbox, new Vector2(249, 459), new Rectangle(529, 30, 11, 10), Color.White);
                    }
                    if (timer >= 20 && timer < 40)
                    {
                        spriteBatch.Draw(Game1.chardialogbox, new Vector2(249, 459), new Rectangle(529, 20, 11, 10), Color.White);
                    }
                    if (timer >= 40 && timer < 60)
                    {
                        spriteBatch.Draw(Game1.chardialogbox, new Vector2(249, 459), new Rectangle(529, 10, 11, 10), Color.White);
                    }
                    if (timer >= 60 && timer < 80)
                    {
                        spriteBatch.Draw(Game1.chardialogbox, new Vector2(249, 459), new Rectangle(529, 0, 11, 10), Color.White);
                    }

                }
                else
                {
                    spriteBatch.Draw(Game1.chardialogbox, new Vector2(2, 340), new Rectangle(360, 0, 150, 140), Color.White);
                }
            }

            if (rightchar > 0 && Remotion > 0)
            {
                spriteBatch.Draw(Game1.chardialog, new Vector2(671, 348), new Rectangle(Remotion * 120 - 120, rightchar * 120 - 120, 120, 120), Color.White);
                if (which == 2)
                {
                    spriteBatch.Draw(Game1.chardialogbox, new Vector2(800 - 350, 340), new Rectangle(0, 140, 350, 140), Color.White);
                    spriteBatch.DrawString(Game1.Arial_12, line1, new Vector2(460, 415), Color.White);
                    spriteBatch.DrawString(Game1.Arial_12, line2, new Vector2(460, 430), Color.White);
                    spriteBatch.DrawString(Game1.Arial_12, line3, new Vector2(460, 441), Color.White);
                    WhichChar(rightchar);
                    spriteBatch.DrawString(Game1.Arial_12, Name, new Vector2(557, 456), Color.White);
                    if (timer < 20)
                    {
                        spriteBatch.Draw(Game1.chardialogbox, new Vector2(541, 459), new Rectangle(517, 30, 11, 10), Color.White);
                    }
                    if (timer >= 20 && timer < 40)
                    {
                        spriteBatch.Draw(Game1.chardialogbox, new Vector2(541, 459), new Rectangle(517, 20, 11, 10), Color.White);
                    }
                    if (timer >= 40 && timer < 60)
                    {
                        spriteBatch.Draw(Game1.chardialogbox, new Vector2(541, 459), new Rectangle(517, 10, 11, 10), Color.White);
                    }
                    if (timer >= 60 && timer < 80)
                    {
                        spriteBatch.Draw(Game1.chardialogbox, new Vector2(541, 459), new Rectangle(517, 0, 11, 10), Color.White);
                    }
                }
                else
                {
                    spriteBatch.Draw(Game1.chardialogbox, new Vector2(800 - 141, 340), new Rectangle(360, 140, 150, 140), Color.White);
                }
            }


        }

    }
}
