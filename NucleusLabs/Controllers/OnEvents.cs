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
            UpdatePlayerInventoryWeight();
        }


        //end Define Events

        //OnEvents / psedo events

        public void OnItemPickUp(GameObject gameObject, int LocationID)
        {
            UpdatePlayerInventoryWeight();
            if (gameObject is UsefulItem)
            {
                UsefulItem usefulGameObject = gameObject as UsefulItem;
                //If gameObject grants XP then add to player
                if (usefulGameObject.XP != 0)
                {
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
            UpdatePlayerInventoryWeight();
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
                

            }
        }
        public void OnPlayerTravel(GameMap.Direction Dir)
        {
            int TravelToLocation = _gameMap.GetTravelLocation(_gamePlayer.LocationID, Dir);
            _gamePlayer.TravelTo(TravelToLocation, _gameMap);
            ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
            _gameSounds.GameSounds.Where(b => b.Name == "FootSteps").First().Play();
            if (TravelToLocation == 566)
            {
                //Player beat game
                _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.YouWon(_gamePlayer.Name, _gameAI.Name), ActionMenu.MissionIntro, "");
                _gameConsoleView.GetContinueKey();
                _playingGame = false;
            }
            else
            {
                _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_gamePlayer.LocationID, _gameMap, _universe), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
            }
        }
        public void OnItemConsume(GameObject gameObject)
        {
            UpdatePlayerInventoryWeight();
        }
        public void OnPlayerTravelFail()
        {
            _gameSounds.GameSounds.Where(b => b.Name == "FootSteps").First().Stop();
            if (_gamePlayer.Gender == Player.Genders.Male)
            {

                _gameSounds.GameSounds.Where(b => b.Name == "OofMale").First().PlayLoop();
            }
            else if(_gamePlayer.Gender == Player.Genders.Female)
            {
                _gameSounds.GameSounds.Where(b => b.Name == "OofFemale").First().Play();
            }
        }
    }
}
