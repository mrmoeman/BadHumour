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
    class Platform_Level
    {
        int timer;
        int temp = 1;
        Platform_Player pplayer;
        Platform_Weather Weather;
        NPC N_P_C;
        public Interactive_Object IOBJ;
        public Platform_Collision_Box CollisionBox;
        public List<Platform_Collision_Box> CollisionList = new List<Platform_Collision_Box>();
        public List<Interactive_Object> IObjList = new List<Interactive_Object>();
        public List<NPC> NPCList = new List<NPC>();

        PhyObj OBJ;
        public List<PhyObj> OBJList = new List<PhyObj>();

        public Platform_Level()
        {
            pplayer = new Platform_Player();
            Platform_Data.playerallowance[0] = 1;
            Platform_Data.playerallowance[1] = 1;
            Platform_Data.playerallowance[2] = 1;
            Platform_Data.playerallowance[3] = 1;
            Platform_Data.playerallowance[4] = 1;
            Platform_Data.playerallowance[5] = 1;
            Weather = new Platform_Weather(0, 0, 0, 0, 0);
        }

        public void AddNPC(int x, int y, int chara, int dir, String dia, int layer)
        {
            N_P_C = new NPC(x, y, chara, dir, dia, layer);
            NPCList.Add(N_P_C);
        }

        public void AddCollisionBox(int x, int y, int width, int height)
        {
            CollisionBox = new Platform_Collision_Box(x, y, width, height);
            CollisionList.Add(CollisionBox);
        }

        public void AddLightRain(float XSpeed)
        {
            Weather = new Platform_Weather(4, XSpeed, 4, 1, 1);
        }

        public void AddAcidRain(float XSpeed)
        {
            Weather = new Platform_Weather(20, XSpeed, 4, 2, 1);
        }

        public void AddHeavyRain(float XSpeed)
        {
            Weather = new Platform_Weather(50, XSpeed, 4, 1, 1);
        }

        public void AddObject(int type, int xpos, int ypos, int moveable)
        {
            if (moveable > 0)
            {
                if (type == 1)
                {
                    OBJ = new barrel(xpos, ypos, 1);
                }
                if (type == 2)
                {
                    OBJ = new crate(xpos, ypos, 1);
                }
            }
            else
            {
                if (type == 1)
                {
                    OBJ = new barrel(xpos, ypos);
                }
                if (type == 2)
                {
                    OBJ = new crate(xpos, ypos);
                }
            }
            OBJList.Add(OBJ);

        }

        public void AddDoor(int x, int y, int state, int refnum)
        {
            IOBJ = new I_Obj_Door(x, y, state, refnum);
            IObjList.Add(IOBJ);
        }

        public void AddConsoleA(int x, int y, int state, int refnum)
        {
            IOBJ = new I_Obj_Console(x, y, state, refnum);
            IObjList.Add(IOBJ);
        }

        public void AddConsoleB(int x, int y, int state, int refnum)
        {
            IOBJ = new I_Obj_Console_B(x, y, state, refnum);
            IObjList.Add(IOBJ);
        }

        public void AddBar(int x, int y, int layer)
        {
            IOBJ = new I_Obj_Bar(x, y, layer);
            IObjList.Add(IOBJ);
        }

        public virtual void update()
        {
            timer++;


            CollisionList.ForEach(i =>{
                i.update();
                Weather.CheckCol(i.GetBoundary());
            });
            Weather.update();

            


            if (timer > 480)
            {
                Platform_Data.LevelStart();
                IObjList.ForEach(i => i.update());
                NPCList.ForEach(i => i.update());
                OBJList.ForEach(i => i.update());
                pplayer.update();
            }


           
        }

        public int CheckIObj(int refnum)
        {
            temp = 0;
            IObjList.ForEach(i => 
                {
                    if (i.CheckRef(refnum) == true && i.GetActivated() == true && temp == 0)
                    {
                        temp = 1;
                    } 
                });
            return temp;
        }


        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }

        public virtual void DrawBackground(SpriteBatch spriteBatch)
        {
            IObjList.ForEach(i =>
            {
                if (i.GetLayer() == -1)
                {
                    i.draw(spriteBatch);
                }
            });

        }

        public virtual void DrawMidground(SpriteBatch spriteBatch)
        {
            NPCList.ForEach(i =>
            {
                if (i.GetLayer() == 0)
                {
                    i.draw(spriteBatch);
                }
            });

            IObjList.ForEach(i =>{
                if (i.GetLayer() == 0)
                {
                    i.draw(spriteBatch);
                }
            });

            NPCList.ForEach(i =>
            {
                if (i.GetLayer() == 1)
                {
                    i.draw(spriteBatch);
                }
            });

            pplayer.playerdraw(spriteBatch);

            IObjList.ForEach(i =>
            {
                if (i.GetLayer() == 1)
                {
                    i.draw(spriteBatch);
                }
            });

            OBJList.ForEach(i =>
            {
                    i.draw(spriteBatch);
            });
        }

        public virtual void DrawForeground(SpriteBatch spriteBatch)
        {

            NPCList.ForEach(i =>
            {
                if (i.GetDialogue() == 1)
                {
                    i.Dialogue(spriteBatch);
                }
            });


            IObjList.ForEach(i =>
            {
                if (i.GetLayer() == 2)
                {
                    i.draw(spriteBatch);
                }
            });



            pplayer.playeruidraw(spriteBatch);
            Weather.draw(spriteBatch);

            if (timer <= 480)
            {
                spriteBatch.Draw(Game1.black, new Vector2(0, 0), Color.White);
                spriteBatch.DrawString(Game1.Nasa, "" + "Loading Level", new Vector2(350, 240), Color.White);
            }

        }

    }

    
}
