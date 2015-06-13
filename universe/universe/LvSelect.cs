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
    class LvSelect
    {

        List<LvSelectButton> Buttonlist = new List<LvSelectButton>();

        public LvSelect()
        {
            LvSelectButton button = new LvSelectButton(427, 50, 3, "Devastating Beginnings", 1, 1);
            Buttonlist.Add(button);
            button = new LvSelectButton(427, 130, 3, "The Chase", 1, 2);
            Buttonlist.Add(button);
            button = new LvSelectButton(366, 130, 1, "Welcome Aboard", 2, 1);
            Buttonlist.Add(button);
            button = new LvSelectButton(366, 210, 1, "Bunny Bar", 2, 2);
            Buttonlist.Add(button);
            button = new LvSelectButton(488, 290, 2, "C's Assault", 3, 1);
            Buttonlist.Add(button);

            button = new LvSelectButton(671, 130, 2, "Gallant Defense", 3, 2);
            Buttonlist.Add(button);

        }


        public void update(int mousex, int mousey, int mouseleft)
        {

            Buttonlist.ForEach(i => i.update(mousex, mousey, mouseleft));

        }


        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game1.black, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(Game1.lvsel, new Vector2(0, 0), new Rectangle(0, 0, 800, 20), Color.White);
            for (int i = 20; i < 480; i += 20)
            {
                spriteBatch.Draw(Game1.lvsel, new Vector2(0, i), new Rectangle(0, 20, 800, 20), Color.White);
            }
            Buttonlist.ForEach(i => i.draw(spriteBatch));

        }

    }
}
