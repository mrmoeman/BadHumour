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
    class Level_Two : Platform_Level
    {
        public Level_Two()
            : base()
        {
            Platform_Data.SetOffsetX(-1261);
            Platform_Data.SetOffsetY(-2140);

            Platform_Data.playerallowance[6] = 1;
            Platform_Data.playerallowance[7] = 1;
            Platform_Data.playerallowance[8] = 1;
            Platform_Data.playerallowance[9] = 0;
            Platform_Data.playerallowance[10] = 1;
            Platform_Data.playerallowance[11] = 1;
            Platform_Data.playerallowance[12] = 0;
            Platform_Data.playerallowance[13] = 0;
            Platform_Data.playerallowance[14] = 1;
            Platform_Data.playerallowance[15] = 0;
            Platform_Data.playerallowance[16] = 0;
            Platform_Data.playerallowance[17] = 0;


            AddCollisionBox(0, 2269, 4000, 50);
            AddCollisionBox(894, 2026, 10, 259);
            AddCollisionBox(894, 2025, 539, 12);
            AddCollisionBox(1422, 2027, 11, 140);
            AddCollisionBox(1423, 2158, 172, 17);
            AddCollisionBox(1585, 1554, 12, 611);
            AddCollisionBox(1585, 1552, 795, 9);
            //AddCollisionBox(2369, 1549, 13, 727);

            AddBar(1078, 2220, 0);

            AddNPC(1156, 2268, 1, 0, "blargh", 0);
            AddNPC(953, 2268, 1, 1, "blargh", 1);

            AddAcidRain(1);

            AddObject(1, 1460, 2228, 0);
            AddObject(1, 1500, 2228, 0);
            AddObject(1, 1540, 2228, 0);
            AddObject(1, 1580, 2228, 0);

        }


        public override void update()
        {
            base.update();


        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            //base.Draw(spriteBatch);
            spriteBatch.Draw(Game1.black, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(Game1.Level_Two_Back, new Vector2(Platform_Data.GetOffsetX() + 400, Platform_Data.GetOffsetY() + 240), Color.White);
            base.DrawBackground(spriteBatch);
            spriteBatch.Draw(Game1.Level_Two_Mid, new Vector2(Platform_Data.GetOffsetX() + 400, Platform_Data.GetOffsetY() + 240), Color.White);
            base.DrawMidground(spriteBatch);
            spriteBatch.Draw(Game1.Level_Two_Fore, new Vector2(Platform_Data.GetOffsetX() + 400, Platform_Data.GetOffsetY() + 240), Color.White);
            base.DrawForeground(spriteBatch);

            //spriteBatch.DrawString(Game1.Arial, "" + Platform_Data.GetOffsetX(), new Vector2(250, 30), Color.White);
            //spriteBatch.DrawString(Game1.Arial, "" + Platform_Data.GetOffsetY(), new Vector2(250, 50), Color.White);
        }

    }
}
