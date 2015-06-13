using System;
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

namespace universe
{
    class Effect
    {


        int timer;

        public Effect()
        {

        }



        public void draw(int x, int y, SpriteBatch spriteBatch, int effecttype)
        {
            timer++;

            if (timer < 5)
            {
                if (effecttype == 1)
                {
                    spriteBatch.Draw(Game1.sexplo, new Vector2(x, y), new Rectangle(0, 0, 28, 28), Color.White);
                }
                if (effecttype == 2)
                {
                    spriteBatch.Draw(Game1.mexplo, new Vector2(x, y), new Rectangle(0, 0, 70, 70), Color.White);
                }
                if (effecttype == 3)
                {
                    spriteBatch.Draw(Game1.ssmoke, new Vector2(x, y), new Rectangle(0, 0, 28, 28), Color.White);
                }
            }
            if (timer < 10 && timer >= 5)
            {
                if (effecttype == 1)
                {
                    spriteBatch.Draw(Game1.sexplo, new Vector2(x, y), new Rectangle(28, 0, 28, 28), Color.White);
                }
                if (effecttype == 2)
                {
                    spriteBatch.Draw(Game1.mexplo, new Vector2(x, y), new Rectangle(70, 0, 70, 70), Color.White);
                }
                if (effecttype == 3)
                {
                    spriteBatch.Draw(Game1.ssmoke, new Vector2(x, y), new Rectangle(28, 0, 28, 28), Color.White);
                }
            }
            if (timer < 15 && timer >= 10)
            {
                if (effecttype == 2)
                {
                    spriteBatch.Draw(Game1.mexplo, new Vector2(x, y), new Rectangle(140, 0, 70, 70), Color.White);
                }
            }
        }

        public void draw(int x, int y, SpriteBatch spriteBatch, int effecttype, int width, int height)
        {
            timer++;

            if (timer < 5)
            {
                if (effecttype == 1)
                {
                    spriteBatch.Draw(Game1.sexplo, new Vector2(x + width/2 - 14, y + height/2 - 14), new Rectangle(0, 0, 28, 28), Color.White);
                }
                if (effecttype == 2)
                {
                    spriteBatch.Draw(Game1.mexplo, new Vector2(x + width / 2 - 35, y + height / 2 - 35), new Rectangle(0, 0, 70, 70), Color.White);
                }
                if (effecttype == 3)
                {
                    spriteBatch.Draw(Game1.ssmoke, new Vector2(x + width / 2 - 14, y + height / 2 - 14), new Rectangle(0, 0, 28, 28), Color.White);
                }
            }
            if (timer < 10 && timer >= 5)
            {
                if (effecttype == 1)
                {
                    spriteBatch.Draw(Game1.sexplo, new Vector2(x + width / 2 - 14, y + height / 2 - 14), new Rectangle(28, 0, 28, 28), Color.White);
                }
                if (effecttype == 2)
                {
                    spriteBatch.Draw(Game1.mexplo, new Vector2(x + width/2 - 35, y + height/2 - 35), new Rectangle(70, 0, 70, 70), Color.White);
                }
                if (effecttype == 3)
                {
                    spriteBatch.Draw(Game1.ssmoke, new Vector2(x + width / 2 - 14, y + height / 2 - 14), new Rectangle(28, 0, 28, 28), Color.White);
                }
            }
            if (timer < 15 && timer >= 10)
            {
                if (effecttype == 2)
                {
                    spriteBatch.Draw(Game1.mexplo, new Vector2(x + width/2 - 35, y + height/2 - 35), new Rectangle(140, 0, 70, 70), Color.White);
                }
            }
        }

        public void SetTimer(int number)
        {
            timer = number;
        }

    }
}
