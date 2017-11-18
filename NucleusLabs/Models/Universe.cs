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
                    { 0, "Fan" },
                    { 1, "empty pop can" },
                    { 2, "empty toilet paper roll" },
                };
        Dictionary<int, string> UselessItemDescriptions = new Dictionary<int, string>()
                {
                    { 0, "small pink fold up fan with blue flowers all over it." },
                    { 1, "empty pop can that is partly crushed." },
                    { 2, "toilet paper cardboard roll that is falling apart." },
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
