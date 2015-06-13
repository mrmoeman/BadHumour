using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace universe
{
    public static class Platform_Data
    {
        static float offsetx;
        static float offsety;
        public static int[] playerallowance = new int[20];
        static int levelstart;
        //0 - horizontal
        //1 - jump
        //2 - character change
        //3 - attack
        //4 - sprint
        //5 - other
        //6 - moeman
        //7 - Eloise
        //8 - cirno
        //9 - selli
        //10 - mitchel
        //11 - amelia
        //12 - gaile
        //13 - simon
        //14 - kagami
        //15 - carara
        //16 - klava
        //17 - valetta
        //18 - stamina
        //19 - health
        public static int[] playerdata = new int[16];
        //0 - x
        //1 - y
        //2 - character
        //3 - activate button
        //4 - jumping
        //5 - runon
        //6 - attacking
        //7 - direction
        //8 - left collide
        //9 - right collide
        //10 - bottom collide
        //11 - damage
        //12 - health
        //13 - knockback
        //14 - up collide
        //15 - weather damage


        public static float GetOffsetX()
        {
            return offsetx;
        }

        public static float GetOffsetY()
        {
            return offsety;
        }

        public static void SetOffsetX(int number)
        {
            offsetx = number;
        }

        public static void SetOffsetY(int number)
        {
            offsety = number;
        }

        public static void IncrOffsetX(int number)
        {
            offsetx += number;
        }

        public static void IncrOffsetY(int number)
        {
            offsety += number;
        }

        public static void LevelStart()
        {
            levelstart = 1;
        }

        public static int GetLevelStart()
        {
            return levelstart;
        }

        public static void reset()
        {
            offsetx = 0;
            offsety = 0;
            levelstart = 0;
            for (int i = 0; i < 20; i++){
                playerallowance[i] = 0;
            }
            for (int i = 0; i < 16; i++)
            {
                playerdata[i] = 0;
            }

        }

    }
}
