using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    class DoorLock : UsefulItem
    {
        public bool IsUnlocked { get; set; }
        public int LockCode { get; set; }
        public int Room { get; set; }
        public GameMap.Direction direction {get; set;}

    }
}
