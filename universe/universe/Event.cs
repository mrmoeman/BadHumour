using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace universe
{
    class Event
    {

        public int eventstatus = 0;

        public void eventbox(int xa, int ya, int xb, int yb)
        {
            if (Game1.playerdata[0] + 40 > xa && Game1.playerdata[0] + 40 < xb)
            {
                if (Game1.playerdata[1] + 40 > ya && Game1.playerdata[1] + 40 < yb)
                {
                   eventstatus = 1;
                }
            }
        }

        public void eventcharacter(int character)
        {
            if (Game1.playerdata[2] == character)
            {
                eventstatus = 1;
            }
        }

        public void eventcharacteractivate(int xa, int ya, int xb, int yb,int character)
        {
            if (Game1.playerdata[0] + 40 > xa && Game1.playerdata[0] + 40 < xb)
            {
                if (Game1.playerdata[1] + 40 > ya && Game1.playerdata[1] + 40 < yb)
                {
                    if (Game1.playerdata[2] == character)
                    {
                        if (Game1.playerdata[3] == 1)
                        {
                            eventstatus = 1;
                        }
                    }
                }
            }
        }

        public void eventcharacterjump(int character)
        {
            if (Game1.playerdata[2] == character && Game1.playerdata[4]== 1)
            {
                eventstatus = 1;
            }
        }

        public void eventcharacterrun(int character)
        {
            if (Game1.playerdata[2] == character && Game1.playerdata[5] == 2)
            {
                eventstatus = 1;
            }
        }

        public void eventactivate(int xa, int ya, int xb, int yb)
        {
            if (Game1.playerdata[0] + 40 > xa && Game1.playerdata[0] + 40 < xb)
            {
                if (Game1.playerdata[1] + 40 > ya && Game1.playerdata[1] + 40 < yb)
                {
                    if (Game1.playerdata[3] == 1)
                    {
                        eventstatus = 1;
                    }
                }
            }
        }

        public void eventobjectbroken(int objectstatus)
        {
            if (objectstatus <= 0)
            {
                eventstatus = 1;
            }
        }

        public void evententerarea(int area, int areareq)
        {
            if (area == areareq)
            {
                eventstatus = 1;
            }
        }

        public void elevator(int upxa, int upya, int upxb, int upyb, int lwxa, int lwya, int lwxb, int lwyb, int area, int areareq)
        {
            if (area == areareq)
            {
                if (Game1.playerdata[0] + 40 > upxa && Game1.playerdata[0] + 40 < upxb && eventstatus == 0)
                {
                    if (Game1.playerdata[1] + 40 > upya && Game1.playerdata[1] + 40 < upyb)
                    {
                        if (Game1.playerdata[3] == 1)
                        {
                            eventstatus = 1;
                        }
                    }
                }
                if (Game1.playerdata[0] + 40 > lwxa && Game1.playerdata[0] + 40 < lwxb & eventstatus == 0)
                {
                    if (Game1.playerdata[1] + 40 > lwya && Game1.playerdata[1] + 40 < lwyb)
                    {
                        if (Game1.playerdata[3] == 1)
                        {
                            eventstatus = 2;
                        }
                    }
                }

                if (eventstatus == 1)
                {
                    Game1.playerstart[0] = 1;
                    Game1.playerstart[4] = lwxa - 20;
                    Game1.playerstart[5] = lwya;
                }

                if (eventstatus == 2)
                {
                    Game1.playerstart[0] = 1;
                    Game1.playerstart[4] = upxa - 20;
                    Game1.playerstart[5] = upya - 8;
                }

                if (Game1.playerdata[3] == 0)
                {
                    eventstatus = 0;
                }

            }
        }
    }
}
