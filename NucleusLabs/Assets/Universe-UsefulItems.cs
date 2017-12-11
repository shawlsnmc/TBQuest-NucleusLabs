using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    public partial class Universe
    {
        private void InitializeUsefullGameObjects()
        {
            GameObjects.Add(new UsefulItem
            {
                ObjectID = this.LastID,
                LocationID = 641,
                UsefulItemID= 1, 
                Name = "Ladder",
                Description = "8ft rusty ladder laying on the floor. It looks very sturdy but also very heavy",
                Consumable = false,
                CanAddToInventory = true,
                Weight = 50,
                XP = 50
            });
            GameObjects.Add(new UsefulItem
            {
                ObjectID = this.LastID,
                LocationID = 611,
                UsefulItemID = 2,
                Name = "Catnip",
                Description = "Catnip infused cat treat, sample pack.",
                Consumable = false,
                CanAddToInventory = true,
                Weight = 1,
                XP = 0
            });
            for (int i = 1; i <= 3; i++) //create three more randomly placed.
            {
                GameObjects.Add(new UsefulItem
                {
                    ObjectID = this.LastID,
                    LocationID = 600 + (rand.Next(2, 7) * 10) + rand.Next(1, 7), //place object in random spot on this floor exluding column1 as it could be locked.
                    UsefulItemID = 2,
                    Name = "Catnip",
                    Description = "Catnip infused cat treat, sample pack.",
                    Consumable = false,
                    CanAddToInventory = true,
                    Weight = 1,
                    XP = 0
                });
            }
            GameObjects.Add(new DoorLock
            {
                ObjectID = this.LastID,
                LocationID = 652,
                UsefulItemID = 3,
                Name = "Janitor Closet Door Lock",
                Description = "Digital keypad lock for gaining access to the janitor's closet",
                Consumable = false,
                CanAddToInventory = false,
                Weight = 0,
                XP = 0,
                IsUnlocked = false,
                CanInteractWith = true,
                LockCode = rand.Next(100000,1000000),
                Room = 652,
                direction = GameMap.Direction.West
            });
            GameObjects.Add(new UsefulItem
            {
                ObjectID = this.LastID,
                LocationID = 611,
                UsefulItemID = 4,
                Name = "Map",
                Description = "Blank map and supplies to be used to record your explorations.",
                Consumable = false,
                CanAddToInventory = true,
                Weight = 1,
                XP = 5
            });


            //The next object needs to know the lock code..
            string temp = ((GameObjects.OfType<UsefulItem>().Where(b => b.UsefulItemID == 3).First()) as DoorLock).LockCode.ToString();
            GameObjects.Add(new UsefulItem
            {
                ObjectID = this.LastID,
                LocationID = 600 + (rand.Next(2, 7) * 10) + rand.Next(1, 7), //place object in random spot on this floor exluding column1 as it could be locked.
                UsefulItemID = 0,
                Name = "crumpled up paper",
                Description = $"crumpled up piece of paper with the numbers {temp.Substring(0,3)} written on in. The paper appears to be torn in half down the right hand side.",
                Consumable = false,
                CanAddToInventory = true,
                Weight = 1,
                XP = 5
            });
            GameObjects.Add(new UsefulItem
            {
                ObjectID = this.LastID,
                LocationID = 600 + (rand.Next(2, 7) * 10) + rand.Next(1, 7), //place object in random spot on this floor exluding column1 as it could be locked.
                UsefulItemID = 0,
                Name = "crumpled up paper",
                Description = $"crumpled up piece of paper with the numbers {temp.Substring(3, 3)} written on in. The paper appears to be torn in half down the left hand side.",
                Consumable = false,
                CanAddToInventory = true,
                Weight = 1,
                XP = 5
            });


        }

    }
}
