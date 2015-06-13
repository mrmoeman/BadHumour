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
    class Silax_Psion_Ship : Danmaku_Enemy
    {
        int xp;
        int yp;
        int timer;
        float rotation;
        Boolean check = false;
        Bullet_Spell Circle;
        Bullet_Spell Blast;
        Direction direction;
        

        List<Bullet_Spell> BulletSpelllist = new List<Bullet_Spell>();

        public Silax_Psion_Ship(int x, int y, Direction dir, int speed)
            : base(x, y, 2, 5, 25, 25)
        {
            SetSpeed(speed);
            direction = dir;
            Circle = new Bullet_Spell(0);
            Blast = new Bullet_Spell(1);

        }


        public override void update()
        {
            base.update();
            rotation += 0.1f;
            if (direction == Direction.Up)
            {
                SetYpos(GetYpos() - GetSpeed());
                if (GetYpos() < 0)
                {
                    resetpos();
                }
            }
            if (direction == Direction.Down)
            {
                SetYpos(GetYpos() + GetSpeed());
                if (GetYpos() > 480)
                {
                    resetpos();
                }
            }
            if (direction == Direction.Left)
            {
                SetXpos(GetXpos() - GetSpeed());
                if (GetYpos() < 0)
                {
                    resetpos();
                }
            }
            if (direction == Direction.Right)
            {
                SetXpos(GetXpos() + GetSpeed());
                if (GetYpos() > 800)
                {
                    resetpos();
                }
            }

            timer++;

            if (timer > 80 && GetHealth() > 0)
            {
                Circle = new Bullet_Spell(0);
                BulletSpelllist.Add(Circle);
                timer = 0;
            }

            BulletSpelllist.ForEach(i =>
            {
             
             i.SetHealth(GetHealth());
             if ((i.CheckAllRadius(140) == true && i.GetBulletCount() > 1) || i.GetCheck() == true)
             {
                 i.SetSecondary(true);
                 i.SetSize(1);
                 i.AddBulletPoint((int)(Game1.Dan_Data.GetData().X), (int)(Game1.Dan_Data.GetData().Y), 2f, false);
                 i.SetCheck(true);
                 i.SetSpecial(5);
                 i.SetColour(0);
             }
             else
             {
                 i.AddBulletCircleSpin(2, 10, 10, 1.5f, -0.2f, centerx, centery, false);
                 i.LimitBulletRadius(150, false);
                 i.SetColour(1);
                 i.SetSize(0);
             }

            });
            

            Blast.SetHealth(GetHealth());
            Blast.AddBulletSectorBlast(10, 1, 1, 2, centerx, centery, 180, 120);
            Blast.SetSpecial(2);

           

        }


        public override void drawship(SpriteBatch spriteBatch)
        {

            //base.draw(spriteBatch, 182, 100);

            if (GetHealth() > 0)
            {
                spriteBatch.Draw(Game1.eship, new Vector2(GetXpos(), GetYpos()), new Rectangle(182, 100, 25, 25), Color.White, rotation, new Vector2(12.5f, 12.5f), 1.0f, SpriteEffects.None, 0.0f);

            }
            else
            {
                base.draw(spriteBatch, 182, 100);
            }

             BulletSpelllist.ForEach(i =>
            {

                i.draw(spriteBatch);

            });

            Blast.draw(spriteBatch);

        }

    }
}
