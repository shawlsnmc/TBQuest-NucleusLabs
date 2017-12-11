using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NucleusLabs
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public partial class Controller
    {


        private ConsoleView _gameConsoleView;
        private Player _gamePlayer;
        private Player _gameAI;
        private bool _playingGame;
        private GameMap _gameMap;
        public Universe _universe;
        public Sounds _gameSounds;

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
            _gameSounds = new Sounds();
            _gamePlayer = new Player();
            _gameAI = new Player();
            _gameMap = new GameMap();
            _universe = new Universe(this);
            _gameConsoleView = new ConsoleView(_gamePlayer, _gameMap, _universe);
            _playingGame = true;
            Console.CursorVisible = false;
                
             
        
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            PlayerAction PlayerActionChoice = PlayerAction.None;

            bool skipintro = false; // set to true to show start screens
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
                ActionMenu.currentMenu = ActionMenu.CurrentMenu.MissionIntro;
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
            ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_gamePlayer.LocationID, _gameMap, _universe), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));

            //
            // game loop
            //
            while (_playingGame)
            {

                //Make sure player is still alive.
                //This needs to be moved to an OnHealthChange event...
                if (_gamePlayer.Health == 0)
                {
                    //dead player
                    _gameConsoleView.GetContinueKey();
                    ActionMenu.currentMenu = ActionMenu.CurrentMenu.MissionIntro;
                    _gameConsoleView.DisplayGamePlayScreen("YOU DIED!!!", Text.YouDied(_gamePlayer, _gameAI), ActionMenu.MissionIntro, "");
                    _gameConsoleView.GetContinueKey();
                    Environment.Exit(1);
                }else if (_gamePlayer.Health < 25)
                {
                    //    _universe.GameSounds.Where(b => b.Name == "HealthAlert").First().PlayLoop();
                    if (_gamePlayer.Gender == Player.Genders.Female)
                    {
                        _gameSounds.FemaleBreathing.Play();
                    }
                    else
                    {
                        _gameSounds.MaleBreathing.Play();
                    }
                    
                    //}
                    //else if (_universe.GameSounds.Where(b => b.Name == "HealthAlert").First().isLooping)
                    //{
                    //    _universe.GameSounds.Where(b => b.Name == "HealthAlert").First().Stop();

                    
                }


                //
                // get next game action from player
                //

                switch (ActionMenu.currentMenu)
                {
                    case ActionMenu.CurrentMenu.MainMenu:
                        PlayerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu, true);
                        break;
                    case ActionMenu.CurrentMenu.InventoryMenu:
                        PlayerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.InventoryMenu, true);
                        break;
                    case ActionMenu.CurrentMenu.InteractMenu:
                        PlayerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.InteractMenu, true);
                        break;
                    default:
                        break;
                }

                //
                // choose an action based on the player's menu choice
                //
                switch (PlayerActionChoice)
                {
                    case PlayerAction.None:
                        break;

                    case PlayerAction.PlayerInfo:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayPlayerInfo();
                        break;

                    case PlayerAction.LookAround:
                    case PlayerAction.ReturnToMain:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_gamePlayer.LocationID, _gameMap, _universe), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                        break;

                    // case PlayerAction.Admin:
                    //     ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                    //     _gameConsoleView.DisplayGamePlayScreen("Admin Stuff", Text.AdminInfo(_gamePlayer.LocationID, _gameMap, _universe), ActionMenu.MainMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                    //     break;

                    case PlayerAction.LookAt:
                        if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.MainMenu)
                        {
                            this.LookAtAction(_universe.GameObjects.Where(b => b.LocationID == _gamePlayer.LocationID), ActionMenu.MainMenu);
                        }
                        else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.InventoryMenu)
                        {
                            this.LookAtAction(_universe.GameObjects.Where(b => b.LocationID == -1), ActionMenu.InventoryMenu);
                        }

                        break;
                    case PlayerAction.PickUpItem:
                        this.PickUpAction(_gamePlayer.LocationID, ActionMenu.MainMenu);
                        break;

                    case PlayerAction.PutDownItem:
                        this.PutDownAction(_gamePlayer.LocationID, ActionMenu.InventoryMenu);
                        break;

                    case PlayerAction.ConsumeItem:
                        this.ConsumeAction(ActionMenu.InventoryMenu);
                        break;

                    case PlayerAction.PlayerInventory:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.InventoryMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Player Inventory", Text.PlayerInventory(_universe.GameObjects), ActionMenu.InventoryMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                        break;

                    case PlayerAction.InteractWith:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.InteractMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Interact With", Text.InteractWith(), ActionMenu.InteractMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                        break;

                    case PlayerAction.TalkTo:
                        this.TalkToAction();
                        break;

                    case PlayerAction.GiveTo:
                        this.GiveToAction();
                        break;

                    case PlayerAction.UseObject:
                        this.UseObjectAction();
                        break;

                    case PlayerAction.ExitGame:
                        _playingGame = false;
                        break;

                    case PlayerAction.TravelNorth:
                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.North)) {
                            OnPlayerTravel(GameMap.Direction.North);
                        }
                        else
                        {
                            OnPlayerTravelFail();
                        }
                        break;

                    case PlayerAction.TravelSouth:
                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.South)) {
                            OnPlayerTravel(GameMap.Direction.South);
                        }
                        else
                        {
                            OnPlayerTravelFail();
                        }
                        break;

                    case PlayerAction.TravelEast:
                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.East)) {
                            OnPlayerTravel(GameMap.Direction.East);
                        }
                        else
                        {
                            OnPlayerTravelFail();
                        }
                        break;

                    case PlayerAction.TravelWest:
                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.West)) {
                            OnPlayerTravel(GameMap.Direction.West);
                        }
                        else
                        {
                            OnPlayerTravelFail();
                        }
                        break;

                    case PlayerAction.TravelUp:
                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.Up)) {
                            OnPlayerTravel(GameMap.Direction.Up);
                        }
                        else
                        {
                            OnPlayerTravelFail();
                        }
                        break;

                    case PlayerAction.TravelDown:
                        if (_gameMap.GetTravelDirectionAccessible(_gamePlayer.LocationID, GameMap.Direction.Down)) {
                            OnPlayerTravel(GameMap.Direction.Down);
                        }
                        else
                        {
                            OnPlayerTravelFail();
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
        private void LookAtAction(IEnumerable<GameObject> gameObjects, Menu menu)
        {


            int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectId(gameObjects, menu);

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
                _gameConsoleView.DisplayGameObjectInfo(gameObject, menu);
            }
        }
        private void PickUpAction(int locationID, Menu menu)
        {
            int gameObjectToPickUp = _gameConsoleView.DisplayGetGameObjectId(_universe.GameObjects.Where(b => b.LocationID == locationID && b.CanAddToInventory == true), menu);
            if (gameObjectToPickUp > 0) {
                GameObject gameObject = _universe.GameObjects.Where(b => b.ObjectID == gameObjectToPickUp).First();
                gameObject.LocationID = -1;
                OnItemPickUp(gameObject, locationID);
                _gameConsoleView.DisplayGamePlayScreen("Pick Up Object", $"The object has been added to your inventory.", menu, "");
            }

        }


        private void ConsumeAction(Menu menu)
        {
            int gameObjectToConsume = _gameConsoleView.DisplayGetGameObjectId(_universe.GameObjects.Where(b => b.LocationID == -1 && b.Consumable == true), menu);
            if (gameObjectToConsume > 0)
            {
                GameObject gameObject = _universe.GameObjects.Where(b => b.ObjectID == gameObjectToConsume).First();
                gameObject.LocationID = 0;
                _gamePlayer.Health += (gameObject as ConsumableItem).HealthPoints;
                OnItemConsume(gameObject);
                _gameConsoleView.DisplayGamePlayScreen("Consumed Item", $"You consumed the {gameObject.Name} and it gave you {(gameObject as ConsumableItem).HealthPoints} HP.", menu, "");
            }
        }




        private void PutDownAction(int locationID, Menu menu)
        {
            int gameObjectId = _gameConsoleView.DisplayGetGameObjectId(_universe.GameObjects.Where(b => b.LocationID == -1), menu);
            if (gameObjectId > 0)
            {
                GameObject gameObject = _universe.GameObjects.Where(b => b.ObjectID == gameObjectId).First();
                gameObject.LocationID = locationID;
                OnItemPutDown(gameObject, locationID);
                _gameConsoleView.DisplayGamePlayScreen("Put Down Object", $"The object has been removed from your inventory.", menu, "");

            }
        }


        private void TalkToAction()
        {
            ActionMenu.currentMenu = ActionMenu.CurrentMenu.InteractMenu;

            int Id = _gameConsoleView.DisplayGetGameNPCId(_universe.GameNPCs.Where(b => b.LocationID == _gamePlayer.LocationID), ActionMenu.InteractMenu);
            if (Id > 0)
            {
                ISpeak gameNPC = _universe.GameNPCs.Where(b => b.CharID == Id).First() as ISpeak;
                _gameConsoleView.DisplayGamePlayScreen("Talk To", gameNPC.Speak(), ActionMenu.InteractMenu, "");

            }
            else if (Id == 0) //cancelled selection
            {
                _gameConsoleView.DisplayGamePlayScreen("Interact With", Text.InteractWith(), ActionMenu.InteractMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
            }


        }
        private void GiveToAction()
        {
            ActionMenu.currentMenu = ActionMenu.CurrentMenu.InteractMenu;

            int NPCId = _gameConsoleView.DisplayGetGameNPCId(_universe.GameNPCs.Where(b => b.LocationID == _gamePlayer.LocationID), ActionMenu.InteractMenu);
            int gameObjectId = -1;
            if (NPCId > 0)
            {
                NPC NPC = _universe.GameNPCs.Where(b => b.CharID == NPCId).First() as NPC;
                List<int> NPCAccepts = NPC.AcceptUsefulItems;

                gameObjectId = _gameConsoleView.DisplayGetGameObjectId(_universe.GameObjects.OfType<UsefulItem>().Where(b => NPCAccepts.Contains(b.UsefulItemID) && b.LocationID == -1), ActionMenu.InteractMenu);
                if (gameObjectId > 0)
                {
                    GameObject gameObject = _universe.GameObjects.Where(b => b.ObjectID == gameObjectId).First();
                    //take item from player
                    gameObject.LocationID = 0;

                    // Giving Item to NPC
                    OnItemGiveEvent(gameObject, NPC);

                    //reset screen..
                    _gameConsoleView.DisplayGamePlayScreen("Interact With", Text.InteractWith(), ActionMenu.InteractMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));

                }

            }
            
            if(NPCId == 0 || gameObjectId == 0)//cancelled selection
            {
                _gameConsoleView.DisplayGamePlayScreen("Interact With", Text.InteractWith(), ActionMenu.InteractMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
            }
        }

        private void UpdatePlayerInventoryWeight()
        {
            double weight = 0;
            foreach (GameObject gameObject in _universe.GameObjects.Where(b => b.LocationID == -1)) 
            {
                weight += gameObject.Weight;
            }
            _gamePlayer.InventoryWeight = weight;

        }

        private void UseObjectAction()
        {
            ActionMenu.currentMenu = ActionMenu.CurrentMenu.InteractMenu;

            int ObjectID = _gameConsoleView.DisplayGetGameObjectId(_universe.GameObjects.OfType<UsefulItem>().Where(b => b.LocationID == _gamePlayer.LocationID && (b as UsefulItem).CanInteractWith == true), ActionMenu.InteractMenu);
            
            if (ObjectID > 0)
            {
                GameObject GameObject = _universe.GameObjects.Where(b => b.ObjectID == ObjectID).First();
                
                switch (GameObject.GetType().Name)
                {
                    case "DoorLock":
                        int lockCode;
                        _gameConsoleView.DisplayGamePlayScreen("Interact With Door Lock", "Industrial Digial Door Lock System\nPlease enter your door lock code below", ActionMenu.InteractMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                        string temp = (GameObject as DoorLock).LockCode.ToString();
                        _gameConsoleView.GetInteger("Enter Door Lock Code: "+temp, 100000, 999999, out lockCode);
                        if ((GameObject as DoorLock).LockCode == lockCode)
                        {
                            string text = "";
                            if ((GameObject as DoorLock).IsUnlocked== true)
                            {
                                (GameObject as DoorLock).IsUnlocked = false;
                                text = "Code Successful! Door is now locked.";
                            }
                            else
                            {
                                (GameObject as DoorLock).IsUnlocked = true;
                                text = "Code Successful! Door is now unlocked.";
                            }
                            _gameMap.SetLocationLock((GameObject as DoorLock).Room, (GameObject as DoorLock).direction, (GameObject as DoorLock).IsUnlocked);


                            _gameSounds.GameSounds.Where(b => b.Name == "DoorLockSuccess").First().Play();
                            _gameConsoleView.DisplayGamePlayScreen("Interact With Door Lock", text, ActionMenu.InteractMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));

                        }
                        else
                        {
                            _gameSounds.GameSounds.Where(b => b.Name == "DoorLockError").First().Play();
                            _gameConsoleView.DisplayGamePlayScreen("Interact With Door Lock", "Code incorrect.", ActionMenu.InteractMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
                        }
                        break;


                }
                    

                

            }

            if (ObjectID == 0)//cancelled selection
            {
                _gameConsoleView.DisplayGamePlayScreen("Interact With", Text.InteractWith(), ActionMenu.InteractMenu, "", _gameMap.GetAvailableMovement(_gamePlayer.LocationID));
            }

        }


    }
}
