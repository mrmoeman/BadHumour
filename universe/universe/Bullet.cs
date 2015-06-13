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
    class Bullet
    {
        float xpos;
        float ypos;
        int direction;
        int other = 1;
        int speed;
        int timer;
        float initx;
        float inity;
        float oldx;
        float oldy;
        int wave;
        int which;
        int radius;
        int size;
        int visible;
        int colour;
        float PointX;
        float PointY;
        int PointSetup;
        int SetAllowed;
        float rotation;
        float oldrotation;
        int special;
        int anitimer;
        String owned;
        float offset;
        Vector2 vectorpos;
        Vector2 tempvect;
        Rectangle tempbound;
        Trail Bullettrail = new Trail();
        Bullet bullet;
        public List<Bullet> Bulletlist = new List<Bullet>();
        Random rnd = new Random();
        Boolean SpecChecl = false;
        Boolean IsSecondary = false;
        Boolean RotationSetup = false;
        double Rotation;
        Vector2 RotationPoint;
        float RotRadius;

        public Bullet(float x, float y)
        {
            xpos = x;
            ypos = y;
            initx = x;
            inity = y;
            timer = rnd.Next(1, 13);
            
        }

        public Bullet(float x, float y, String own)
        {
            owned = own;
            xpos = x;
            ypos = y;
            initx = x;
            inity = y;
            timer = rnd.Next(1, 13);
        }

        public Bullet(float x, float y, int othe)
        {
            xpos = x;
            ypos = y;
            initx = x;
            inity = y;
            other = othe;
            timer = rnd.Next(1, 13);
        }

        public Bullet(float x, float y, int othe, int wav, int whic)
        {
            xpos = x;
            ypos = y;
            initx = x;
            inity = y;
            other = othe;
            which = whic;
            wave = wav;
            timer = rnd.Next(1, 13);
        }

        public Bullet(float x, float y, int othe, int wav, int whic, int rad)
        {
            xpos = x;
            ypos = y;
            initx = x;
            inity = y;
            other = othe;
            which = whic;
            wave = wav;
            radius = rad;
            timer = rnd.Next(1, 13);
        }

        public double GetRotation()
        {
            return Rotation;
        }

        public int GetBombed()
        {
            if (Game1.Dan_Data.GetBomb() == 1)
            {
                tempvect = Game1.Dan_Data.GetBombVector();

                if (Math.Sqrt((xpos - tempvect.X) * (xpos - tempvect.X) + (ypos - tempvect.Y) * (ypos - tempvect.Y)) <= Game1.Dan_Data.GetBombRadius() && owned != "player")
                {
                    return 1;
                }
                else { return 0; }
                
            }
            else
            {
                return 0;
            }
        }

        public int GetShielded()
        {
             if (Game1.Dan_Data.GetInvun() > 0)
            {
                tempvect = Game1.Dan_Data.GetData();

                if (Math.Sqrt((xpos - tempvect.X) * (xpos - tempvect.X) + (ypos - tempvect.Y) * (ypos - tempvect.Y)) <= 32 && owned != "player")
                {
                    return 1;
                }
                else { return 0; }
              
            }
            else
            {
                return 0;
            }
        }

        public Vector2 GetBullet()
        {
            return vectorpos = new Vector2(xpos, ypos);
        }

        public int GetSize()
        {
            return size;
        }

        public Boolean GetSecondary()
        {
            return IsSecondary;
        }

        public void SetSecondary(Boolean State)
        {
            IsSecondary = State;
        }

        public int GetOffBottom()
        {
            if (ypos > 480)
            {
                return 1;
            }
            else { return 0; }
        }

        public int GetOffTop()
        {
            if (ypos < 0)
            {
                return 1;
            }
            else { return 0; }
        }

        public int GetOffSides()
        {
            if (xpos > 800 || xpos < 0)
            {
                return 1;
            }
            else { return 0; }
        }

        public int GetOffScreen()
        {
            if (xpos > 1200 || xpos < -400 || ypos < -400 || ypos > 880)
            {
                return 1;
            }
            else { return 0; }
        }

        public int GetInitX()
        {
            return (int)initx;
        }

        public int GetInitY()
        {
            return (int)inity;
        }

        public float GetOldX()
        {
            return oldx;
        }

        public float GetOldY()
        {
            return oldy;
        }

        public int GetX()
        {
            return (int)xpos;
        }

        public int GetY()
        {
            return (int)ypos;
        }

        public float GetFX()
        {
            return xpos;
        }

        public float GetFY()
        {
            return ypos;
        }

        public int GetRadius()
        {
            return radius;
        }

        public int GetWhich()
        {
            return which;
        }

        public int GetWave()
        {
            return wave;
        }

        public float GetDistanceFromInit()
        {
            return (float)(Math.Sqrt((xpos + 3 - initx) * (xpos + 3 - initx) + (ypos + 3 - inity) * (ypos + 3 - inity)));
        }

        public float GetDistanceFromInitX()
        {
            return initx - xpos;
        }
        public float GetDistanceFromInitY()
        {
            return inity - ypos;
        }

        public int GetSetAllow()
        {
            return SetAllowed;
        }

        public void SetOwner(String nim)
        {
            owned = nim;
        }

        public void SetSpecial(int number)
        {
            special = number;
        }

        public void SetVisibility(int number)
        {
            visible = number;
        }

        public void SetSize(int number)
        {
            size = number;
        }

        public void SetColour(int number)
        {
            colour = number;
        }

        public void SetAllow(int number)
        {
            SetAllowed = number;
        }

        public void SetYpos(float number)
        {
            if (SetAllowed == 0)
            {
                ypos = number;
            }
        }
        public void SetXpos(float number)
        {
            if (SetAllowed == 0)
            {
                xpos = number;
            }
        }

        public void AdjustRotationPoint(Vector2 Adjust)
        {
            RotationPoint = RotationPoint + Adjust;
        }

        public void AdjustPosition(Vector2 Adjust)
        {
            xpos = xpos + Adjust.X;
            ypos = ypos + Adjust.Y;
        }


        public void RotateAboutPoint(float x, float y, float FullCircleTime)
        {
            if (RotationSetup == false)
            {
                RotationPoint = new Vector2(x, y);
                Rotation = Angle(RotationPoint, GetBullet(), new Vector2(x, y - 5));
                RotRadius = DistanceBetweenTwoPoints(GetBullet(), RotationPoint).Z;
                if (xpos < x)
                {
                    Rotation = 360 - Rotation;
                }
                RotationSetup = true;
                
            }

            Rotation += 360/FullCircleTime;
            float TempRad = DistanceBetweenTwoPoints(RotationPoint, GetBullet()).Z;

            xpos = (float)(RotationPoint.X + TempRad * Math.Sin(Rotation * Math.PI / 180));

            ypos = (float)(RotationPoint.Y - TempRad * Math.Cos(Rotation * Math.PI / 180));
        }

        public double Angle(Vector2 A, Vector2 B, Vector2 C)
        {
            double AB = DistanceBetweenTwoPoints(A, B).Z;
            double AC = DistanceBetweenTwoPoints(A, C).Z;
            double BC = DistanceBetweenTwoPoints(B, C).Z;

            double angle = Math.Acos(((AC * AC) + (AB * AB) - (BC * BC)) /( 2 * AC * AB));

            return angle * (180/Math.PI);
        }

        

        public Vector3 DistanceBetweenTwoPoints(Vector2 pointa, Vector2 pointb)
        {
            double tempx = pointa.X - pointb.X;
            double tempy = pointa.Y - pointb.Y;
            double hyp = Math.Sqrt(tempx * tempx + tempy * tempy);
            return new Vector3((float)tempx,(float) tempy, (float)hyp);
        }

        public void MoveInitY(float number)
        {
            inity += (int)number;
        }
        public void MoveInitX(float number)
        {
            initx += (int)number;
        }

        public void SetInitY(float number)
        {
            inity = (int)number;
        }
        public void SetInitX(float number)
        {
            initx = (int)number;
        }

        public double DistanceFromInit()
        {
            return Math.Sqrt((initx - xpos) * (initx - xpos) + (inity - ypos) * (inity - ypos));
        }

        public void UpdateOldPosition()
        {
            oldx = xpos;
            oldy = ypos;
        }

        public void BulletPoint(int x, int y, float speed)
        {
            if (PointSetup == 0)
            {
                
                if (xpos - x != 0 && ypos - y != 0)
                {
                    if (xpos - x < 0 && ypos - y < 0)
                    {
                        PointY = (ypos - y)/((x - xpos)/speed);
                        PointX = speed;
                    }
                    if (xpos - x < 0 && ypos - y > 0)
                    {
                        PointY = (ypos - y) / ((x - xpos) / -speed);
                        PointX = speed;
                    }

                    if (xpos - x > 0 && ypos - y < 0)
                    {
                        PointY = (y - ypos) / ((xpos - x) / speed);
                        PointX = -speed;
                    }
                    if (xpos - x > 0 && ypos - y > 0)
                    {
                        PointY = (ypos - y)/((xpos - x)/-speed);
                        PointX = -speed;
                    }
                }
                if (xpos - x == 0)
                {
                    if (ypos - y < 0)
                    {
                        PointX = 0;
                        PointY = speed;
                    }
                    else
                    {
                        PointX = 0;
                        PointY = -speed;
                    }
                }
                if (ypos - y == 0)
                {
                    if (xpos - x > 0)
                    {
                        PointX = -speed;
                        PointY = 0;
                    }
                    else
                    {
                        PointX = speed;
                        PointY = 0;
                    }
                }
                PointSetup = 1;
                
            }
            xpos = (xpos + PointX);
            ypos = (ypos + PointY);

        }

        public void BulletSine(int radius, int PixelAngle, int direct)
        {
            if (direct == 1)
            {
                offset = (float)Math.Sin(initx - xpos * PixelAngle) * radius;
                ypos = inity + (int)offset;
            }
            if (direct == 2)
            {
                offset = (float)Math.Sin(inity - ypos * PixelAngle) * radius;
                xpos = initx + (int)offset;
            }
        }

        public void DoubleBulletSplitSine(int time, int radiusA, int PixelAngleA, int directA, int radius, int PixelAngle, int direct)
        {
            BulletSine(radiusA, PixelAngleA, directA);

            timer++;
            if (timer > time)
            {
                bullet = new Bullet(xpos, ypos, 1);
                Bulletlist.Add(bullet);
                bullet = new Bullet(xpos, ypos, -1);
                Bulletlist.Add(bullet);
                timer = 0 + rnd.Next(0, 10);
            }
            if (direct == 1)
            {
               Bulletlist.ForEach(i => i.MoveYpos(speed / 2));
               Bulletlist.ForEach(i => i.BulletSine(radius, PixelAngle, 2));
            }
            if (direct == 2)
            {
               Bulletlist.ForEach(i => i.MoveXpos(speed / 2));
               Bulletlist.ForEach(i => i.BulletSine(radius, PixelAngle, 1));
            }
            Bulletlist.ForEach(i => { if (i.GetOffScreen() == 1) { Bulletlist.Remove(i); } });
        }


        public void BulletSplit(int time)
        {
            timer++;
            if (timer > time)
            {
                bullet = new Bullet(xpos, ypos, 1);
                Bulletlist.Add(bullet);
                bullet = new Bullet(xpos, ypos, -1);
                Bulletlist.Add(bullet);
                timer = 0 + rnd.Next(0, 10);
            }
            if (direction == 1)
            {
                Bulletlist.ForEach(i => i.MoveYpos(speed/2));
            }
            if (direction == 2)
            {
                Bulletlist.ForEach(i => i.MoveXpos(speed/2));
            }
            Bulletlist.ForEach(i => { if (i.GetOffScreen() == 1) { Bulletlist.Remove(i); } });
        }

        public void DoubleBulletSplit(int time)
        {
            BulletSplit(time);
            Bulletlist.ForEach(i => i.BulletSplit(time));
        }

        public void TripleBulletSplit(int time)
        {
            BulletSplit(time);
            Bulletlist.ForEach(i => i.DoubleBulletSplit(time));
        }

        public void MoveYpos(int number)
        {
            ypos += number * other;
            direction = 2;
            speed = number;
        }

        public void MoveXpos(int number)
        {
            xpos += number * other;
            direction = 1;
            speed = number;
        }

        

        public void draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.DrawString(Game1.Arial, "" + Rotation, new Vector2(115, 23), Color.White);
            anitimer++;

            Bulletlist.ForEach(i =>
            {
                if (i.GetBombed() == 1)
                {
                    Bulletlist.Remove(i);
                }
                if (i.GetShielded() == 1)
                {
                    Bulletlist.Remove(i);
                }
            });

            if (owned != "player" && visible == 0)
            {
                tempvect = Game1.Dan_Data.GetData();
                tempbound = new Rectangle ((int)tempvect.X - 2, (int)tempvect.Y - 2, 4, 4);
                if (size == 0)
                {
                    if (Math.Sqrt((xpos - tempvect.X) * (xpos - tempvect.X) + (ypos - tempvect.Y) * (ypos - tempvect.Y)) < 4)
                    {
                        Game1.Dan_Data.SetHit(1);
                    }
                }
                if (size == 1)
                {
                    if (Math.Sqrt((xpos - tempvect.X) * (xpos - tempvect.X) + (ypos - tempvect.Y) * (ypos - tempvect.Y)) < 10)
                    {
                        Game1.Dan_Data.SetHit(1);
                    }
                }
                if (size == 2)
                {
                    if (Math.Sqrt((xpos - tempvect.X) * (xpos - tempvect.X) + (ypos - tempvect.Y) * (ypos - tempvect.Y)) < 25)
                    {
                        Game1.Dan_Data.SetHit(1);
                    }
                }
            }

            if (special == 1)
            {
                if (anitimer > 12)
                {
                    anitimer = 0;
                }
                if (anitimer <= 4)
                {
                    colour=0;
                }
                if (anitimer > 4 && anitimer <= 8)
                {
                    colour = 1;
                }
                if (anitimer > 8 && anitimer <= 12)
                {
                    colour = 2;
                }
            }

            if (special == 5)
            {
                if (SpecChecl == false)
                {
                    anitimer = rnd.Next(0, 25);
                    SpecChecl = true;
                }
                size = 1;
                if (colour == 0)
                {
                    spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(218, 19, 25, 25), Color.White * 0.3f);
                }
                if (colour == 1)
                {
                    spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(0, 100, 25, 25), Color.White * 0.3f);
                }
                if (colour == 2)
                {
                    spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(50, 100, 25, 25), Color.White * 0.3f);
                }
                if (anitimer > 25)
                {
                    anitimer = 0;
                }
                if (anitimer <= 5)
                {
                    if (colour == 0)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(218, 19, 25, 25), Color.White);
                    }
                    if (colour == 1)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(0, 100, 25, 25), Color.White * 0.3f);
                    }
                    if (colour == 2)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(50, 100, 25, 25), Color.White * 0.3f);
                    }

                }
                if (anitimer > 5 && anitimer <= 10)
                {
                    if (colour == 0)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(218, 45, 25, 25), Color.White);
                    }
                    if (colour == 1)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(0, 125, 25, 25), Color.White * 0.3f);
                    }
                    if (colour == 2)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(50, 125, 25, 25), Color.White * 0.3f);
                    }
                }
                if (anitimer > 10 && anitimer <= 15)
                {
                    if (colour == 0)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(218, 95, 25, 25), Color.White);
                    }
                    if (colour == 1)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(0, 150, 25, 25), Color.White * 0.3f);
                    }
                    if (colour == 2)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(50, 150, 25, 25), Color.White * 0.3f);
                    }
                }
                if (anitimer > 15 && anitimer <= 20)
                {
                    if (colour == 0)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(244, 95, 25, 25), Color.White);
                    }
                    if (colour == 1)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(25, 150, 25, 25), Color.White * 0.3f);
                    }
                    if (colour == 2)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(75, 150, 25, 25), Color.White * 0.3f);
                    }
                }
                if (anitimer > 20 && anitimer <= 25)
                {
                    if (colour == 0)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(244, 45, 25, 25), Color.White);
                    }
                    if (colour == 1)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(25, 125, 25, 25), Color.White * 0.3f);
                    }
                    if (colour == 2)
                    {
                        spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12.5f, ypos - 12.5f), new Rectangle(75, 125, 25, 25), Color.White * 0.3f);
                    }
                }
            }

            Bulletlist.ForEach(i => i.draw(spriteBatch));
            if (visible == 0)
            {
                if (special == 1)
                {
                   // if (size == 0)
                   // {
                        Bullettrail.AddParticle((int)xpos, (int)ypos, 5);
                        Bullettrail.SetType(1);
                        Bullettrail.draw(spriteBatch);
                   // }
                }
                if (special == 2)
                {
                    rotation = (float)(Math.Tanh((ypos - inity) / (xpos - initx)));
                    if (xpos > initx && ypos > inity)
                    {
                        rotation += (float)(180 * Math.PI / 180);
                    }
                    if (xpos < initx && ypos < inity)
                    {  
                    }
                    if (xpos < initx && ypos > inity)
                    {
                    }
                    if (xpos > initx && ypos < inity)
                    {
                        rotation += (float)(180 * Math.PI / 180);
                    }
                    if (xpos == initx && ypos > inity){
                        rotation = (float)(270 * Math.PI / 180);
                    }
                    if (xpos == initx && ypos < inity)
                    {
                        rotation = (float)(90 * Math.PI / 180);
                    }
                    if (ypos == inity && xpos > initx)
                    {
                        rotation = (float)(180 * Math.PI / 180);
                    }
                    if (ypos == inity && xpos < initx)
                    {
                        rotation = (float)(0 * Math.PI / 180);
                    }
                }

                if (special == 3)
                {
                    if (oldx != xpos && oldy != ypos)
                    {
                        rotation = (float)(Math.Tanh((ypos - oldy) / (xpos - oldx)));

                        if (xpos > oldx && ypos > oldy)
                        {
                            rotation += (float)(180 * Math.PI / 180);
                        }
                        if (xpos < oldx && ypos < oldy)
                        {
                        }
                        if (xpos < oldx && ypos > oldy)
                        {
                        }
                        if (xpos > oldx && ypos < oldy)
                        {
                            rotation += (float)(180 * Math.PI / 180);
                        }
                        if (xpos == oldx && ypos > oldy)
                        {
                            rotation = (float)(270 * Math.PI / 180);
                        }
                        if (xpos == oldx && ypos < oldy)
                        {
                            rotation = (float)(90 * Math.PI / 180);
                        }
                        if (ypos == oldy && xpos > oldx)
                        {
                            rotation = (float)(180 * Math.PI / 180);
                        }
                        if (ypos == oldy && xpos < oldx)
                        {
                            rotation = (float)(0 * Math.PI / 180);
                        }
                    }
                    else
                    {
                        rotation = oldrotation;
                    }
                    oldx = xpos;
                    oldy = ypos;
                    oldrotation = rotation;
                }
                if (special == 4)
                {
                    // if (size == 0)
                    // {
                    Bullettrail.BubbleParticles((int)xpos, (int)ypos, 6, (int)oldx, (int)oldy);
                    Bullettrail.draw(spriteBatch);
                    // }
                }


                if (size == 0)
                {
                    if (colour == 0)
                    {
                        if (special == 0){
                        spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 3, ypos - 3), new Rectangle(75, 75, 6, 6), Color.White);
                        }
                        if (special == 1)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 3, ypos - 3), new Rectangle(175, 75, 6, 6), Color.White);
                        }
                        if (special == 2 || special == 3)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 3, ypos - 3), new Rectangle(87, 75, 13, 7), Color.White, rotation, new Vector2(3,3), 1.0f, SpriteEffects.None, 0.0f);
                        }
                    }
                    if (colour == 1)
                    {
                        if (special == 0)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 3, ypos - 3), new Rectangle(81, 75, 6, 6), Color.White);
                        }
                        if (special == 1)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 3, ypos - 3), new Rectangle(181, 75, 6, 6), Color.White);
                        }
                        if (special == 2 || special == 3)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 3, ypos - 3), new Rectangle(87, 82, 13, 7), Color.White, rotation, new Vector2(3, 3), 1.0f, SpriteEffects.None, 0.0f);
                        }
                    }
                    if (colour == 2)
                    {
                        if (special == 0)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 3, ypos - 3), new Rectangle(75, 81, 6, 6), Color.White);
                        }
                        if (special == 1)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 3, ypos - 3), new Rectangle(175, 81, 6, 6), Color.White);
                        }
                        if (special == 2 || special == 3)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 3, ypos - 3), new Rectangle(87, 89, 13, 7), Color.White, rotation, new Vector2(3, 3), 1.0f, SpriteEffects.None, 0.0f);
                        }
                    }
                    if (colour == 3)
                    {
                        if (special == 0)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 3, ypos - 3), new Rectangle(81, 81, 6, 6), Color.White);
                        }
                    }
                }
                if (size == 1)
                {
                    if (colour == 0)
                    {
                        if (special == 0)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12, ypos - 12), new Rectangle(50, 50, 25, 25), Color.White);
                        }
                        if (special == 1)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12, ypos - 12), new Rectangle(150, 50, 25, 25), Color.White);
                        }
                    }
                    if (colour == 1)
                    {
                        if (special == 0)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12, ypos - 12), new Rectangle(75, 50, 25, 25), Color.White);
                        }
                        if (special == 1)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12, ypos - 12), new Rectangle(175, 50, 25, 25), Color.White);
                        }
                    }
                    if (colour == 2)
                    {
                        if (special == 0)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12, ypos - 12), new Rectangle(50, 75, 25, 25), Color.White);
                        }
                        if (special == 1)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 12, ypos - 12), new Rectangle(150, 75, 25, 25), Color.White);
                        }
                    }
                }
                if (size == 2)
                {
                    if (colour == 0)
                    {
                        if (special == 0)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 25, ypos - 25), new Rectangle(0, 0, 50, 50), Color.White);
                        }
                        if (special == 1)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 25, ypos - 25), new Rectangle(100, 0, 50, 50), Color.White);
                        }
                    }
                    if (colour == 1)
                    {
                        if (special == 0)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 25, ypos - 25), new Rectangle(0, 50, 50, 50), Color.White);
                        }
                        if (special == 1)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 25, ypos - 25), new Rectangle(100, 50, 50, 50), Color.White);
                        }
                    }
                    if (colour == 2)
                    {
                        if (special == 0)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 25, ypos - 25), new Rectangle(50, 0, 50, 50), Color.White);
                        }
                        if (special == 1)
                        {
                            spriteBatch.Draw(Game1.bullet, new Vector2(xpos - 25, ypos - 25), new Rectangle(150, 0, 50, 50), Color.White);
                        }
                    }
                }
            }
        }
    }
}
