using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "NucleusLabs" };
        public static List<string> FooterText = new List<string>() { "Lame Headache Productions, 2017" };

        #region INTITIAL GAME SETUP

        public static string GameIntro()
        {
            string messageBoxText =
            "You wake up with no clue where you are or why you are locked in this room. " +
            "You remember you were with your best friend before whatever happened that got you into this mess. "+
            "You will need to look for clues and solve puzzles in order to rescue your friend and yourself. \n"+
            " \n" +
            "Press any key to continue.\n";

            return messageBoxText;
        }

        public static string CurrentLocationInfo(int LocationID,GameMap Map, IEnumerable<GameObject> gameObjects)
        {
             
            string locationName = Map.GetLocationName(LocationID);
            string locationDesc = Map.GetLocationDescription(LocationID);
            string messageBoxText =

            $"Your Current Location: {locationName}\n" +
            " \n" +
            $"{locationDesc}\n" +
            " \n" +
            "Looking around you notice the following items\n\n";


            messageBoxText +=
                "ID".PadRight(10) +
                "Name".PadRight(30) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) + "\n";
            
            //foreach (GameObject gameObject in gameObjects) 
            foreach(var gameObject in gameObjects.Where(b => b.LocationID == LocationID))
            {
                messageBoxText +=
                    $"{gameObject.ObjectID}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += "\nChoose from the menu options to proceed.\n";

            return messageBoxText;
        }


        public static string GameObjectsChooseList(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Objects here\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) + "\n";

            //
            // display all traveler objects in rows
            //
            
            foreach (GameObject gameObject in gameObjects)
            {
                messageBoxText +=
                    $"{gameObject.ObjectID}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            return messageBoxText;
        }




        public static string LookAt(GameObject gameObject)
        {
            string messageBoxText = "";

            messageBoxText =
                $"{gameObject.Name}\n" +
                " \n" +
                gameObject.Description + " \n" +
                " \n";

            messageBoxText += $"This item ";

            if (gameObject.CanAddToInventory)
            {
                messageBoxText += "may be added to your inventory.";
            }
            else
            {
                messageBoxText += "may not be added to your inventory.";
            }

            return messageBoxText;
        }




        public static string AdminInfo(int LocationID, GameMap Map, IEnumerable<GameObject> gameObjects)
        {

            string locationName = Map.GetLocationName(LocationID);
            string locationDesc = Map.GetLocationDescription(LocationID);
            string messageBoxText =

            $"Your Current Location: {locationName}\n" +
            " \n" +
            $"{locationDesc}\n" +
            " \n" +
            "Looking around you notice the following items\n\n";


            messageBoxText +=
                "ID".PadRight(10) +
                "Name".PadRight(30) + 
                "Location".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) + 
                "---".PadRight(10) + "\n";

            //foreach (GameObject gameObject in gameObjects) 
            foreach (var gameObject in gameObjects)
            {
                messageBoxText +=
                    $"{gameObject.ObjectID}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    $"{gameObject.LocationID}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += "Choose from the menu options to proceed.\n";

            return messageBoxText;
        }

        #region Initialize Mission Text

        public static string InitializeMissionIntro()
        {
            string messageBoxText =
            "Keep an eye on your health meter, if it hits 0, it's game over." +
            " \n" +
            "Press the Esc key to exit the game at any point.\n" +
            " \n" +
            "First I need to get some information from you so the narrative doesn't sound completely stupid.\n" +
                "Please enter all the required information on the following screens.\n" +
                " \n" +
                "Press any key to begin.";

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerName()
        {
            string messageBoxText =
                "Enter your name Player.\n" +
                " \n" +
                "Please use the name you wish to be referred during your time here.";

            return messageBoxText;
        }

        public static string InitializeMissionGetAIName()
        {
            string messageBoxText =
                "Enter your partner's name.\n" +
                " \n" +
                "Please use the name you wish for us to use while referencing your partner during your time here.";

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerGender(Player gamePlayer)
        {
            string messageBoxText =
                $"{gamePlayer.Name}, it will be important for us to know your gender.\n" +
                " \n" +
                "Enter your gender below.\n" +
                " \n" +
                "Your options are," +
                " \n";

            string GenderList = null;

            foreach (Player.Genders Gender in Enum.GetValues(typeof(Player.Genders)))
            {
                if (!Gender.Equals(Player.Genders.None)){
                    GenderList += $"\t{Gender}\n";
                }
            }

            messageBoxText += GenderList;

            return messageBoxText;
        }

        public static string InitializeMissionGetAIGender(Player gamePlayer)
        {
            string messageBoxText =
                $"Now we need to know {gamePlayer.Name}'s gender.\n" +
                " \n" +
                $"Enter {gamePlayer.Name}'s gender below.\n" +
                " \n" +
                "Your options are," +
                " \n";

            string GenderList = null;

            foreach (Player.Genders Gender in Enum.GetValues(typeof(Player.Genders)))
            {
                if (!Gender.Equals(Player.Genders.None))
                {
                    GenderList += $"\t{Gender}\n";
                }
            }

            messageBoxText += GenderList;

            return messageBoxText;
        }

        public static string InitializeMissionEchoPlayerInfo()
        {
            string messageBoxText =
                "It appears we have all the necessary data to begin your game. \n" +
                " \n" +
                "Press any key to begin.";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string PlayerInfo(Player gamePlayer)
        {
            string messageBoxText =
                $"\t{gamePlayer.Greeting()}\n" +
                "\n"+
                $"\tPlayer Name: {gamePlayer.Name}\n" +
                $"\tPlayer Gender: {gamePlayer.Gender}\n" +
                $"\tPlayer Location: {gamePlayer.LocationID} *\n" +
                $"\tPlayer Health: {gamePlayer.Health}\n" +
                $"\tPlayer XP: {gamePlayer.Xp}\n" +
                " \n" +
                "\t* Temp for testing";

            return messageBoxText;
        }

        #endregion

        public static List<string> StatusBox(Player Player)
        {
            List<string> statusBoxText = new List<string>
            {
                $"Player's Gender: {Player.Gender}\n",
                $"Player's Location: {Player.LocationID}\n",
                $"Player's Health: {Player.Health}\n" ,
                $"Player's XP: {Player.Xp}\n"
            };

            return statusBoxText;
        }
    }
}
