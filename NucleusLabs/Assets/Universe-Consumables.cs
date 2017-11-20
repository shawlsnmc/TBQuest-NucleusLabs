using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    public partial class Universe
    {
        Dictionary<int, string> ConsumableItemNames = new Dictionary<int, string>()
                {
                    {0, "water bottle" },
                    {1, "health pack" },
                    {2, "moldy cheese"},
                    {3, "jar"},
                    {4, "energy bar"},
                    {5, "grenola bar"},
                    {6, "water bottle"},
                    {7, "water bottle"},
                    {8, "can"},
                    {9, "can"}
                };
        Dictionary<int, string> ConsumableItemDescriptions = new Dictionary<int, string>()
                {
                    {0, "sealed water bottle covered in dust." },
                    {1, "sealed health pack." },
                    {2, "moldy cheese and think, hmmm protein and penicillin, Bonus!"},
                    {3, "jar and it is sealed and full of dried fruit."},
                    {4, "energy bar and find it still sealed."},
                    {5, "grenola bar and it is sealed and chocolate covered!"},
                    {6, "water bottle and find it half full of water."},
                    {7, "water bottle and find it half full of water."},
                    {8, "can and its full of apple sauce."},
                    {9, "can and its full of Mixed fruit."}
                };
        Dictionary<int, int> ConsumableItemhealthpoints = new Dictionary<int, int>()
                {
                    {0, 5},
                    {1, 50},
                    {2, -25},
                    {3, 10},
                    {4, 15},
                    {5, 10},
                    {6, 2},
                    {7, -2},
                    {8, 10},
                    {9, 10}
                };
        Dictionary<int, Double> ConsumableItemWeight = new Dictionary<int, Double>()
                {
                    {0, 1},
                    {1, 5},
                    {2, .2},
                    {3, .5},
                    {4, .1},
                    {5, .1},
                    {6, .5},
                    {7, .5},
                    {8, .5},
                    {9, .5}
                };

    }
}
