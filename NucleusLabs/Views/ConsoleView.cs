using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView
    {
        #region ENUMS

        private enum ViewStatus
        {
            PlayerInitialization,
            PlayingGame
        }

        #endregion

        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Player _gamePlayer;

        ViewStatus _viewStatus;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Player gamePlayer)
        {
            _gamePlayer = gamePlayer;

            _viewStatus = ViewStatus.PlayerInitialization;

            InitializeDisplay();
        }

        #endregion

        #region METHODS
        /// <summary>
        /// display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        /// <param name="availableNavigation">array of availible navigation north,south,east,west,up,down</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt, bool[] availableNavigation = null)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu, availableNavigation);
            DisplayInputBox();
            DisplayStatusBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public PlayerAction GetActionMenuChoice(Menu menu,bool getNavigation = false)
        {
            PlayerAction choosenAction = PlayerAction.None;



            ConsoleKeyInfo keyPressedInfo = Console.ReadKey(true);

            if (getNavigation == true) {
                switch (keyPressedInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        choosenAction = PlayerAction.TravelNorth;
                        break;
                    case ConsoleKey.DownArrow:
                        choosenAction = PlayerAction.TravelSouth;
                        break;
                    case ConsoleKey.LeftArrow:
                        choosenAction = PlayerAction.TravelWest;
                        break;
                    case ConsoleKey.RightArrow:
                        choosenAction = PlayerAction.TravelEast;
                        break;
                    case ConsoleKey.PageUp:
                        choosenAction = PlayerAction.TravelUp;
                        break;
                    case ConsoleKey.PageDown:
                        choosenAction = PlayerAction.TravelDown;
                        break;
                }
            }

            //if player didn't press an arrow key make sure it's a valid menu option
            if (choosenAction == PlayerAction.None)
            {
                //
                // TODO validate menu choices
                //
                char keyPressed = keyPressedInfo.KeyChar;
                menu.MenuChoices.TryGetValue(keyPressed, out choosenAction);
                //if(!menu.MenuChoices.TryGetValue(keyPressed, out choosenAction))
                //{
                //    choosenAction = PlayerAction.None;
                //}
            }
            return choosenAction;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                        DisplayInputBoxPrompt(prompt);
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
        }

        /// <summary>
        /// get a character Gender value from the user
        /// </summary>
        /// <returns>character Gender value</returns>
        public Player.Genders GetGender()
        {
            Player.Genders Gender;
            Enum.TryParse<Player.Genders>(Console.ReadLine(), true, out Gender);
            return Gender;
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            string tabSpace = new String(' ', 35);

            for (int i = ConsoleLayout.WindowHeight; i > ((ConsoleLayout.WindowHeight) / 2-7); i--)
            {
                Console.SetCursorPosition(0, i);
                if (i < (ConsoleLayout.WindowHeight - 1)) { Console.WriteLine(tabSpace + @""); }
                if (i < (ConsoleLayout.WindowHeight - 2)) { Console.WriteLine(tabSpace + @"  _______                .__                      .____          ___.           "); }
                if (i < (ConsoleLayout.WindowHeight - 3)) { Console.WriteLine(tabSpace + @"  \      \  __ __   ____ |  |   ____  __ __  _____|    |   _____ \_ |__   ______"); }
                if (i < (ConsoleLayout.WindowHeight - 4)) { Console.WriteLine(tabSpace + @"  /   |   \|  |  \_/ ___\|  | _/ __ \|  |  \/  ___/    |   \__  \ | __ \ /  ___/"); }
                if (i < (ConsoleLayout.WindowHeight - 5)) { Console.WriteLine(tabSpace + @" /    |    \  |  /\  \___|  |_\  ___/|  |  /\___ \|    |___ / __ \| \_\ \\___ \ "); }
                if (i < (ConsoleLayout.WindowHeight - 6)) { Console.WriteLine(tabSpace + @"\____ |__  /____/  \___  >____/\___  >____//____  >_______ (____  /___  /____  >"); }
                if (i < (ConsoleLayout.WindowHeight - 7)) { Console.WriteLine(tabSpace + @"         \/            \/          \/           \/        \/    \/    \/     \/ "); }
                if (i < (ConsoleLayout.WindowHeight - 8)) { Console.WriteLine(new String(' ', ConsoleLayout.WindowWidth)); }
                System.Threading.Thread.Sleep(100);
            }



            Console.SetCursorPosition(80, ((ConsoleLayout.WindowHeight) / 2)+7);
            Console.WriteLine("Press any key to continue or Esc to exit.");
            Console.WriteLine("");



            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        /// <summary>
        /// initialize the console window settings
        /// </summary>
        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "NucleusLabs";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        /// <param name="availableNavigation">array of availible navigation north,south,east,west,up,down</param>
        private void DisplayMenuBox(Menu menu, bool[] availableNavigation )
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, PlayerAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != PlayerAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }



            availableNavigation = availableNavigation ?? new bool[6];

            bool hasNav = false;
            List<string> NavigationMenu = new List<string> { };

            //Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
            if (availableNavigation[0] == true) //North
            {
                NavigationMenu.Add("Up Arrow    - Travel North");
                hasNav = true;
            }
            else
            {
                NavigationMenu.Add("            - Travel North");
            }

            //Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
            if (availableNavigation[1] == true) //South
            {
                NavigationMenu.Add("Down Arrow  - Travel South");
                hasNav = true;
            }
            else
            {
                NavigationMenu.Add("            - Travel South");
            }

            //Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
            if (availableNavigation[2] == true) //East
            {
                NavigationMenu.Add("Right Arrow - Travel East");
                hasNav = true;
            }
            else
            {
                NavigationMenu.Add("            - Travel East");
            }

            //Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
            if (availableNavigation[3] == true) //West
            {
                NavigationMenu.Add("Left Arrow  - Travel West");
                hasNav = true;
            }
            else
            {
                NavigationMenu.Add("            - Travel West");
            }

            //Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
            if (availableNavigation[4] == true) //Up
            {
                NavigationMenu.Add("Page Up     - Travel Up");
                hasNav = true;
            }
            else
            {
                NavigationMenu.Add("            - Travel Up");
            }

            //Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
            if (availableNavigation[5] == true) //Down
            {
                NavigationMenu.Add("Page Down   - Travel Down");
                hasNav = true;
            }
            else
            {
                NavigationMenu.Add("            - Travel Down");
            }

            if (hasNav)
            {
                topRow++;
                topRow++;
                Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, topRow++);
                Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
                Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
                Console.Write(ConsoleWindowHelper.Center("Available Navigation", ConsoleLayout.MenuBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
                topRow++;
                foreach (string menuItem in NavigationMenu)
                {
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.WriteLine(menuItem);
                }
                
            }


        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        /// <summary>
        /// draw the status box on the game screen
        /// </summary>
        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gamePlayer))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>Player object with all properties updated</returns>
        public Player GetInitialPlayerInfo()
        {
            Player Player = new Player();
            
            //
            // intro
            //
            DisplayGamePlayScreen("Mission Initialization", Text.InitializeMissionIntro(), ActionMenu.MissionIntro, "");
            GetContinueKey();

            //
            // get Player's name
            //
            DisplayGamePlayScreen("Mission Initialization - Name", Text.InitializeMissionGetPlayerName(), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your name: ");
            Player.Name = GetString();

            ////
            //// get Player's age
            ////
            //DisplayGamePlayScreen("Mission Initialization - Age", Text.InitializeMissionGetPlayerAge(Player.Name), ActionMenu.MissionIntro, "");
            //int gamePlayerAge;

            //GetInteger($"Enter your age {Player.Name}: ", 0, 1000000, out gamePlayerAge);
            //Player.Age = gamePlayerAge;

            //
            // get Player's Gender
            //
            do
            {
                DisplayGamePlayScreen("Mission Initialization - Gender", Text.InitializeMissionGetPlayerGender(Player), ActionMenu.MissionIntro, "");
                DisplayInputBoxPrompt($"Enter your Gender {Player.Name}: ");
                Player.Gender = GetGender();
            } while (Player.Gender == Player.Genders.None);

            //
            // echo the Player's info
            //
            //DisplayGamePlayScreen("Mission Initialization - Complete", Text.InitializeMissionEchoPlayerInfo(Player), ActionMenu.MissionIntro, "");
            //GetContinueKey();

            // 
            // change view status to playing game
            //
            //_viewStatus = ViewStatus.PlayingGame;

            return Player;
        }

        public Player GetInitialAIInfo()
        {
            Player Player = new Player();


            //
            // get Player's name
            //
            DisplayGamePlayScreen("Mission Initialization - Partner's Name", Text.InitializeMissionGetAIName(), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your partner's name: ");
            Player.Name = GetString();

            //
            // get Player's Gender
            //
            do
            {
                DisplayGamePlayScreen("Mission Initialization - Partner's Gender", Text.InitializeMissionGetAIGender(Player), ActionMenu.MissionIntro, "");
                DisplayInputBoxPrompt($"Enter {Player.Name} gender: ");
                Player.Gender = GetGender();
            } while (Player.Gender == Player.Genders.None);

            //
            // echo the Player's info
            //
            DisplayGamePlayScreen("Mission Initialization - Complete", Text.InitializeMissionEchoPlayerInfo(), ActionMenu.MissionIntro, "");
            GetContinueKey();

            // 
            // change view status to playing game
            //
            _viewStatus = ViewStatus.PlayingGame;

            return Player;
        }


        #region ----- display responses to menu action choices -----

        public void DisplayPlayerInfo()
        {
            DisplayGamePlayScreen("Player Information", Text.PlayerInfo(_gamePlayer), ActionMenu.MainMenu, "");
        }

        #endregion

        #endregion
    }
}
