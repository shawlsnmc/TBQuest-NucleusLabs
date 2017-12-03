using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public abstract class NPC : Character
    {
        private List<int> _AcceptUsefulItems = new List<int>();
        //public abstract Controller controller { get; set; }
        public List<int> AcceptUsefulItems
        {
            get { return _AcceptUsefulItems; }
            set { _AcceptUsefulItems = value; }
        }

        public virtual void onGiveItem(object source, GameObject gameObject, Character recipient)
        {
            
        }
    }
}
