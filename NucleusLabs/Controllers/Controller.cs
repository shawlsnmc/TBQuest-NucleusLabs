using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {


        private ConsoleView _gameConsoleView;
        private Player _gamePlayer;
        private Player _gameAI;
        private bool _playingGame;
        private GameMap _gameMap;
        public Universe _universe;



        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }



        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gamePlayer = new Player();
            _gameAI = new Player();
            _gameConsoleView = new ConsoleView(_gamePlayer);
            _playingGame = true;
            _gameMap = new GameMap();
            _universe = new Universe();
            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            PlayerAction PlayerActionChoice = PlayerAction.None;

            bool skipintro = true; // set to true to show start screens
            if (!skipintro)
            {

                //
                // display splash screen
                //
                _playingGame = _gameConsoleView.DisplaySpashScreen();

                //
                // player chooses to quit
                //
                if (!_playingGame)
                {
                    Environment.Exit(1);
                }

                //
                // display introductory message
                //
                _gameConsoleView.DisplayGamePlayScreen("Mission Intro", Text.GameIntro(), ActionMenu.MissionIntro, "");
                _gameConsoleView.GetContinueKey();

                //
                // initialize the mission Player
                // 
                InitializeMission();
            }
            else
            {
                InitializeMission(true);
            }
            //
            // prepare game play screen
            //
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_gamePlayer.LocationID, _gameMap, _universe.GameObjects), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));

            //
            // game loop
            //
            while (_playingGame)
            {

                //Make sure player is still alive.

                if (_gamePlayer.Health == 0)
                {
                    //dead player
                    _gameConsoleView.GetContinueKey();
                    _gameConsoleView.DisplayGamePlayScreen("YOU DIED!!!", Text.YouDied(_gamePlayer,_gameAI), ActionMenu.MissionIntro, "");
                    _gameConsoleView.GetContinueKey();
                    Environment.Exit(1);
                }

                //
                // get next game action from player
                //
                    PlayerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu, true);

                //
                // choose an action based on the player's menu choice
                //
                switch (PlayerActionChoice)
                {
                    case PlayerAction.None:
                        break;

                    case PlayerAction.PlayerInfo:
                        _gameConsoleView.DisplayPlayerInfo();
                        break;

                    case PlayerAction.LookAround:
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_gamePlayer.LocationID, _gameMap, _universe.GameObjects), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                        break;

                    case PlayerAction.Admin:
                        _gameConsoleView.DisplayGamePlayScreen("Admin Stuff", Text.AdminInfo(_gamePlayer.LocationID, _gameMap, _universe.GameObjects), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                        break;
                    case PlayerAction.LookAt:
                        this.LookAtAction(_gamePlayer.LocationID);

                        break;
                    case PlayerAction.PickUpItem:
                        this.PickUpAction(_gamePlayer.LocationID);
                        break;
                    case PlayerAction.PutDownItem:
                        this.PutDownAction(_gamePlayer.LocationID);
                        break;

                    case PlayerAction.PlayerInventory:

                        break;

                    case PlayerAction.Exit:
                        _playingGame = false;
                        break;

                    case PlayerAction.TravelNorth:
                        //bool temp = (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.North));

                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.North)){
                            _gamePlayer.TravelTo(_gameMap.GetTravelLocation(_gamePlayer.LocationID, GameMap.Direction.North),_gameMap);
                            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_gamePlayer.LocationID, _gameMap, _universe.GameObjects), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                            
                        }
                        else
                        {
                            //can't travel here
                        }
                        break;
                    case PlayerAction.TravelSouth:
                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.South)){
                            _gamePlayer.TravelTo(_gameMap.GetTravelLocation(_gamePlayer.LocationID, GameMap.Direction.South),_gameMap);
                            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_gamePlayer.LocationID, _gameMap, _universe.GameObjects), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                            
                        }
                        else
                        {
                            //can't travel here
                        }
                        break;
                    case PlayerAction.TravelEast:
                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.East)){
                            _gamePlayer.TravelTo(_gameMap.GetTravelLocation(_gamePlayer.LocationID, GameMap.Direction.East), _gameMap);
                            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_gamePlayer.LocationID, _gameMap, _universe.GameObjects), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                            
                        }
                        else
                        {
                            //can't travel here
                        }
                        break;
                    case PlayerAction.TravelWest:
                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.West)){
                            _gamePlayer.TravelTo(_gameMap.GetTravelLocation(_gamePlayer.LocationID, GameMap.Direction.West), _gameMap);
                            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_gamePlayer.LocationID, _gameMap, _universe.GameObjects), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                            
                        }
                        else
                        {
                            //can't travel here
                        }
                        break;
                    case PlayerAction.TravelUp:
                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.Up)){
                            _gamePlayer.TravelTo(_gameMap.GetTravelLocation(_gamePlayer.LocationID, GameMap.Direction.Up), _gameMap);
                            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_gamePlayer.LocationID, _gameMap, _universe.GameObjects), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                            
                        }
                        else
                        {
                            //can't travel here
                        }
                        break;
                    case PlayerAction.TravelDown:
                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.Down)){
                            _gamePlayer.TravelTo(_gameMap.GetTravelLocation(_gamePlayer.LocationID, GameMap.Direction.Down), _gameMap);
                            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_gamePlayer.LocationID, _gameMap, _universe.GameObjects), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                            
                        }
                        else
                        {
                            //can't travel here
                        }
                        break;
                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeMission(bool testdata = false)
        {
            if (testdata)
            {
                _gamePlayer.Name = "Joe";
                _gamePlayer.Gender = Player.Genders.Male;
                _gamePlayer.TravelTo(611, _gameMap);
                _gameAI.Name = "Sue";
                _gameAI.Gender = Player.Genders.Female;
                _gameAI.UpdateLocation(411);
                _gameConsoleView.setPlayingGame();
            }
            else
            {
                Player Player = _gameConsoleView.GetInitialPlayerInfo();
                Player AI = _gameConsoleView.GetInitialAIInfo();
                _gamePlayer.Name = Player.Name;
                _gamePlayer.Gender = Player.Gender;
                _gamePlayer.TravelTo(611, _gameMap);
                _gameAI.Name = AI.Name;
                _gameAI.Gender = AI.Gender;
                _gameAI.UpdateLocation(411);
            }
        }
        private void LookAtAction(int locationID)
        {


           int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectId(_universe.GameObjects.Where(b => b.LocationID == locationID));

            //
            // display game object info
            //
            if (gameObjectToLookAtId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _universe.GameObjects.Where(b => b.ObjectID == gameObjectToLookAtId).First();

                //
                // display information for the object chosen
                //
                _gameConsoleView.DisplayGameObjectInfo(gameObject);
            }
        }
        private void PickUpAction(int locationID)
        {
            int gameObjectToPickUp = _gameConsoleView.DisplayGetGameObjectId(_universe.GameObjects.Where(b => b.LocationID == locationID));
            if (gameObjectToPickUp >= 0) {
                GameObject gameObject = _universe.GameObjects.Where(b => b.ObjectID == gameObjectToPickUp).First();
                if (gameObject.GetType() == typeof(ConsumableItem))
                {
                    //item is a consumable
                    if (gameObject.Consumable == true)
                    {
                        gameObject.LocationID = 0;
                        _gamePlayer.Health += (gameObject as ConsumableItem).HealthPoints;
                        _gameConsoleView.DisplayGamePlayScreen("Consumed Item", $"You consumed the {gameObject.Name} and it gave you {(gameObject as ConsumableItem).HealthPoints} HP.", ActionMenu.MainMenu, "");
                    }
                    else
                    {
                        gameObject.LocationID = -1;
                        _gameConsoleView.DisplayGamePlayScreen("Pick Up Object", $"The object has been added to your inventory.", ActionMenu.MainMenu, "");
                    }
                }
                else
                {
                    gameObject.LocationID = -1;
                    _gameConsoleView.DisplayGamePlayScreen("Pick Up Object", $"The object has been added to your inventory.", ActionMenu.MainMenu, "");
                }
            }
        }

        private void PutDownAction(int locationID)
        {
            int gameObjectId = _gameConsoleView.DisplayGetGameObjectId(_universe.GameObjects.Where(b => b.LocationID == -1));
            if (gameObjectId >= 0)
            {
                GameObject gameObject = _universe.GameObjects.Where(b => b.ObjectID == gameObjectId).First();
                gameObject.LocationID = locationID;
                _gameConsoleView.DisplayGamePlayScreen("Put Down Object", $"The object has been removed from your inventory.", ActionMenu.MainMenu, "");
            }
        }
    }
}
