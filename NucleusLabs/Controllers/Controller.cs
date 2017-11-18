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
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Player _gamePlayer;
        private Player _gameAI;
        private bool _playingGame;
        private GameMap _gameMap;
        private Universe _universe;
        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

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

        #endregion

        #region METHODS

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


            if (false)
            { // set to true to show start screens

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
                _playingGame = true;
                InitializeMission(true);
            }
            //
            // prepare game play screen
            //
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(_gamePlayer.LocationID, _gameMap), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));

            //
            // game loop
            //
            while (_playingGame)
            {
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
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(_gamePlayer.LocationID, _gameMap), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                        break;

                    case PlayerAction.Exit:
                        _playingGame = false;
                        break;

                    case PlayerAction.TravelNorth:
                        //bool temp = (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.North));

                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.North)){
                            _gamePlayer.TravelTo(_gameMap.GetTravelLocation(_gamePlayer.LocationID, GameMap.Direction.North),_gameMap);
                            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(_gamePlayer.LocationID, _gameMap), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                            
                        }
                        else
                        {
                            //can't travel here
                        }
                        break;
                    case PlayerAction.TravelSouth:
                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.South)){
                            _gamePlayer.TravelTo(_gameMap.GetTravelLocation(_gamePlayer.LocationID, GameMap.Direction.South),_gameMap);
                            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(_gamePlayer.LocationID, _gameMap), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                            
                        }
                        else
                        {
                            //can't travel here
                        }
                        break;
                    case PlayerAction.TravelEast:
                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.East)){
                            _gamePlayer.TravelTo(_gameMap.GetTravelLocation(_gamePlayer.LocationID, GameMap.Direction.East), _gameMap);
                            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(_gamePlayer.LocationID, _gameMap), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                            
                        }
                        else
                        {
                            //can't travel here
                        }
                        break;
                    case PlayerAction.TravelWest:
                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.West)){
                            _gamePlayer.TravelTo(_gameMap.GetTravelLocation(_gamePlayer.LocationID, GameMap.Direction.West), _gameMap);
                            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(_gamePlayer.LocationID, _gameMap), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                            
                        }
                        else
                        {
                            //can't travel here
                        }
                        break;
                    case PlayerAction.TravelUp:
                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.Up)){
                            _gamePlayer.TravelTo(_gameMap.GetTravelLocation(_gamePlayer.LocationID, GameMap.Direction.Up), _gameMap);
                            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(_gamePlayer.LocationID, _gameMap), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                            
                        }
                        else
                        {
                            //can't travel here
                        }
                        break;
                    case PlayerAction.TravelDown:
                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.Down)){
                            _gamePlayer.TravelTo(_gameMap.GetTravelLocation(_gamePlayer.LocationID, GameMap.Direction.Down), _gameMap);
                            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(_gamePlayer.LocationID, _gameMap), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                            
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

        #endregion
    }
}
