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
    class Story
    {
        
        int enterpressed = 0;
        int storypart = 1;

        public void loop()
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Enter))
            {
                if (enterpressed == 0)
                {
                    storypart++;
                }
                enterpressed = 1;
            }
            else { enterpressed = 0; }


        }

        public void Entropy(SpriteBatch spriteBatch)
        {
            


            spriteBatch.Draw(Game1.black, new Vector2(0,0), Color.White);

            spriteBatch.DrawString(Game1.Nasa, "Devestating Beginings", new Vector2(10, 10), Color.White);
            if (storypart == 1)
            {
                spriteBatch.DrawString(Game1.Arial, "In the year 2025 a new drugged called Eternalis was created, scientists found \nthat it caused massively increased lifespans for mice. It was determined that \nthe drug produced an additional 4000% increase in lifespan. The drug need \nnot be taken on a regular basis, but actually just needed to be ingested once. \nScientists quickly refined the drug and found it produced a near infinite \nlifespan for bacteria. Public influence over the drug pushed forward human \ntesting to the year 2028. After two years of testing, no negative side effects \nwere found in the drug for humans. In 2031 the drug started being sold for \nworldwide use. Prices started extremely high, only the rich could afford the \ndrug at first. However, due to immense public interest and funding, ways to \nproduce the drug quickly and cheaply. Research continued on the drug, and \nit was found that human embryos could be injected with the drug safely. \nAnd thus the first generation of eternal humans were born.", new Vector2(10, 24), Color.White);
                spriteBatch.DrawString(Game1.Arial, "The children who were injected during pregnancy aged a lot slower, however, \nthis meant that they retained their ability to learn for a longer period. These \nchildren grew up to become the greatest scientific minds the human race \nhad ever known. With them at forefront of human development, new \ntechnologies spewed out very quickly. Drugs to cure nearly all known \ndiseases were quickly developed, Computers that could do a trillion \ncalculations in a fraction of a second and machines to probe the deepest \nsecrets of the universe were made.", new Vector2(10, 280), Color.White);
            }
            if (storypart == 2)
            {
                spriteBatch.DrawString(Game1.Arial, "However, by the year 2114 the population of earth had reached 50 billion, \npure globalization had taken front and resources were stretched far too thin. \nA strict one child policy was enacted across the entire globe in an attempt to \ncurb human growth. Food and water were rationed and rolling blackouts \nwere a common occurrence across the planet. The draining resources and \nthe gaps between the eternal and mortal began to grow wider. Riots soon \nbroke out between the eternal humans and those that did not wish to live \nforever.", new Vector2(10, 24), Color.White);
                spriteBatch.DrawString(Game1.Arial, "It was not long before these riots turned into all out global warfare. Resources \nwere stretched even thinner with the war effort claiming the majority of \nfood, water and metals. It was to go down in human history as the most \nviolent and bloodiest war humanity had ever laid their eyes on and the \nbarbarism of both sides towards one each other were beyond the wildest of \nimaginations of even the most sadistic person. It had stretched as far to even \nthe soldiers, consumed by pride, would always carry a spare bullet. After all \nit was better to die there and then, than that to be captured alive. The \nadvanced species that was humans, had retorted back into being simple \nanimals.", new Vector2(10, 190), Color.White);
            }

            if (storypart == 3)
            {
                spriteBatch.DrawString(Game1.Arial, "The scientific community was horrified to what humanity had reverted to \ndespite their best attempts to create the perfect world, their theories of \nutopia crumbling to dust before themselves. They decided that the best \ncourse of action was to evacuate the brightest minds and start anew \nelsewhere in the universe, filtering out the ravage violent animals that \nremained. Many ships were built, all of which were to be launched at once \ncarrying thousands of people. However, the organisers of this great project \ngot word that the non-eternals were preparing to fire the most forbidden of \nweaponry, atomic warheads, who even know after the years of peace was \nstill feared and as deadly as history made them out to be. Technology had \nnot only increased the rate in which food and water was drained but also \nhow easy it was to pull together destructive warheads. They were forced to \nrush their plans and in the end only 187 ships were ever constructed and \nonly 1265 humans escaped the planet alive.", new Vector2(10, 24), Color.White);
                spriteBatch.DrawString(Game1.Arial, "Among them was one Eloise along with her mother and father. She was only \nthree years old when the war started and by the time she fled earth, she was \nonly five. She sat in the corner of the ship with the other children, who \nclapped hand patterns with smiles and discussed many simplistic \nunanswered questions. Surrounded by their mothers who cradled them \ntightly. The fathers crowded around the on-board holoscreen watching the \nfinal news broadcasts from their home.", new Vector2(10, 290), Color.White);

            }

            if (storypart == 4)
            {
                spriteBatch.DrawString(Game1.Arial, "The missiles were fired, and immediately the other side fired, the world's end \nfireworks had begun. News broadcasters could be seen praying, as most \npeople on earth were. Goodbyes, tears, echoed across the planet. Doom was \nwritten across their faces, some tried to evade death in underground \nshelters, barricaded houses. Some simply standing in open fields, hoping for \na quick instantaneous death. Moments later, their wish was fulfilled. The sky \nburned red and the ground was scorched, the seas evaporated and life was \ngone. Nature had taken its course; all the old prophecies of the sins of man \nkilling each other had come to fruition. There's was nothing left of the \nanimals called humans. Simply scarred, broken, and drained relics of their \nlegacy.", new Vector2(10, 24), Color.White);
                spriteBatch.DrawString(Game1.Arial, "The men aboard the ship watched the broadcasts stopped, a moment of \nsilence fell upon those inside. The men rushed to the viewing windows and \nsaw the mushroom clouds spread across earth's surface. They made sure \nthat the women and children could not see what was going on. All they had \never known was gone, but they still had their families, and they made sure \nno harm would come to them.", new Vector2(10, 240), Color.White);
            }

            if (storypart == 4)
            {
                storypart = 1;
                Game1.storysection = 0;
                Game1.gamestate = 1;
            }


        }


        public void TheChase(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Game1.black, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(Game1.Nasa, "The Chase", new Vector2(8, 10), Color.White);
            if (storypart == 1)
            {
                spriteBatch.DrawString(Game1.Arial, "It had been many years since she had left earth with the rest of the survivors. Eloise had grown a \nlot, but she still appeared young thanks to the eternalis drug. She was sitting upon a roof top \nlooking out across of the wondrous city laid out below her. It was a marvel to how quickly the \nhumans had restored civility to their new home, she thought to herself.", new Vector2(8, 24), Color.White);
                spriteBatch.DrawString(Game1.Arial, "Sirens started blazing their screeching sounds, and Eloise was on her feet, running and jumping \nfrom roof top to roof top. She hadn't been caught yet and she wasn't going to be caught after \none bad stint. Along the ground, she could see police cars racing alongside the buildings as she \nran. It wasn't long before the all too familiar sounds of a helicopters swirling blades enveloped \nher hearing. A spray of machine gun fire swept across the roof top just before she jumped. She \nwas lucky that time, but still got clipped by a round.", new Vector2(8, 110), Color.White);
                spriteBatch.DrawString(Game1.Arial, "Outstretching her arm, she went to grab onto the next buildings ledge, but it was too far. She fell \nonto a set of emergency stairs two floors down. The fall sent a searing pain through her left arm, \nand she could feel blood trickling down her top lip. Running up the stairs, she found a crescent \nred door. She ordered her implants to release a dose of adrenaline into her blood and she \nkicked the door clean of its hinges. Taking a quick glance down, she could already see swat \nteams climbing the emergency stairs.\n", new Vector2(8, 230), Color.White);
            }
            if (storypart == 2)
            {
                storypart = 1;
                Game1.storysection = 0;
                Game1.gamestate = 1;
            }
            


        }


    }
}
