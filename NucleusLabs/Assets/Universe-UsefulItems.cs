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
            GameObjects.Add(new UseFulItem
            {
                ObjectID = this.LastID,
                LocationID = 641,
                Name = "Ladder",
                Description = "8ft rusty ladder laying on the floor. It looks very sturdy but also very heavy",
                Consumable = false,
                CanAddToInventory = true,
                Weight = 50,
                XP = 50
            });
        }

    }
}
