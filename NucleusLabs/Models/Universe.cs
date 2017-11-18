using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    public class Universe
    {

        //
        // list of all space-time locations, game, and NPC objects
        //
        private int _lastID = 0;

        public int LastID
        {
            get { _lastID++; return _lastID; }
        }

        public List<GameObject> GameObjects  = new List<GameObject>();
        
     //   public List<GameObject> GameObjects
     //   {
     //       get { return _gameObjects; }
     //       set { _gameObjects = value; }
     //   }



        Dictionary<int, string> UselessItemNames = new Dictionary<int, string>()
                {
                    {0, "Fan" },
                    {1, "empty pop can" },
                    {2, "empty toilet paper roll" },
                    {3, "Dirty Rag"},
                    {4, "Light bulb"},
                    {5, "Spray paint can"},
                    {6, "Pillow"},
                    {7, "toothbush"},
                    {8, "Hair brush"},
                    {9, "single shoe"},
                    {10, "used gum"},
                    {11, "sock"},
                    {12, "battery"},
                    {13, "marker"},
                    {14, "shirt"},
                    {15, "bag"},
                    {16, "candy wraper"},
                    {17, "baseball cap"},
                    {18, "water bottle"},
                    {19, "energy bar"},
                    {20, "jar"},
                    {21, "firstaid kit"},
                    {22, "scissors"},
                    {23, "teddy bear"},
                    {24, "wooden car"},
                    {25, "can"},
                    {26, "bag"},
                    {27, "bag"},
                    {28, "Doll"},
                    {29, "Wooden Block"},
                    {30, "Wooden Block"},
                    {31, "Wooden Block"},
                    {32, "baseball cap"},
                    {33, "Dirty Rag"},
                    {34, "Stuffed mouse"},
                    {35, "bag"},
                    {36, "can"},
                    {37, "ball of yarn"}

                };
        Dictionary<int, string> UselessItemDescriptions = new Dictionary<int, string>()
                {
                    {0, "small pink fold up fan with blue flowers all over it." },
                    {1, "empty pop can that is partly crushed." },
                    {2, "toilet paper cardboard roll that is falling apart." },
                    {3, "dirty red rag and notice a number sewn into the corner, 742695."},
                    {4, "light bulb and descover that it is burnt out."},
                    {5, "spray paint can and find that it is empty."},
                    {6, "pillow that is falling apart and  faintly writen on it is the number, 843257."},
                    {7, "toothbrush that is very well used and turning green with mold."},
                    {8, "hair brush that is full of light hair."},
                    {9, "single shoe and find  that is falling apart."},
                    {10, "used gum and find a penny stuck in it."},
                    {11, "sock that is now stiff and stinky."},
                    {12, "battery and find it starting to leak and turn green."},
                    {13, "marker and find that it is all dried up."},
                    {14, "shirt and find it full of moth holes and starting to fall apart."},
                    {15, "bag that looks like its full of green mold."},
                    {16, "candy wraper to find nothing inside to eat."},
                    {17, "baseball cap and find a number writen on the inside rim, 513479."},
                    {18, "water bottle and find that it is empty."},
                    {19, "energy bar and  find it is only a wrapper."},
                    {20, "jar and find it empty."},
                    {21, "firstaid kit and find it empty."},
                    {22, "scissors and find them very dull."},
                    {23, "teddy bear and find it falling apart."},
                    {24, "wooden car and see the paint flaking off."},
                    {25, "can and it had beans in it but its empty now."},
                    {26, "bag and find it empty"},
                    {27, "bag and find it full of used tissue papers."},
                    {28, "Doll and she has lost one arm and is very dirty."},
                    {29, "Wooden block and it has the letters L,V, T and Numbers 5, 7, 3"},
                    {30, "Wooden block and it has the letters D,W, F and Numbers 9, 6, 1"},
                    {31, "Wooden block and it has the letters O,R, N and Numbers 2, 4, 8"},
                    {32, "baseball cap and find a number writen on the inside rim, 592318."},
                    {33, "Dirty red rag and notice a number sewn into the corner, 764318."},
                    {34, "Stuffed mouse and it has chew marks on it."},
                    {35, "bag and find catnip in it."},
                    {36, "can and find it is full of cat food."},
                    {37, "ball of yarn and notice some cat fur on it."}

                };



        //
        // default Universe constructor
        //
        public Universe()
        {
            //
            // add all of the universe objects to the game
            // 
            IntializeGameObjects();
        }

        
        /// <summary>
        /// initialize the universe with all of the space-time locations and game objects
        /// </summary>
        private void IntializeGameObjects()
        {
            //create useless game objects
            Random rand = new Random();

            for (int i = 0; i < 200; i++)
            {
                int UselessID = rand.Next(0, UselessItemNames.Count);

                UselessItem item = new UselessItem {
                    ObjectID = this.LastID,
                    LocationID = (rand.Next(1, 7) * 100) + (rand.Next(1, 7) * 10) + rand.Next(1, 7),
                    Name = UselessItemNames[UselessID],
                    Description = UselessItemNames[UselessID],
                    Consumable = false,
                    CanAddToInventory = true
                };



                GameObjects.Add(item);
            }
            

            //this.GameObjects.Add(new GameObject { })

            
        }
    }
}
