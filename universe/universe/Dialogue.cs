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
     static class Dialogue
    {

         public static void charentrance(SpriteBatch spriteBatch, int character)
         {
             spriteBatch.Draw(Game1.dialogue, new Vector2(0, 380), Color.White);

             if (character == 1)
             {
                 spriteBatch.DrawString(Game1.Arial, "The Moe has arrived.", new Vector2(10, 400), Color.White);
             }
             if (character == 2)
             {
                 spriteBatch.DrawString(Game1.Arial, "Fighting isn't my job, its my duty!", new Vector2(10, 400), Color.White);
             }
             if (character == 3)
             {
                 spriteBatch.DrawString(Game1.Arial, "Prepare to face my danmaku! ", new Vector2(10, 400), Color.White);
             }
             if (character == 4)
             {
                 spriteBatch.DrawString(Game1.Arial, "Knowledge is mine to protect. ", new Vector2(10, 400), Color.White);
             }
             if (character == 5)
             {
                 spriteBatch.DrawString(Game1.Arial, "Monkey! Smash! ", new Vector2(10, 400), Color.White);
             }
             if (character == 6)
             {
                 spriteBatch.DrawString(Game1.Arial, "All is fair, in survival of the fittest. ", new Vector2(10, 400), Color.White);
             }
             if (character == 7)
             {
                 spriteBatch.DrawString(Game1.Arial, "You Really Grind my gears! ", new Vector2(10, 400), Color.White);
             }
             if (character == 8)
             {
                 spriteBatch.DrawString(Game1.Arial, "I shall never falter. ", new Vector2(10, 400), Color.White);
             }
             if (character == 9)
             {
                 spriteBatch.DrawString(Game1.Arial, "I live only to serve. ", new Vector2(10, 400), Color.White);
             }
             if (character == 10)
             {
                 spriteBatch.DrawString(Game1.Arial, "i dont have a name yet. ", new Vector2(10, 400), Color.White);
             }
             if (character == 11)
             {
                 spriteBatch.DrawString(Game1.Arial, "i wish i had a name. ", new Vector2(10, 400), Color.White);
             }
             if (character == 12)
             {
                 spriteBatch.DrawString(Game1.Arial, "I'll make you proud father. ", new Vector2(10, 400), Color.White);
             }
         }


         public static void tuturialtext(SpriteBatch spriteBatch, int tutorial)
         {

             spriteBatch.Draw(Game1.dialogue, new Vector2(0, 380), Color.White);

             if (tutorial == 1)
             {
                 spriteBatch.DrawString(Game1.Arial, "Kagami V2.0: Welcome back Moe. ", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 2)
             {
                 spriteBatch.DrawString(Game1.Arial, "Kagami V2.0: Its time for your medical check. ", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 3)
             {
                 spriteBatch.DrawString(Game1.Arial, "Kagami V2.0: Please walk over to the med lab when you're ready. ", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 4)
             {
                 spriteBatch.DrawString(Game1.Arial, "[Move your character using the Left and Right arrow keys] ", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 5)
             {
                 spriteBatch.DrawString(Game1.Arial, "Kagami V2.0: Give me a second to start the scan.", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 6)
             {
                 spriteBatch.DrawString(Game1.Arial, "[You can cycle through avaliable characters using the Up and Down arrow keys] ", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 7)
             {
                 spriteBatch.DrawString(Game1.Arial, "[You can interact with objects using the X key.] ", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 8)
             {
                 spriteBatch.DrawString(Game1.Arial, "Kagami V2.0: the Scanner is turned on, could you please perfom a jump.", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 9)
             {
                 spriteBatch.DrawString(Game1.Arial, "[You can jump using the Space Button.] ", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 10)
             {
                 spriteBatch.DrawString(Game1.Arial, "Kagami V2.0: Okay, everything looks fine here. Can you try Sprinting?", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 11)
             {
                 spriteBatch.DrawString(Game1.Arial, "[You can activate sprinting by holding down the C key.] ", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 12)
             {
                 spriteBatch.DrawString(Game1.Arial, "Kagami V2.0: It seems your stamina isn't as good as it used to be.", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 13)
             {
                 spriteBatch.DrawString(Game1.Arial, "Kagami V2.0: But overall, you're in good health.", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 14)
             {
                 spriteBatch.DrawString(Game1.Arial, "Kagami V2.0: We're done here, so lets head to the bridge.", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 15)
             {
                 spriteBatch.DrawString(Game1.Arial, "Kagami V2.0: Oh Dear, it seems there is a crate in our way.", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 16)
             {
                 spriteBatch.DrawString(Game1.Arial, "[You can attack enemies and objects using the Z key].", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 17)
             {
                 spriteBatch.DrawString(Game1.Arial, "Kagami V2.0: Shit, we've been breached, quick close the shutters on the window!", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 18)
             {
                 spriteBatch.DrawString(Game1.Arial, "Kagami V2.0: With that dealth with, lets carry on.", new Vector2(10, 400), Color.White);
             }
             if (tutorial == 19)
             {
                 spriteBatch.DrawString(Game1.Arial, "Kagami V2.0: The Co-ordinates for our next launch are ready,", new Vector2(10, 400), Color.White);
                 spriteBatch.DrawString(Game1.Arial, "             so activate the console when you wish you leave.", new Vector2(10, 412), Color.White);
             }
         }


         public static void level1text(SpriteBatch spriteBatch, int tutorial)
         {

             spriteBatch.Draw(Game1.dialogue, new Vector2(0, 380), Color.White);
         }





         public static void npc_chat(SpriteBatch spriteBatch, int dialogue)
         {

             if (dialogue == 1)
             {
                 spriteBatch.DrawString(Game1.Arial, "Bunny Girl: Sorry big boy, not now, its my break.", new Vector2(10, 400), Color.White);
             }

             if (dialogue == 2)
             {
                 spriteBatch.DrawString(Game1.Arial, "Bunny Girl: One Fizzwangal Delight coming right up sir.", new Vector2(10, 400), Color.White);
             }

             if (dialogue == 3)
             {
                 spriteBatch.DrawString(Game1.Arial, "Soldier: No citizens allowed beyond this point.", new Vector2(10, 400), Color.White);
             }

             if (dialogue == 4)
             {
                 spriteBatch.DrawString(Game1.Arial, "Soldier: Turn back, citizen.", new Vector2(10, 400), Color.White);
             }

         }
    }
}
