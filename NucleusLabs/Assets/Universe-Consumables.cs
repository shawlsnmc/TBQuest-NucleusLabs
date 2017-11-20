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
                    {2, "moldy cheese"}

                };
        Dictionary<int, string> ConsumableItemDescriptions = new Dictionary<int, string>()
                {
                    {0, "sealed water bottle covered in dust." },
                    {1, "sealed health pack." },
                    {2, "moldy cheese and think, hmmm protien and penicillin, Bonus!"}
                };
        Dictionary<int, int> ConsumableItemhealthpoints = new Dictionary<int, int>()
                {
                    {0, 5 },
                    {1, 50 },
                    {2, -25}
                };
        Dictionary<int, Double> ConsumableItemWeight = new Dictionary<int, Double>()
                {
                    {0, 2 },
                    {1, 5 },
                    {2, 1 }
                };

    }
}
