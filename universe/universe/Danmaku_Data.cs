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
    public enum Danmaku_Character {Moeman, Gaile, Cirno, Simon, Amelia, Carara, Kagami, Mitchel, Klavis, Valetta, Seli, Eloise};

    public class Danmaku_Data
    {
        public Danmaku_Data()
        {

        }

        Vector2 Tempvect;
        int playerx = 0;
        int playery = 0;
        int playerbomb;
        int bombrad;
        int bombx;
        int bomby;
        int hit = 0;
        int invun;
        int hits;
        int passoverdata;
        Danmaku_Character PlayerChar = Danmaku_Character.Moeman;

        public void SetChar(Danmaku_Character Char)
        {
            PlayerChar = Char;
        }

        public Danmaku_Character GetChar()
        {
            return PlayerChar;
        }


        public void SetInvun(int number)
        {
            invun = number;
        }

        public void SetPass(int number)
        {
            passoverdata = number;
        }

        public int GetPass()
        {
           return passoverdata;
        }

        public void SetData(int x, int y)
        {
            playerx = x;
            playery = y;
        }

        public void SetHit(int number)
        {
            hit = number;
        }

        public void IncEnemyHit(int number)
        {
            hits += number;
        }

        public void ResetEnemyHit()
        {
            hits = 0;
        }

        public void SetBomb(int number, int rad)
        {
            if (playerbomb == 0)
            {
                bombx = playerx;
                bomby = playery;
            }
            playerbomb = number;
            bombrad = rad;

        }

        public int GetBomb()
        {
            return playerbomb;
        }

        public int GetEnemyHit()
        {
            return hits;
        }

        public int GetInvun()
        {
            return invun;
        }

        public int GetBombRadius()
        {
            return bombrad;
        }

        public Vector2 GetBombVector()
        {
            return new Vector2(bombx, bomby);
        }

        public void SetTempVector(int x, int y)
        {
            Tempvect.X = x;
            Tempvect.Y = y;
        }

        public float GetTempX()
        {
            return Tempvect.X;
        }

        public float GetTempY()
        {
            return Tempvect.Y;
        }

        public Vector2 GetData()
        {
            return new Vector2(playerx, playery);
        }

        public int GetHit()
        {
            return hit;
        }
    }
}
