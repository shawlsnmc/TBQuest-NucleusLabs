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
        public List<Character> GameNPCs = new List<Character>();
        private Controller _controller;
        //   public List<GameObject> GameObjects
        //   {
        //       get { return _gameObjects; }
        //       set { _gameObjects = value; }
        //   }

        public Random rand = new Random();





        //
        // default Universe constructor
        //
        public Universe(Controller controller)
        {
            _controller = controller;
            //
            // add all of the universe objects to the game
            // 
            InitializeGameObjects();
            InitializeNPCs();

        }

        
        /// <summary>
        /// initialize the universe with all of the space-time locations and game objects
        /// </summary>
        private void InitializeGameObjects()
        {
            //create useless game objects
            
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
                    CanAddToInventory = true,
                    Weight = UselessItemWeight[itemID]
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
                    HealthPoints = ConsumableItemhealthpoints[itemID],
                    Weight = ConsumableItemWeight[itemID]
                });
            }

            //Useful, one of a kind items
            InitializeUsefullGameObjects();


        }

    }
}
