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
    class LvSelectButton
    {
        int xpos;
        int ypos;
        int timer;
        int highlighted;
        int which;
        String Name;
        int type;
        int number;

        public LvSelectButton(int x, int y, int whic, String Nam, int typ, int numb)
        {
            
            xpos = x;
            ypos = y;
            which = whic;
            Name = Nam;
            type = typ;
            number = numb;

        }

        public void update(int mousex,int mousey, int mouseleft)
        {

            if (mousex > xpos - 30 && mousex < xpos + 30 && mousey > ypos - 30 && mousey < ypos + 30)
            {
                 timer++;
                 highlighted = 1;
            }
            else { timer = 0; highlighted = 0; }


            if (highlighted == 1 && mouseleft > 0)
            {
                if (type == 1)
                {
                    Game1.gamestate = 2;
                    Game1.storysection = number;
                }
                if (type == 2)
                {
                    Game1.gamestate = 2;
                    Game1.level = number;
                }
                if (type == 3)
                {
                    Game1.gamestate = 2;
                    Game1.boss = number;
                }
                Game1.dan_reset = 1;
                Game1.reset = 1;
            }


        }

        public void ChangeYpos(int number)
        {
            ypos += number;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (timer < 20)
            {
                spriteBatch.Draw(Game1.lvselect, new Vector2(xpos - 30, ypos - 30), new Rectangle(0, 0, 60, 60), Color.White);
            }
            if (timer >= 20)
            {
                spriteBatch.Draw(Game1.lvselect, new Vector2(xpos - 30, ypos - 30), new Rectangle(60, 0, 60, 60), Color.White);
            }
            if (timer >= 40)
            {
                timer = 0;
            }

            if (which == 1)
            {
                spriteBatch.Draw(Game1.lvselect, new Vector2(xpos - 30, ypos - 30), new Rectangle(0, 60, 60, 60), Color.White);
            }
            if (which == 2)
            {
                spriteBatch.Draw(Game1.lvselect, new Vector2(xpos - 30, ypos - 30), new Rectangle(60, 60, 60, 60), Color.White);
            }
            if (which == 3)
            {
                spriteBatch.Draw(Game1.lvselect, new Vector2(xpos - 30, ypos - 30), new Rectangle(120, 60, 60, 60), Color.White);
            }

            if (highlighted == 1)
            {
                spriteBatch.DrawString(Game1.Nasa, Name, new Vector2(xpos - (Name.Length*10)/2, ypos + 30), Color.Red);

            }

        }

    }
}
