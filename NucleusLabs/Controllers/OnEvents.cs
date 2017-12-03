using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    public partial class Controller
    {


        //Define Events
        public delegate void GiveItemEventHandler(object source, GameObject gameObject, Character recipient);

        public event GiveItemEventHandler GiveItemEvent;

        protected virtual void OnItemGiveEvent(GameObject gameObject, Character recipient)
        {
            GiveItemEvent?.Invoke(this, gameObject, recipient);
        }


        //end Define Events

        //OnEvents / psedo events

        public void OnItemPickUp(GameObject gameObject, int LocationID)
        {
            if (gameObject is UsefulItem)
            {
                UsefulItem usefulGameObject = gameObject as UsefulItem;
                //If gameObject grants XP then add to player
                if (usefulGameObject.XP != 0){
                    _gamePlayer.Xp += usefulGameObject.XP;
                    usefulGameObject.XP = 0;
                }

                switch (usefulGameObject.UsefulItemID)
                {
                    case 1:  //ladder on floor 6
                        if (LocationID == 666)
                        {
                            _gameMap.SetLocationDescription(666, "Walls to the North, East, and South.  The room continues to the West. However, there is a hole in the ceiling that looks like a ladder once hung but only the brackets remain.");
                            _gameMap.SetLocationLock(666, GameMap.Direction.Up, false);
                        }
                        break;

                }

            }

        }


        public void OnItemPutDown(GameObject gameObject, int LocationID)
        {
            if (gameObject is UsefulItem)
            {
                UsefulItem usefulGameObject = gameObject as UsefulItem;

                switch (usefulGameObject.UsefulItemID)
                {
                    case 1:  //ladder on floor 6
                        if (LocationID == 666)
                        {
                            _gameMap.SetLocationDescription(666, "Walls to the North, East, and South.  The room continues to the West. There is a hole in the ceiling with a ladder mounted to the edge of the hole.");
                            _gameMap.SetLocationLock(666, GameMap.Direction.Up, true);
                        }
                        break;

                }
                //

            }
        }

        public void OnItemConsume(GameObject gameObject)
        {


        }
    }
}
