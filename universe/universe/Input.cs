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
    static class Input
    {

        public static int GetEnter()
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Enter))
            {
                return 1;
            }
            else { return 0; }
        }

        public static int GetZ()
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Z))
            {
                return 1;
            }
            else { return 0; }
        }

        public static int GetSpace()
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Space))
            {
                return 1;
            }
            else { return 0; }
        }

        public static int GetX()
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.X))
            {
                return 1;
            }
            else { return 0; }
        }

        public static int GetC()
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.C))
            {
                return 1;
            }
            else { return 0; }
        }

        public static int GetUp()
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Up))
            {
                return 1;
            }
            else { return 0; }
        }

        public static int GetDown()
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Down))
            {
                return 1;
            }
            else { return 0; }
        }

        public static int GetLeft()
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Left))
            {
                return 1;
            }
            else { return 0; }
        }

        public static int GetRight()
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Right))
            {
                return 1;
            }
            else { return 0; }
        }

        public static int GetEsc()
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Escape))
            {
                return 1;
            }
            else { return 0; }
        }

    }
}
