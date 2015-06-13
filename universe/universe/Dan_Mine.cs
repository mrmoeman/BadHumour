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
    class Dan_Mine : Danmaku_Enemy
    {
        int waves;
        Bullet_Spell Blast;
        Random rnd = new Random();

        public Dan_Mine(float speed, int heal)
            : base(800, 240, speed, heal, 20, 20)
        {
            Blast = new Bullet_Spell(0);
            SetYpos(0 + rnd.Next(0, 480));
        }

        public override void update()
        {
            base.update();
            base.MoveXpos();

            waves++;

            Blast.AddBulletBlast(8, waves, 120, 0.8f, centerx, centery);
            Blast.MoveBulletXpos(GetSpeed());
            Blast.SetHealth(GetHealth());

        }

        public override void drawship(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch, 80, 0);
            Blast.draw(spriteBatch);
        }

    }
}
