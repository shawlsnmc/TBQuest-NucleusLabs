using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    public partial class Universe
    {
        private void InitializeNPCs()
        {
            //GameObjects.Add(new UsefulItem
            //{
            //    ObjectID = this.LastID,
            //    LocationID = 641,
            //    UsefulItemID = 1,
            //    Name = "Ladder",
            //    Description = "8ft rusty ladder laying on the floor. It looks very sturdy but also very heavy",
            //    Consumable = false,
            //    CanAddToInventory = true,
            //    Weight = 50,
            //    XP = 50
            //});
            GameNPCs.Add(new Cat
            {
                CharID = this.LastID,
                LocationID = 612,
                Name = "Einstein the Cat",
                AcceptUsefulItems = { 2 },
                HasCatnip = false,
                Messages = { "Meow?", "MEEEEEEoooowoow", "Meowowowowow", "Purrrrrrr", "Meoooow", "Meow Meow Meow" },
                SecretMessages = { { 612, "WTF? I can talk? Hey do you think you could get me more of those cat treats? purrrrease?" } },
                CanFollowPlayer = false,
                IsFollowingPlayer = false,
                controller = _controller
            });

            //The next npc needs to know the lock code..
            string temp =  ((GameObjects.OfType<UsefulItem>().Where(b => b.UsefulItemID == 3).First())as DoorLock).LockCode.ToString();

            GameNPCs.Add(new Cat
            {
                CharID = this.LastID,
                LocationID = 652,
                Name = "Yoda the Cat",
                AcceptUsefulItems = { 2 },
                HasCatnip = false,
                Messages = { "Meow?", "MEEEEEEoooowoow", "Meowowowowow", "Purrrrrrr", "Meoooow", "Meow Meow Meow" },
                SecretMessages = { { 652, "Ball of yarn, Janitor took, Locked in room he did. Door code, "+ temp +" it is." },
                                   { 666, "Brackets on ceiling, you did notice? Put down ladder you should " },
                },
                CanFollowPlayer = true,
                IsFollowingPlayer = false,
                controller = _controller
            });

        }

    }
}
