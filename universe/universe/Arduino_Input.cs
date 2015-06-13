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
using System.IO.Ports;

namespace universe
{
    static class Arduino_Input
    {

        static SerialPort port = new SerialPort("COM5", 9600);
        static byte[] ard_input = new byte[12];
        static int opened = 0;
        static string ard_string;
        static int timer;
        static int offset;



        public static void Update()
        {
            timer++;

            if (opened == 0)
            {
                port.Open();
                port.WriteLine("1");
                opened = 1;
            }

           // if (ard_input[9] > 0)
            //{
                
           // }

            if (port.BytesToRead > 9)
            {
                port.Read(ard_input, offset, 10);
            }
                //port.WriteLine("1");


            
           
            
           // ard_string = port.ReadLine();

            //port.Close();

        }



        public static int Get_A()
        {
            return ard_input[1] - 48;
        }

        public static int Get_B()
        {
            return (int)ard_input[0] - 48;
        }

        public static int Get_Right()
        {
            return (int)ard_input[2] - 48;
        }

        public static int Get_Down()
        {
            return (int)ard_input[3] - 48;
        }

        public static int Get_Left()
        {
            return (int)ard_input[4] - 48;
        }

        public static int Get_Up()
        {
            return ard_input[5] - 48;
        }

        public static int Get_Tilt()
        {
            return ard_input[6] - 48;
        }

        public static int Get_Light()
        {
            return ard_input[7] - 48;
        }

        public static int Get_LeftTrig()
        {
            return ard_input[9] - 48;
        }

        public static int Get_RightTrig()
        {
            return ard_input[8] - 48;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (timer > 25)
            {
                //spriteBatch.DrawString(Game1.Nasa, " " + ard_string, new Vector2(150, 10), Color.White);
                spriteBatch.DrawString(Game1.Nasa, " " + Get_B(), new Vector2(150, 20), Color.White);
                spriteBatch.DrawString(Game1.Nasa, " " + Get_A(), new Vector2(150, 35), Color.White);
                spriteBatch.DrawString(Game1.Nasa, " " + Get_Right(), new Vector2(150, 50), Color.White);
                spriteBatch.DrawString(Game1.Nasa, " " + Get_Down(), new Vector2(150, 65), Color.White);
                spriteBatch.DrawString(Game1.Nasa, " " + Get_Up(), new Vector2(150, 80), Color.White);
                spriteBatch.DrawString(Game1.Nasa, " " + Get_Left(), new Vector2(150, 95), Color.White);
                spriteBatch.DrawString(Game1.Nasa, " " + Get_Tilt(), new Vector2(150, 110), Color.White);
                spriteBatch.DrawString(Game1.Nasa, " " + Get_Light(), new Vector2(150, 125), Color.White);
                spriteBatch.DrawString(Game1.Nasa, " " + Get_RightTrig(), new Vector2(150, 140), Color.White);
                spriteBatch.DrawString(Game1.Nasa, " " + Get_LeftTrig(), new Vector2(150, 155), Color.White);
            }
        }

    }
}
