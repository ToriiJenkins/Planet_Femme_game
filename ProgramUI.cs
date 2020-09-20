using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Femme
{
    public class ProgramUI
    {
        public enum Item { codex, healer, coms, transporter };
       // public enum AlienBeing { mroxx, taranja};

        public List<Item> inventory = new List<Item>();

      /*  Dictionary<string, AlienBeing> Aliens = new Dictionary<string, AlienBeing>
        {
            {"mroxx", mroxx},
            {"taranja", taranja }
        }; */

        Dictionary<string, Location> Locations = new Dictionary<string, Location>
        {
            {"gertie", gertie },
            {"crew quarters", crewquarters },
            {"planet surface", planetsurface },
            {"alien dwelling 1", aliendwelling1 }, 
            {"alien dwelling 2", aliendwelling2 }
        };

        public static Location gertie = new Location(
            "\n\n\n\n\n You are inside your ship. You call her gertie. She is small but sturdy.\n\n" +
            "You may take the path to the crew quarters or out to the planet surface.\n",
            new List<string> { "planet surface", "crew quarters" },
            new List<Item> { Item.coms },
            "+-------------+\n" +
            "|| com device ||\n" +
            "|| XX         ||\n" +
            "|| XXXXXX     ||\n" +
            "||            ||\n" +
            "|| XXXXX      ||\n" +
            "|--------------|\n" +
            "| -----------+ |\n" +
            "||  ||  |   |  |\n" +
            "||  ||  |   |  |\n" +
            "|+----+ +---+  |\n" +
            "|    |  |      |\n" +
            "|    +--+      |\n" +
            "|+------------+|\n",
            new List<AlienBeing> { }
            );

        public static Location crewquarters = new Location(
            "\n\n\n\n\n You are inside your personal quarters. It is a plain space with nothing spectacular.\n\n" +
            "The only personal touch is a succulent from planet Earth on the table next to the bed.\n\n" +
            "It's not much but it's home.\n\n" +
            "You may go back to gertie.\n\n",
            new List<string> { "gertie" },
            new List<Item> { Item.codex },
            "+X-X-----+\n" +
            "| XXX    | \n" +
            "|        |\n" +
            "| CODEX  |\n" +
            "|        |\n" +
            "|        |\n" +
            "| XXX    |\n" +
            "+X -XX---x\n",
            new List<AlienBeing> { }
            );

        public static Location planetsurface = new Location(
            "\n\n\n\n\n You are the first human to set foot on the Planet Femme!\n\n" +
            "The planet is lush and green. You spot a few hut looking structures that are alien dwellings.\n\n" +
            "You are able to go back into gertie or into alien dwelling 1.\n\n",
            new List<string> { "gertie", "alien dwelling 1" },
            new List<Item> { },
            "",
            new List<AlienBeing> { }
            );

        public static Location aliendwelling1 = new Location(
            "\n\n\n\n You are in the home of a planet resident.\n\n" +
            "You see a door leading back outside or a hallway that seems to lead to alien dwelling 2.",
            new List<string> { "planet surface", "alien dwelling 2" },
            new List<Item> { Item.healer },
            "+-----+ XXX \n" +
            "+ -----+XXX \n" +
            "| h | \n" +
            "| e | \n" +
            "| a | \n" +
            "| l | \n" +
            "+----+ \n",
            new List<AlienBeing> { mroxx }
            );

        public static Location aliendwelling2 = new Location(
            "\n\n\n\n You have entered a second dwelling.\n\n" +
            "The only exit you see is the hallway back to the first dwelling",
            new List<string> { "alien dwelling 1" },
            new List<Item> { Item.transporter },
            "  ++ \n" +
            "  || \n" +
            "+------+  \n" +
            "| X | ----|  \n" +
            "| | -| X ||  \n" +
            "|transport|  \n" +
            "+---------",
            new List<AlienBeing> {}
            );

        public static AlienBeing mroxx = new AlienBeing("Mroxx", "This being is similar to Tarranja. Her stature is small and slender, her skin seems to be a lighter, and her eyes are teal. ",  "Welcome to my home, human. My gift to you is this healer. \n" +
            "You may find our planet to be a bit more dangerous than  your own, and end up needing it.");

        public static AlienBeing tarranja = new AlienBeing("Taranja", "The being you see is tall and has beautiful dark purple skin and emerald green eyes.", "Hello, I am tarranja. I hope you enjoy Femme! It is our custom to give a gift that may assist you in your travels.\n\n");
            
        

                
            


        public void Run()
        {
            Location currentLocation = gertie;
            bool foundpath = false;

            Console.Clear();
            Console.WriteLine("You have just landed your beloved ship on a new planet.\n" +
                "Us humans call this planet Femme.");
            bool alive = true;

            Console.WriteLine(currentLocation.Splash);
            Console.WriteLine(currentLocation.ItemImage);
            
           


            while (alive)
            {
                string command = Console.ReadLine().ToLower();
                //Console.Clear();

                if(command.StartsWith("go " ) || command.StartsWith("path "))
                { 
                    foreach (string path in currentLocation.Paths)
                    {
                        if (command.Contains(path) && Locations.ContainsKey(path))
                        {
                            currentLocation = Locations[path];
                            foundpath = true;
                            break;
                        }
                    }
                    if(!foundpath)
                    {
                        Console.WriteLine("You cannot follow that path");
                    }
                }//go and paths If statement
                else if (command.StartsWith("get") || command.StartsWith("take") || command.StartsWith("pick up"))
                {
                    bool foundItem = false;
                    foreach (Item item in currentLocation.Items)
                    {
                        if(!foundItem && command.Contains(item.ToString()))
                        {
                            Random rand = new Random();
                            int flavorTextChoice = rand.Next(0, 3);
                            string flavorText;
                            switch (flavorTextChoice)
                            {
                                case 0:
                                    flavorText = "That is interesting. What do you think it does?";
                                    break;
                                case 1:
                                    flavorText = "That looks verrrry breakable, be careful.";
                                    break;
                                case 2:
                                    flavorText = "Do you think it is edible?";
                                    break;
                                default:
                                    flavorText = "Nice.";
                                    break;
                            }//switch

                            Console.WriteLine($"You found a(n) {item}. {flavorText} " +
                                "Press any key to continue...");
                            currentLocation.ItemImage = "";
                            currentLocation.RemoveItem(item);
                            inventory.Add(item);
                            foundItem = true;
                            Console.ReadKey();
                            break;
                        }//if foundItem != false
                    }//foreach
                    if (!foundItem)
                    {
                        Console.WriteLine("Hmm... I am not sure what you may be referring to.");
                    }
                }//get take pickup else if
                else if (command.StartsWith("use") || command.StartsWith("activate"))
                {
                    Console.WriteLine("I am pretty sure you do not know what you are doing.");
                }
                else
                {
                    Console.WriteLine("What? Ooohhh, look at that shiny thing.");
                }

                Console.WriteLine(currentLocation.Splash);
                Console.WriteLine(currentLocation.ItemImage);
            }//while

        }// run method

    }//ProgramUI Class
}//namespace
