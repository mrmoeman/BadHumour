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
    class Bullet_Spell
    {
        int initx;
        int inity;
        int binitx;
        int binity;
        int timer;
        int wave;
        float temp;
        float temp_two;
        int OnDeath;
        int health;
        int setup;
        int temp_three;
        int temp_four;
        int direction = 1;
        int Pointing;
        Bullet bullet;
        List<Bullet> Bulletlist = new List<Bullet>();
        Boolean Checker = false;
        Boolean IsSecondary = false;
        Boolean CreationAllowed = true;
        Random Rnd = new Random();

        public Bullet_Spell(int ondeath)
        {
            OnDeath = ondeath;
        }

        public void SetSecondary(Boolean State)
        {
            IsSecondary = State;
        }

        public Boolean GetCheck()
        {
            return Checker;
        }

        public void SetCheck(Boolean tempbol)
        {
            Checker = tempbol;
        }

        public void SetCreationAllowed(Boolean State)
        {
            CreationAllowed = State;
        }

        public void SetInit(int x, int y)
        {
            Bulletlist.ForEach(i => i.SetInitX(x));
            Bulletlist.ForEach(i => i.SetInitY(y));
        }

        public int GetBullet_InitX()
        {
            Bulletlist.ForEach(i => {
              binitx = i.GetInitX();
            });
            if (Bulletlist.Count > 0)
            {
                return binitx;
            }
            else { return -5000; }
        }

        public int GetBullet_InitY()
        {
            Bulletlist.ForEach(i =>
            {
                binity = i.GetInitY();
            });
            if (Bulletlist.Count > 0)
            {
                return binity;
            }
            else { return -5000; }
        }

        public int GetBulletCount()
        {
            return Bulletlist.Count;
        }

        public void SetHealth(int number)
        {
            health = number;
        }

        public void SetWave(int number)
        {
            wave = number;
        }

        public void SetDirection(int number)
        {
            direction = number;
        }

        public void SetRadius (int number)
        {
            temp= number;
        }

        public Boolean CheckAllRadius(int number)
        {
            Bulletlist.ForEach(i =>
            {

                if (i.GetDistanceFromInit() < number)
                {
                    temp_four++;
                }


            });

            if (temp_four > 0)
            {
                temp_four = 0;
                return false;

            }
            else 
            {
                temp_four = 0;
                return true; 
            }


        }

        public void LimitBulletRadius(int number, Boolean SecondCheck)
        {
            Bulletlist.ForEach(i =>
            {

                if (i.GetDistanceFromInit() > number)
                {
                    if (i.GetSecondary() == IsSecondary || SecondCheck == false)
                    {
                        i.SetXpos(i.GetOldX());
                        i.SetYpos(i.GetOldY());
                    }
                    if (SecondCheck == true)
                    {
                        i.SetSecondary(true);
                    }
                }

                i.UpdateOldPosition();

            });


        }

        public void LimitRadius(int number)
        {
            if (temp >= number)
            {
                temp = number;
            }
        }

        public int GetWave()
        {
            return wave;
        }

        public float GetTemp()
        {
            return temp;
        }

        public int HealthCheck()
        {
            if (OnDeath == 0 && health > 0 || OnDeath == 1 && health <= 0)
            {
                return 1;
            }
            else { return 0; }
        }

        public void SetOwner(String nim)
        {
            Bulletlist.ForEach(i => i.SetOwner(nim));
        }

        public void SetColour(int number)
        {
            Bulletlist.ForEach(i => i.SetColour(number));
        }

        public void SetSpecial(int number)
        {
            Bulletlist.ForEach(i => i.SetSpecial(number));
        }

        public void SetSize(int number)
        {
            Bulletlist.ForEach(i => i.SetSize(number));
        }

        public virtual void MoveBulletXpos(float speed)
        {
            Bulletlist.ForEach(i => i.MoveInitX(speed));
        }

        public virtual void AddBulletPoint(int x, int y, float speed, Boolean SecondCheck)
        {
            Bulletlist.ForEach(i => {

                if (i.GetSecondary() == IsSecondary || SecondCheck == false)
                {
                    i.BulletPoint(x, y, speed);
                }
            
            });
            Pointing = 1;
        }


        public virtual void AddBulletLine(int x, int y, int direction)
        {
            timer++;
            if (timer > 10)
            {
                Bulletlist.ForEach(i => Bulletlist.Remove(i));
                if (direction == 1) //left
                {
                    for (int i = x; i > 0; i--)
                    {
                        bullet = new Bullet(i, y);
                        Bulletlist.Add(bullet);
                    }
                }
                if (direction == 2) //right
                {
                    for (int i = x; i < 800; i++)
                    {
                        bullet = new Bullet(i, y);
                        Bulletlist.Add(bullet);
                    }
                }
                if (direction == 3) //up
                {
                    for (int i = y; i > 0; i--)
                    {
                        bullet = new Bullet(x, i);
                        Bulletlist.Add(bullet);
                    }
                }
                if (direction == 4) //down
                {
                    for (int i = y; i < 480; i++)
                    {
                        bullet = new Bullet(x, i);
                        Bulletlist.Add(bullet);
                    }
                }
                timer = 0;
            }
        }

        public virtual void AddBulletStream(int time, int x, int y, int direction, int speed)
        {
            if ((OnDeath == 1 && HealthCheck() == 1) || OnDeath == 0)
            {
                timer++;
                temp++;
            }

            if (HealthCheck() == 1 && CreationAllowed == true)
            {
                if (timer >= time)
                {
                    bullet = new Bullet(x, y);
                    Bulletlist.Add(bullet);
                    timer = 0;
                }
            }

             Bulletlist.ForEach(i =>
            {
                if (direction == 1)
                {
                    i.MoveXpos(-speed);
                }
                if (direction == 2)
                {
                    i.MoveYpos(-speed);
                }

            });
        }

        public virtual void AddBulletStreamSine(int time, int x, int y, int radius, int PixelAngle, int direction)
        {
            if ((OnDeath == 1 && HealthCheck() == 1) || OnDeath == 0)
            {
                timer++;
                temp++;
            }

            if (HealthCheck() == 1)
            {
                if (timer >= time && CreationAllowed == true)
                {
                    bullet = new Bullet(x, y);
                    Bulletlist.Add(bullet);
                    Bulletlist.ForEach(i => i.SetColour(1));
                    timer = 0;
                }
            }

            Bulletlist.ForEach(i =>
            {
                i.BulletSine(radius, PixelAngle, direction);
                if (direction == 1)
                {
                    i.MoveXpos(-5);
                }
                if (direction == 2)
                {
                    i.MoveYpos(-5);
                }

            });
        }

        public virtual void AddBulletStreamSineSplit(int time, int x, int y, int radius, int PixelAngle, int direction, int radiusB, int PixelAngleB, int DirectionB)
        {
            if ((OnDeath == 1 && HealthCheck() == 1) || OnDeath == 0)
            {
                timer++;
                temp++;
            }

            if (HealthCheck() == 1)
            {
                if (timer >= time && CreationAllowed == true)
                {
                    bullet = new Bullet(x, y);
                    Bulletlist.Add(bullet);
                    timer = 0;
                }
            }

            Bulletlist.ForEach(i =>
            {
                i.DoubleBulletSplitSine(time, radius, PixelAngle, direction, radiusB, PixelAngleB, DirectionB);
                if (direction == 1)
                {
                    i.MoveXpos(-10);
                }
                if (direction == 2)
                {
                    i.MoveYpos(-10);
                }

            });
        }

        public virtual void AddBulletStreamSplit(int time, int x, int y, int direction)
        {
            if ((OnDeath == 1 && HealthCheck() == 1) || OnDeath == 0)
            {
                timer++;
                temp++;
            }

            if (HealthCheck() == 1)
            {
                if (timer >= time && CreationAllowed == true)
                {
                    bullet = new Bullet(x, y);
                    Bulletlist.Add(bullet);
                    timer = 0;
                }
            }

            Bulletlist.ForEach(i =>
            {
                i.BulletSplit((int)(time*4.5f));
                if (direction == 1)
                {
                    i.MoveXpos(-5);
                }
                if (direction == 2)
                {
                    i.MoveYpos(-5);
                }

            });


        }

        public virtual void AddBulletStreamDoubleSplit(int time, int x, int y, int direction)
        {
            if ((OnDeath == 1 && HealthCheck() == 1) || OnDeath == 0)
            {
                timer++;
                temp++;
            }

            if (HealthCheck() == 1)
            {
                if (timer >= time && CreationAllowed == true)
                {
                    bullet = new Bullet(x, y);
                    Bulletlist.Add(bullet);
                    timer = 0;
                }
            }

            Bulletlist.ForEach(i =>
            {
                i.BulletSplit(time);
                i.Bulletlist.ForEach(z =>
                {
                    z.BulletSplit(time);
                });
                if (direction == 1)
                {
                    i.MoveXpos(-5);
                }
                if (direction == 2)
                {
                    i.MoveYpos(-5);
                }

            });


        }

        public virtual void AddBulletStreamTripleSplit(int time, int x, int y, int direction)
        {
            if ((OnDeath == 1 && HealthCheck() == 1) || OnDeath == 0)
            {
                timer++;
                temp++;
            }

            if (HealthCheck() == 1)
            {
                if (timer >= time && CreationAllowed == true)
                {
                    bullet = new Bullet(x, y);
                    Bulletlist.Add(bullet);
                    timer = 0;
                }
            }

            Bulletlist.ForEach(i =>
            {
                i.BulletSplit(time);
                i.Bulletlist.ForEach(z =>
                {
                    z.DoubleBulletSplit(time);
                });
                if (direction == 1)
                {
                    i.MoveXpos(-5);
                }
                if (direction == 2)
                {
                    i.MoveYpos(-5);
                }

            });


        }
 
        public virtual void AddBulletCircleSpin(int number, int Waves, int time, float speed,float RotSpeed, int x, int y, Boolean SecondaryCheck)
        {
            if ((OnDeath == 1 && HealthCheck() == 1 )|| OnDeath == 0)
            {
                timer++;
                temp+= speed;
                temp_two += RotSpeed;
            }

                if (HealthCheck() == 1)
                {

                initx = x;
                inity = y;

                if ((temp * speed - time * speed * wave) >= 0 && wave < Waves && CreationAllowed == true)
                {
                    for (int z = 0; z < number + 1; z++)
                    {
                        bullet = new Bullet(initx, inity, 1, wave, z);
                        Bulletlist.Add(bullet);
                    }
                    wave++;
                    timer = 0;
                }
            }

            Bulletlist.ForEach(i =>
            {
                if (i.GetSecondary() == IsSecondary || SecondaryCheck == false)
                {
                    if (i.GetWave() <= wave && Pointing == 0)
                    {
                        i.SetXpos((int)(i.GetInitX() + (temp * speed - time * speed * i.GetWave()) * Math.Cos(((360 / number * (i.GetWhich())) - (temp_two - time * (i.GetWave() + 1)) * direction * RotSpeed) * Math.PI / 180)));
                        i.SetYpos((int)(i.GetInitY() + (temp * speed - time * speed * i.GetWave()) * Math.Sin(((360 / number * (i.GetWhich())) - (temp_two - time * (i.GetWave() + 1)) * direction * RotSpeed) * Math.PI / 180)));

                    }
                }
            });

        }

        public virtual void AddBulletCircleSpinOld(int number, int Waves, int time, float speed, float RotSpeed, int x, int y)
        {
            if ((OnDeath == 1 && HealthCheck() == 1) || OnDeath == 0)
            {
                timer++;
                temp += speed;
                temp_two += RotSpeed;
            }

            if (HealthCheck() == 1)
            {

                initx = x;
                inity = y;

                if ((temp * speed - time * speed * wave) >= 0 && wave < Waves && CreationAllowed == true)
                {
                    for (int z = 0; z < number + 1; z++)
                    {
                        bullet = new Bullet(initx, inity, 1, wave, z);
                        Bulletlist.Add(bullet);
                    }
                    wave++;
                    timer = 0;
                }
            }

            Bulletlist.ForEach(i =>
            {

                if (i.GetWave() <= wave && Pointing == 0)
                {
                    i.SetXpos((int)(i.GetInitX() + (temp * speed - time * speed * i.GetWave()) * Math.Cos(((360 / number * (i.GetWhich())) - (temp_two - time * (i.GetWave() + 1)) * direction) * Math.PI / 180)));
                    i.SetYpos((int)(i.GetInitY() + (temp * speed - time * speed * i.GetWave()) * Math.Sin(((360 / number * (i.GetWhich())) - (temp_two - time * (i.GetWave() + 1)) * direction) * Math.PI / 180)));

                }
            });

        }

        public virtual void AddBulletCircle(int number, int speed, int x, int y)
        {
            if ((OnDeath == 1 && HealthCheck() == 1) || OnDeath == 0)
            {
                timer++;
                temp+= speed;
            }

            if (HealthCheck() == 1)
            {

                initx = x;
                inity = y;

                if (timer == 2 && CreationAllowed == true)
                {
                    for (int z = 0; z < number; z++)
                    {
                        bullet = new Bullet(initx, inity, 1, 0, z);
                        Bulletlist.Add(bullet);
                    }
                    wave++;
                    
                }
            }

            Bulletlist.ForEach(i =>
            {
                if(Pointing == 0){
                    i.SetXpos((int)(i.GetInitX() + (temp) * Math.Cos(((360 / number * (i.GetWhich())) * direction) * Math.PI / 180)));
                    i.SetYpos((int)(i.GetInitY() + (temp) * Math.Sin(((360 / number * (i.GetWhich())) * direction) * Math.PI / 180)));
                }
            });

        }

        public virtual void AddBulletCirclePoint(int number, int speed, int x, int y, int distance, int px, int py, float pspeed)
        {
            if ((OnDeath == 1 && HealthCheck() == 1) || OnDeath == 0)
            {
                timer++;
                temp += speed;
            }

            if (HealthCheck() == 1)
            {

                initx = x;
                inity = y;

                if (timer == 2 && CreationAllowed == true)
                {
                    for (int z = 0; z < number + 1; z++)
                    {
                        bullet = new Bullet(initx, inity, 1, 0, z);
                        Bulletlist.Add(bullet);
                    }
                    wave++;

                }
            }

            Bulletlist.ForEach(i =>
            {
                if (i.GetDistanceFromInit() < distance && i.GetSetAllow() == 0)
                {
                    i.SetXpos((int)(i.GetInitX() + (temp) * Math.Cos(((360 / number * (i.GetWhich())) * direction) * Math.PI / 180)));
                    i.SetYpos((int)(i.GetInitY() + (temp) * Math.Sin(((360 / number * (i.GetWhich())) * direction) * Math.PI / 180)));
                }
                else
                {
                    i.SetAllow(1);
                    i.BulletPoint(px, py, pspeed);
                }

            });

        }

        public virtual void AddBulletBlastSpin(int number, int Waves, int time, int speed, float RotSpeed, int x, int y)
        {
            if ((OnDeath == 1 && HealthCheck() == 1) || OnDeath == 0)
            {
                timer++;
                temp++;
                temp_two += RotSpeed;
            }

            if (HealthCheck() == 1)
            {

                initx = x;
                inity = y;

                if ((temp * speed - time * speed * wave) >= 0 && wave < Waves && CreationAllowed == true)
                {
                    for (int z = 0; z < number + 1; z++)
                    {
                        bullet = new Bullet(initx, inity, 1, wave, z);
                        Bulletlist.Add(bullet);
                    }
                    wave++;
                    timer = 0;
                }
            }

            Bulletlist.ForEach(i =>
            {

                if (i.GetWave() <= wave && Pointing == 0)
                {
                    i.SetXpos((int)(i.GetInitX() + (temp * speed - time * speed * i.GetWave()) * Math.Cos(((360 / number * (i.GetWhich())) - (temp_two) * direction) * Math.PI / 180)));
                    i.SetYpos((int)(i.GetInitY() + (temp * speed - time * speed * i.GetWave()) * Math.Sin(((360 / number * (i.GetWhich())) - (temp_two) * direction) * Math.PI / 180)));

                }
            });

        }

        public virtual void AddBulletRotatingBlastStar(int number, int Waves, int time, int speed, float RotSpeed, int x, int y)
        {
            if ((OnDeath == 1 && HealthCheck() == 1) || OnDeath == 0)
            {
                timer++;
                temp++;
                temp_two += RotSpeed;
            }

            if (HealthCheck() == 1)
            {

                initx = x;
                inity = y;

                if ((temp * speed - time * speed * wave) >= 0 && wave < Waves && CreationAllowed == true)
                {
                    for (int z = 0; z < number*Math.Pow(2, wave); z++)
                    {
                        bullet = new Bullet(initx, inity, 1, wave, z);
                        Bulletlist.Add(bullet);
                    }
                    wave++;
                    timer = 0;
                }
            }

            Bulletlist.ForEach(i =>
            {

                if (i.GetWave() <= wave && Pointing == 0)
                {
                    if (i.GetWave() == 0)
                    {
                        i.SetXpos((int)(i.GetInitX() + (temp * speed - time * speed * i.GetWave()) * Math.Cos(((360 / (number * Math.Pow(2, i.GetWave())) * (i.GetWhich())) - (temp_two) * direction) * Math.PI / 180)));
                        i.SetYpos((int)(i.GetInitY() + (temp * speed - time * speed * i.GetWave()) * Math.Sin(((360 / (number * Math.Pow(2, i.GetWave())) * (i.GetWhich())) - (temp_two) * direction) * Math.PI / 180)));
                    }
                    if (i.GetWave() > 0)
                    {
                        i.SetXpos((int)(i.GetInitX() + (temp * speed - time * speed * i.GetWave()) * Math.Cos((((360 / (number * Math.Pow(2, i.GetWave())) * (i.GetWhich())) - (temp_two) * direction) + (360 / (number * Math.Pow(2, i.GetWave()-1)))/4) * Math.PI / 180)));
                        i.SetYpos((int)(i.GetInitY() + (temp * speed - time * speed * i.GetWave()) * Math.Sin((((360 / (number * Math.Pow(2, i.GetWave())) * (i.GetWhich())) - (temp_two) * direction) + (360 / (number * Math.Pow(2, i.GetWave()-1)))/4) * Math.PI / 180)));
                    }
                }
            });

        }

        public virtual void AddBulletBlast(int number, int Waves, int time, float speed, int x, int y)
        {

            if ((OnDeath == 1 && HealthCheck() == 1)|| OnDeath == 0)
            {
                timer++;
                temp+= speed;
            }

                if (HealthCheck() == 1)
                {

                initx = x;
                inity = y;

                if ((temp * speed - time * speed * wave) >= 0 && wave < Waves && CreationAllowed == true)
                {
                    for (int z = 0; z <= number + 1; z++)
                    {
                        bullet = new Bullet(initx, inity, 1, wave, z);
                        Bulletlist.Add(bullet);
                    }
                    wave++;
                    timer = 0;
                }
            }
                Bulletlist.ForEach(i =>
                {

                    if (i.GetWave() <= wave && Pointing == 0)
                    {
                        i.SetXpos((int)(i.GetInitX() + (temp * speed - time * speed * i.GetWave()) * Math.Cos((360 / number * (i.GetWhich())) * Math.PI / 180)));
                        i.SetYpos((int)(i.GetInitY() + (temp * speed - time * speed * i.GetWave()) * Math.Sin((360 / number * (i.GetWhich())) * Math.PI / 180)));

                    }
                });
        }

        public virtual void AddBulletBlastPoint(int number, int Waves, int time, float speed, int x, int y, int distance, int px, int py, float pspeed)
        {

            if ((OnDeath == 1 && HealthCheck() == 1) || OnDeath == 0)
            {
                timer++;
                temp += speed;
            }

            if (HealthCheck() == 1)
            {

                initx = x;
                inity = y;

                if ((temp * speed - time * speed * wave) >= 0 && wave < Waves && CreationAllowed == true)
                {
                    for (int z = 0; z <= number + 1; z++)
                    {
                        bullet = new Bullet(initx, inity, 1, wave, z);
                        Bulletlist.Add(bullet);
                    }
                    wave++;
                    timer = 0;
                }
            }
            Bulletlist.ForEach(i =>
            {
                if (i.GetDistanceFromInit() < distance && i.GetSetAllow() == 0)
                {
                    if (i.GetWave() <= wave && Pointing == 0)
                    {
                        i.SetXpos((int)(i.GetInitX() + (temp * speed - time * speed * i.GetWave()) * Math.Cos((360 / number * (i.GetWhich())) * Math.PI / 180)));
                        i.SetYpos((int)(i.GetInitY() + (temp * speed - time * speed * i.GetWave()) * Math.Sin((360 / number * (i.GetWhich())) * Math.PI / 180)));

                    }
                }
                else
                {
                    i.SetAllow(1);
                    i.BulletPoint(px, py, pspeed);
                }
            });
        }

        public virtual void AddBulletSectorBlast(int number, int Waves, int time, float speed, int x, int y, float MidAngle, int VariationAngle)
        { // mindangle = 0 is to the right
            //midangle goes clockwise into positive

            if ((OnDeath == 1 && HealthCheck() == 1) || OnDeath == 0)
            {
                timer++;
                temp += speed;
            }

            if (HealthCheck() == 1)
            {

                initx = x;
                inity = y;

                if ((temp * speed - time * speed * wave) >= 0 && wave < Waves && CreationAllowed == true)
                {
                    for (int z = 0; z <= number ; z++)
                    {
                        bullet = new Bullet(initx, inity, 1, wave, z);
                        Bulletlist.Add(bullet);
                    }
                    wave++;
                    timer = 0;
                }
            }
            Bulletlist.ForEach(i =>
            {

                if (i.GetWave() <= wave && Pointing == 0)
                {
                    i.SetXpos((int)(i.GetInitX() + (temp * speed - time * speed * i.GetWave()) * Math.Cos((((VariationAngle / number) * (i.GetWhich())) + (MidAngle - VariationAngle / 2)) * Math.PI / 180)));
                    i.SetYpos((int)(i.GetInitY() + (temp * speed - time * speed * i.GetWave()) * Math.Sin((((VariationAngle / number) * (i.GetWhich())) + (MidAngle - VariationAngle / 2)) * Math.PI / 180)));

                }
            });
        }

        public virtual void RotateAboutPoint(float x, float y, float rotspeed, Boolean SecondaryCheck)
        {
            Bulletlist.ForEach(i =>
            {

                if (i.GetWave() <= wave && Pointing == 0 && (i.GetSecondary() == IsSecondary || SecondaryCheck == false))
                {
                    i.RotateAboutPoint(x, y, rotspeed);
                }
            });
        }

        public virtual void RotateAboutRelativePoint(float x, float y, float rotspeed, Boolean SecondaryCheck)
        {
            Bulletlist.ForEach(i =>
            {

                if (i.GetWave() <= wave && Pointing == 0 && (i.GetSecondary() == IsSecondary || SecondaryCheck == false))
                {
                    i.RotateAboutPoint(i.GetBullet().X - x, i.GetBullet().Y - y, rotspeed);
                }
            });
        }

        public virtual void RotateAboutInitPoint(float rotspeed, Boolean SecondaryCheck)
        {
            Bulletlist.ForEach(i =>
            {

                if (i.GetWave() <= wave && Pointing == 0 && (i.GetSecondary() == IsSecondary || SecondaryCheck == false))
                {
                    i.RotateAboutPoint(i.GetInitX(), i.GetInitY(), rotspeed);
                }
            });
        }

        public virtual void AddBulletSpray(int x, int y, int number, int time, int Waves, float speed, Boolean SecondaryCheck)
        {
            if ((OnDeath == 1 && HealthCheck() == 1) || OnDeath == 0)
            {
                timer++;
                temp += speed;
            }

            if (HealthCheck() == 1)
            {

                initx = x;
                inity = y;

                if (timer > time && wave < Waves && CreationAllowed == true)
                {
                    for (int z = 0; z < number; z++)
                    {

                        bullet = new Bullet(initx, inity, 1, wave, Rnd.Next(0, 360));
                        Bulletlist.Add(bullet);
                    }
                    wave++;
                    timer = 0;
                }

                Bulletlist.ForEach(i =>
                {
                    if (i.GetSecondary() == IsSecondary || SecondaryCheck == false)
                    {


                        i.SetXpos((float)(i.GetFX() + (i.GetDistanceFromInit() + speed) * Math.Cos(i.GetWhich()) * Math.PI / 180));
                        i.SetYpos((float)(i.GetFY() + (i.GetDistanceFromInit() + speed) * Math.Sin(i.GetWhich()) * Math.PI / 180));
                    
                    
                    }

                });

            }

        }


        public virtual void AddBulletCascadingBlast(int number, int speed, int x, int y, int radius, int second_number)
        {

            if ((OnDeath == 1 && HealthCheck() == 1) || OnDeath == 0)
            {
                timer++;
                temp+= speed;
            }

            if (HealthCheck() == 1)
            {
                if (temp > radius && setup == 0)
                {
                    temp_three = Bulletlist.Count;
                     Bulletlist.ForEach(i =>
                        {
                            if (temp_four < temp_three)
                            {
                                for (int z = 0; z < second_number; z++)
                                {
                                    bullet = new Bullet(i.GetX(), i.GetY(), 1, 0, z,(int) temp);
                                    Bulletlist.Add(bullet);
                                    i.SetVisibility(1);

                                }
                                temp_four++;
                            }
                        });
                        Bulletlist.ForEach(i =>
                        {
                            if (i.GetRadius() > 0)
                            {
                                i.SetSize(1);
                            }
                        });

                    setup = 1;
                }

                initx = x;
                inity = y;

                if ((wave) >= 0 && wave < 1)
                {
                    for (int z = 0; z <= number + 1; z++)
                    {
                        bullet = new Bullet(initx, inity, 1, wave, z);
                        Bulletlist.ForEach(i => i.SetColour(2));
                        Bulletlist.ForEach(i => i.SetSize(2));
                        Bulletlist.Add(bullet);
                    }
                    wave++;
                    timer = 0;
                }
            }
            Bulletlist.ForEach(i =>
            {

                if (i.GetWave() <= wave)
                {
                    if (temp < radius || i.GetRadius() > 0 && Pointing == 0)
                    {
                        i.SetXpos((int)(i.GetInitX() + (temp - i.GetRadius()) * Math.Cos((360 / number * (i.GetWhich())) * Math.PI / 180)));
                        i.SetYpos((int)(i.GetInitY() + (temp - i.GetRadius()) * Math.Sin((360 / number * (i.GetWhich())) * Math.PI / 180)));
                    }
                }
            });
        }

        public void AdjustRotationWithPosition(Vector2 Adjust, Boolean SecondaryCheck)
        {
            Bulletlist.ForEach(i =>
            {

                if ((i.GetSecondary() == IsSecondary || SecondaryCheck == false))
                {
                    i.AdjustPosition(Adjust);
                    i.AdjustRotationPoint(Adjust);
                }
            });
        }

        public void RemoveAll()
        {
            Bulletlist.ForEach(i =>
            {
                Bulletlist.Remove(i);
            });
        }

        public void draw(SpriteBatch spriteBatch)
        {

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
                if (i.GetOffScreen() == 1)
                {
                    Bulletlist.Remove(i);
                }
            });

            //spriteBatch.DrawString(Game1.Arial, "" + wave, new Vector2(115, 23), Color.White);
             Bulletlist.ForEach(i =>{
                    if (i.GetWave() <= wave)
                    {
                        i.draw(spriteBatch);
                    }
             });

        }


    }
}
