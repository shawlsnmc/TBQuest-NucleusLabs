using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    public class UsefulItem : GameObject
    {
        public int XP { get; set; }
        public int UsefulItemID { get; set; }
        public bool CanInteractWith { get; set; }

    }
}
