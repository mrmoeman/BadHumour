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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        player player1;
        Story story1;
        public static Texture2D spritesheet;
        public static Texture2D ui;
        public static Texture2D dialogue;
        public static Texture2D crate;
        public static Texture2D level_0_map;
        public static Texture2D level_0_map_front;
        public static Texture2D level_0_two_map_front;
        public static Texture2D level_0_two_a_map;
        public static Texture2D level_0_two_b_map;
        public static Texture2D level_0_two_c_map;
        public static Texture2D level_0_two_d_map;
        public static Texture2D level_0_three_map;
        public static Texture2D level_0_three_map_front;
        public static Texture2D level_0_four_map;
        public static Texture2D level_0_four_map_front;
        public static Texture2D level_0_five_map;
        public static Texture2D level_0_five_map_front;
        public static Texture2D level_1_map;
        public static Texture2D level_1_map_middle;
        public static Texture2D level_1_map_front;
        public static Texture2D level_1_two_map;
        public static Texture2D level_1_two_map_front;
        public static Texture2D xpress;
        public static Texture2D black;
        public static Texture2D wire;
        public static Texture2D npc;
        public static Texture2D phyobj;
        public static Texture2D mine;
        public static Texture2D sexplo;
        public static Texture2D mexplo;
        public static Texture2D ssmoke;
        public static Texture2D lvselect;
        public static Texture2D lvsel;
        public static Texture2D ship;
        public static Texture2D bullet;
        public static Texture2D mbullet;
        public static Texture2D eship;
        public static Texture2D Health_Bar;
        public static Texture2D chardialog;
        public static Texture2D chardialogbox;
        public static Texture2D Dan_R_Menu;
        public static Texture2D Planet_A;
        public static Texture2D Planet_B;

        public static Texture2D Int_Object;
        public static Texture2D Level_One_Back;
        public static Texture2D Level_One_Mid;
        public static Texture2D Level_One_Fore;
        public static Texture2D Level_Two_Back;
        public static Texture2D Level_Two_Mid;
        public static Texture2D Level_Two_Fore;

        public static Texture2D startscreen;

        public static SpriteFont Arial;
        public static SpriteFont Arial_12;
        public static SpriteFont Nasa;
        public static int dialogueplay;
        public static int dialoguenpc;
        public static int[] playerallowance;
        public static int level = 0;
        LvSelect levelselect;

        Danmaku_level Cirno_Boss;
        Platform_Level Tutorial;
        public static Danmaku_Data Dan_Data = new Danmaku_Data();
        public static int[] playerstart;
        public static int[] playerdata;
        public static int storysection = 0;
        public static int boss = 0;
        public static int gamestate = 10; 
        public static Rectangle manboundary;
        public static Rectangle manleftboundary;
        public static Rectangle manrightboundary;
        public static Rectangle manleftmoveboundary;
        public static Rectangle manrightmoveboundary;
        public static Rectangle manbottomboundary;
        public static int reset = 0;
        public static int dan_reset = 0;

        MouseState ms = Mouse.GetState();

        public int mousex;
        public int mousey;
        public int mouseleft;

        int paused = 0;
        int gamestateold;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            player1 = new player();
            story1 = new Story();
            levelselect = new LvSelect();

            Cirno_Boss = new Danmaku_Cirno();
            Tutorial = new Level_One();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spritesheet = Content.Load<Texture2D>("full_sprite");
            npc = Content.Load<Texture2D>("npc_spritesheet");
            ui = Content.Load<Texture2D>("ui");
            dialogue = Content.Load<Texture2D>("dialogue");
            crate = Content.Load<Texture2D>("cratesprite");
            level_0_map = Content.Load<Texture2D>("level_0");
            level_0_map_front = Content.Load<Texture2D>("level_0_front");
            level_0_two_map_front = Content.Load<Texture2D>("level_0_two_front");
            level_0_two_a_map = Content.Load<Texture2D>("level_0_two_a");
            level_0_two_b_map = Content.Load<Texture2D>("level_0_two_b");
            level_0_two_c_map = Content.Load<Texture2D>("level_0_two_c");
            level_0_two_d_map = Content.Load<Texture2D>("level_0_two_d");
            level_0_three_map = Content.Load<Texture2D>("level_0_three");
            level_0_three_map_front = Content.Load<Texture2D>("level_0_three_front");
            level_0_four_map = Content.Load<Texture2D>("level_0_four");
            level_0_four_map_front = Content.Load<Texture2D>("level_0_four_front");
            level_0_five_map = Content.Load<Texture2D>("level_0_five");
            level_0_five_map_front = Content.Load<Texture2D>("level_0_five_front");
            level_1_map = Content.Load<Texture2D>("level_1");
            level_1_map_middle = Content.Load<Texture2D>("level_1_mid");
            level_1_map_front = Content.Load<Texture2D>("level_1_front");
            level_1_two_map = Content.Load<Texture2D>("level_1_two");
            level_1_two_map_front = Content.Load<Texture2D>("level_1_two_front");

            phyobj = Content.Load<Texture2D>("PhyObj");
            mine = Content.Load<Texture2D>("mine");
            sexplo = Content.Load<Texture2D>("explosprite");
            mexplo = Content.Load<Texture2D>("mexplosprite");
            ssmoke = Content.Load<Texture2D>("ssmokesprite");
            lvselect = Content.Load<Texture2D>("lvselectsprite");
            lvsel = Content.Load<Texture2D>("lvsel");

            chardialog = Content.Load<Texture2D>("chardialog");
            chardialogbox = Content.Load<Texture2D>("chardialogbox");

            startscreen = Content.Load<Texture2D>("startscreen");

            //danmaku stuff
            bullet = Content.Load<Texture2D>("bulletsprite");
            Dan_R_Menu = Content.Load<Texture2D>("Dan_rmenu");
            mbullet = Content.Load<Texture2D>("mbullet");
            ship = Content.Load<Texture2D>("ship");
            eship = Content.Load<Texture2D>("ShipSpriteSheet");
            Health_Bar = Content.Load<Texture2D>("health_bar");
            Planet_A = Content.Load<Texture2D>("planet");
            Planet_B = Content.Load<Texture2D>("planet2");

            //platforming
            Int_Object = Content.Load<Texture2D>("i_object");
            Level_One_Back = Content.Load<Texture2D>("level_one_back");
            Level_One_Mid = Content.Load<Texture2D>("level_one_fore");
            Level_One_Fore = Content.Load<Texture2D>("level_one_front");
            Level_Two_Back = Content.Load<Texture2D>("level_two_back");
            Level_Two_Mid = Content.Load<Texture2D>("level_two_mid");
            Level_Two_Fore = Content.Load<Texture2D>("level_two_fore");

            xpress = Content.Load<Texture2D>("xpress_sprite");
            black = Content.Load<Texture2D>("black");
            wire = Content.Load<Texture2D>("wire");
            Arial = Content.Load<SpriteFont>("Arial");
            Arial_12 = Content.Load<SpriteFont>("Arial_12");
            Nasa = Content.Load<SpriteFont>("Nasa");
            playerallowance = new int[20];
            playerstart = new int[7];
            //0 - level started
            //1 - left bound
            //2 - right bound
            //3 - bottom bound
            //4 - player x
            //5 - player y
            //6 - character
            playerdata = new int[14];
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
            playerdata[12] = 100;
            for (int x = 0; x < 20; x++)
            {
                playerallowance[x] = 1;
                //0 - horizontal
                //1 - jump
                //2 - character change
                //3 - attack
                //4 - sprint
                //5 - other
                //6 - moeman
                //7 - kasia
                //8 - cirno
                //9 - cyria
                //10 - mitchel
                //11 - gerbs
                //12 - gaile
                //13 - simon
                //14 - kagami
                //15 - tba
                //16 - tba
                //17 - elizabeth
                //18 - stamina
                //19 - health
            }
            player1.playersetup();


            manboundary = new Rectangle(0, 0, 24, 58);
            manleftboundary = new Rectangle(0, 0, 24, 58);
            manrightboundary = new Rectangle(0, 0, 24, 58);
            manleftmoveboundary = new Rectangle(0, 0, 2, 58);
            manrightmoveboundary = new Rectangle(0, 0, 2, 58);
            manbottomboundary = new Rectangle(0, 0, 24, 2);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            ms = Mouse.GetState();
            mousex = ms.X;
            mousey = ms.Y;
            mouseleft = (int) ms.LeftButton;


           // Arduino_Input.Update();
            
            if (Input.GetEsc() == 1 && gamestate > 0 && paused == 0)
            {
                gamestateold = gamestate;
                paused = 1;
                gamestate = 0;
            }

            if (Input.GetEsc() == 0 && gamestate > 0 && paused == 1)
            {
                paused = 0;
            }



            if (gamestate == 0)
            {
                IsMouseVisible = true;
                if (Input.GetEsc() == 0 && paused == 1)
                {
                    paused = 0;
                }
                if (Input.GetEsc() == 1 && paused == 0)
                {
                    gamestate = gamestateold;
                    paused = 1;
                }
                if (Input.GetEnter() == 1)
                {
                    gamestate = 1;
                    level = 0;
                    storysection = 0;
                    boss = 0;
                    reset = 1;
                    dan_reset = 1;
                }
            }

            if (gamestate == 1)
            {
                IsMouseVisible = true;
                levelselect.update(mousex, mousey, mouseleft);
            }

            if (gamestate == 2)
            {
                IsMouseVisible = false;
                //bosses
                if (boss == 1){
                    if (dan_reset == 1)
                    {
                        Cirno_Boss= new Danmaku_Cirno();
                        dan_reset = 0;
                    }

                    Cirno_Boss.update();
                }

                if (boss == 2)
                {
                    if (dan_reset == 1)
                    {
                        Cirno_Boss = new Danmaku_Gaile();
                        dan_reset = 0;
                    }

                    Cirno_Boss.update();
                }

                //story
                if (storysection > 0)
                {
                    story1.loop();
                }

                if (level > 0)
                {
                    //player1.update();

                    //boundary update
                    manboundary.X = (int)playerdata[0] + 27;
                    manboundary.Y = (int)playerdata[1] + 12;
                    manleftboundary.X = (int)playerdata[0] + 3;
                    manleftboundary.Y = (int)playerdata[1] + 12;
                    manrightboundary.X = (int)playerdata[0] + 51;
                    manrightboundary.Y = (int)playerdata[1] + 12;
                    manleftmoveboundary.X = (int)playerdata[0] + 25;
                    manleftmoveboundary.Y = (int)playerdata[1] + 12;
                    manrightmoveboundary.X = (int)playerdata[0] + 51;
                    manrightmoveboundary.Y = (int)playerdata[1] + 12;
                    manbottomboundary.X = (int)playerdata[0] + 27;
                    manbottomboundary.Y = (int)playerdata[1] + 73;

                    if (level > 0)
                    {
                        Tutorial.update();
                    }




                    if (reset == 1)
                    {
                        Platform_Data.reset();
                        if (level == 1)
                        {
                            Tutorial = new Level_One();
                        }
                        if (level == 2)
                        {
                            Tutorial = new Level_Two();
                        }


                        player1.playerreset();

                        for (int x = 0; x < 20; x++)
                        {
                            playerallowance[x] = 1;
                        }

                        reset = 0;
                    }

                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            if (gamestate == 0)
            {
                spriteBatch.Draw(Game1.black, new Vector2(0, 0), Color.White);
                spriteBatch.DrawString(Game1.Nasa, "Game Paused!", new Vector2(300, 210), Color.White);
                spriteBatch.DrawString(Game1.Nasa, "Press [ESC] to return to game.", new Vector2(210, 240), Color.White);
                spriteBatch.DrawString(Game1.Nasa, "Press [Enter] to return to menu.", new Vector2(200, 270), Color.White);
            }

            if (gamestate == 1)
            {

                spriteBatch.DrawString(Game1.Nasa, mousex + "   " + mousey, new Vector2(120 , 20), Color.White);

                levelselect.draw(spriteBatch);
            }

            if (gamestate == 2)
            {

                //bosses
                if (boss > 0)
                {
                    Cirno_Boss.draw(spriteBatch);
                }

                if (storysection == 1)
                {
                    story1.Entropy(spriteBatch);
                }
                if (storysection == 2)
                {
                    story1.TheChase(spriteBatch);
                }


                if (level > 0)
                {
                    Tutorial.Draw(spriteBatch);
                }

               
                
                
            }

           // Arduino_Input.Draw(spriteBatch);
            //spriteBatch.DrawString(Game1.Nasa, " " + paused, new Vector2(120, 20), Color.White);
            if (gamestate == 10)
            {
                spriteBatch.Draw(Game1.startscreen, new Vector2(0, 0), Color.White);
                if (Input.GetEnter() == 1)
                {
                    gamestate = 1;
                }

            }




            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
