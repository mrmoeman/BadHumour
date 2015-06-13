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
    class Interactive_Object
    {
        int xpos;
        int ypos;
        int state;
        int timer;
        int x1;
        int x2;
        int y1;
        int y2;
        int exx;
        int exy;
        int width;
        int height;
        int refnum;
        int ani;
        int activated;
        int Layer;
        public Interactive_Object(int x, int y, int stat, int xx1, int yy1, int xx2, int yy2, int widt, int heigh, int refn, int extrax, int extray, int layer)
        {
            xpos = x;
            ypos = y;
            x1 = xx1;
            x2 = xx2;
            y1 = yy1;
            y2 = yy2;
            exx = extrax;
            exy = extray;
            width = widt;
            height = heigh;
            state = stat;
            refnum = refn;
            Layer = layer;
        }

        public void update()
        {
            if (state > 0)
            {
                timer++;
            }
            if (timer < 50)
            {
                ani = 0;
            }
            if (timer >= 50 && timer < 100)
            {
                ani = 1;
            }
            if (timer >= 100)
            {
                timer = 0;
            }

            if (440 > Platform_Data.GetOffsetX() + xpos + 400 && 440 < Platform_Data.GetOffsetX() + xpos + width + 400 && 280 > Platform_Data.GetOffsetY() + ypos + 240 && 280 < Platform_Data.GetOffsetY() + ypos + height + 240 && Platform_Data.playerdata[3] == 1)
            {
                activated = 1;
            }

        }

        public void SetState(int number)
        {
            state = number;
        }

        public bool CheckRef(int number)
        {
            if (number == refnum)
            {
                return true;
            }
            else return false;
        }

        public bool GetActivated()
        {
            if (Platform_Data.playerdata[3] == 0 && activated == 1)
            {
                activated = 0;
                return true;
            }
             return false;
        }

        public int GetLayer()
        {
            return Layer;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            
                spriteBatch.Draw(Game1.Int_Object, new Vector2(xpos + 400 + Platform_Data.GetOffsetX() + exx,exy + ypos + 240 + Platform_Data.GetOffsetY()), new Rectangle(x1, y1, width, height), Color.White);
            
            if (ani == 1 && state == 1)
            {
                spriteBatch.Draw(Game1.Int_Object, new Vector2(xpos + 400 + Platform_Data.GetOffsetX(), ypos + 240 + Platform_Data.GetOffsetY()), new Rectangle(x2, y2, width, height), Color.White * 0.4f);
            }
        }

    }



    class I_Obj_Console : Interactive_Object
    {
        public I_Obj_Console(int x, int y, int state, int refnum)
            : base(x, y, state, 81, 1, 81, 76, 55, 63, refnum, 0, 0, 0)
        {
        }
    }

    class I_Obj_Console_B : Interactive_Object
    {
        public I_Obj_Console_B(int x, int y, int state, int refnum)
            : base(x, y, state, 155, 4, 155, 79, 28, 59, refnum, 0, 0, 0)
        {
        }
    }

    class I_Obj_Bar : Interactive_Object
    {
        public I_Obj_Bar(int x, int y, int layer)
            : base(x, y, 0, 0, 174, 0, 0, 164, 56, 0, 0, 0, layer)
        {
        }
    }

}
