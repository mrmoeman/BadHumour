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
    class Prompt
    {
        int timer;
        int xpos;
        int ypos;
        int areareq;
        public Prompt(int x, int y, int areare){
            xpos = x;
            ypos = y;
            areareq = areare;
        }

        public void draw(SpriteBatch spriteBatch,int area)
        {
            if (area == areareq)
            {
                timer++;
                if (timer < 15)
                {
                    spriteBatch.Draw(Game1.xpress, new Vector2(xpos - 20, ypos - 20), new Rectangle(0, 0, 30, 30), Color.White);
                }
                else
                {
                    spriteBatch.Draw(Game1.xpress, new Vector2(xpos - 20, ypos - 20), new Rectangle(30, 0, 30, 30), Color.White);
                }
                if (timer > 30) { timer = 0; }
            }

        }

    }
}
