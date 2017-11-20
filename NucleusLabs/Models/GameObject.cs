using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    public class GameObject
    {
        public int ObjectID { get; set; }
        public int LocationID { get; set; } // -1 for player1 inventory, -2 for player2, 0 for removed from game
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Consumable { get; set; }
        public virtual bool CanAddToInventory { get; set; }
        public virtual double Weight { get; set; }



    }




}
