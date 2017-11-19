using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    public partial class Universe
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

            //Useless Items
            for (int i = 0; i < 200; i++)
            {
                int itemID = rand.Next(0, UselessItemNames.Count);
                GameObjects.Add( new UselessItem {
                    ObjectID = this.LastID,
                    LocationID = (rand.Next(1, 7) * 100) + (rand.Next(1, 7) * 10) + rand.Next(1, 7),
                    Name = UselessItemNames[itemID],
                    Description = UselessItemDescriptions[itemID],
                    Consumable = false,
                    CanAddToInventory = true
                });
            }

            //Consumables Items
            for (int i = 0; i < 200; i++)
            {
                int itemID = rand.Next(0, ConsumableItemNames.Count);
                GameObjects.Add(new ConsumableItem
                {
                    ObjectID = this.LastID,
                    LocationID = (rand.Next(1, 7) * 100) + (rand.Next(1, 7) * 10) + rand.Next(1, 7),
                    Name = ConsumableItemNames[itemID],
                    Description = ConsumableItemDescriptions[itemID],
                    Consumable = true,
                    CanAddToInventory = true,
                    HealthPoints = ConsumableItemhealthpoints[itemID]
                });
            }

            //this.GameObjects.Add(new GameObject { })


        }
    }
}
