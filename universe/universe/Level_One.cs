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
    class Level_One : Platform_Level
    {
        public Level_One() : base(){
            Platform_Data.SetOffsetX(-607);
            Platform_Data.SetOffsetY(-600);

            Platform_Data.playerallowance[6] = 1;
            Platform_Data.playerallowance[7] = 0;
            Platform_Data.playerallowance[8] = 1;
            Platform_Data.playerallowance[9] = 0;
            Platform_Data.playerallowance[10] = 0;
            Platform_Data.playerallowance[11] = 0;
            Platform_Data.playerallowance[12] = 0;
            Platform_Data.playerallowance[13] = 0;
            Platform_Data.playerallowance[14] = 1;
            Platform_Data.playerallowance[15] = 0;
            Platform_Data.playerallowance[16] = 0;
            Platform_Data.playerallowance[17] = 0;

            AddCollisionBox(415, 697, 3002, 10);
            AddCollisionBox(373, 456, 45, 311);
            AddCollisionBox(3389, 550, 45, 458);
            AddCollisionBox(2200, 545, 601, 34);
            AddCollisionBox(810, 579, 315, 13);
            AddCollisionBox(1519, 568, 167, 11);
            AddCollisionBox(2198, 427, 24, 117);
            AddCollisionBox(2198, 426, 222, 15);
            AddCollisionBox(2756, 382, 43, 166);

            AddDoor(2229, 474, 1, 101);
            AddDoor(2229, 627, 1, 102);

            AddConsoleA(465, 635, 1, 103);


            AddConsoleB(700, 648, 1, 104);

        }


        public override void update()
        {
            base.update();

            if (CheckIObj(101) == 1)
            {
                Platform_Data.IncrOffsetY(-150);
            }
            if (CheckIObj(102) == 1)
            {
                Platform_Data.IncrOffsetY(154);
            }


        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            //base.Draw(spriteBatch);
            spriteBatch.Draw(Game1.black, new Vector2(0,0), Color.White);
            spriteBatch.Draw(Game1.Level_One_Back, new Vector2(Platform_Data.GetOffsetX()+400, Platform_Data.GetOffsetY()+240), Color.White);
            base.DrawBackground(spriteBatch);
            spriteBatch.Draw(Game1.Level_One_Mid, new Vector2(Platform_Data.GetOffsetX()+400, Platform_Data.GetOffsetY()+240), Color.White);
            base.DrawMidground(spriteBatch);
            spriteBatch.Draw(Game1.Level_One_Fore, new Vector2(Platform_Data.GetOffsetX()+400, Platform_Data.GetOffsetY()+240), Color.White);
            base.DrawForeground(spriteBatch);

            //spriteBatch.DrawString(Game1.Arial, "" + Platform_Data.GetOffsetX(), new Vector2(250, 30), Color.White);
            //spriteBatch.DrawString(Game1.Arial, "" + Platform_Data.GetOffsetY(), new Vector2(250, 50), Color.White);
        }

    }
}
