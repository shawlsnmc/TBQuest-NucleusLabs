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
    public class Cat : NPC, ISpeak
    {
        private List<String> _Messages = new List<String>();
        private Controller _controller;

        public Controller controller
        {
            get
            {
                return _controller;
            }
            set
            {   
                //make sure we get a controller reference before subscribing to events
                _controller = value;

                //subscribe to our event
                controller.GiveItemEvent += this.onGiveItem;
            }
        }

        public List<String> Messages
        {
            get { return _Messages; }
            set { _Messages = value; }
        }
        
        public Dictionary<int, string> SecretMessages = new Dictionary<int, string>();
        
        public bool HasCatnip { get; set; }
        public bool CanFollowPlayer { get; set; }
        public bool IsFollowingPlayer { get; set; }

        public string Speak() {
            Random rand = new Random();
            string Message = "Meow?";
            if (this.HasCatnip == true)
            {
                SecretMessages.TryGetValue(this.LocationID, out Message);
                if (Message == null)
                {
                    Message = "Meow?";
                }
                this.HasCatnip = false;
            }
            else
            {
                int messageIndex = rand.Next(0, Messages.Count());
                Message = Messages[messageIndex];
            }



            return Message;
        }

        

        public override void onGiveItem(object source, GameObject gameObject, Character recipient)
        {
            if (recipient == this)
            {
                //handle item
                if ((gameObject as UsefulItem).UsefulItemID == 2)
                {
                    //We Got Catnip!!!
                    this.HasCatnip = true;

                }
            }
        }
    }
}
