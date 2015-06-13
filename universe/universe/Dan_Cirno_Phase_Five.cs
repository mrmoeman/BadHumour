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
    class Dan_Cirno_Phase_Five : Danmaku_Enemy
    {

        int anitimer;
        public Dan_Cirno_Phase_Five()
            : base((int)Game1.Dan_Data.GetTempX(), (int)Game1.Dan_Data.GetTempY(), 2, 4000, 67, 44)
        {

        }

        public override void update()
        {
            base.update();

            Invincible();

        }

        public override void drawship(SpriteBatch spriteBatch)
        {


            anitimer++;
            if (anitimer < 10)
            {
                base.draw(spriteBatch, 169, 0);
            }
            if (anitimer >= 10 && anitimer < 20)
            {
                base.draw(spriteBatch, 169, 44);
            }
            if (anitimer == 19)
            {
                anitimer = 0;
            }
        }

    }
}
