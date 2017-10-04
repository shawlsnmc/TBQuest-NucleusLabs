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
            "You will need to look for clues and solve puzzles in order to rescue your friend and yourself. "+
            " \n" +
            "Keep an eye on your health meter, if it hits 0, it's game over."+
            " \n" +
            "Press the Esc key to exit the game at any point.\n" +
            " \n" +
            "\tFirst I need to get some inforamion from you so the narrative doesn't sound completely stupid.\n" +
            " \n" +
            "\tPress any key to begin.\n";

            return messageBoxText;
        }

        public static string CurrrentLocationInfo()
        {
            string messageBoxText =
            "Wakey Wakey!\n" +
            " \n" +
            "\tChoose from the menu options to proceed.\n";

            return messageBoxText;
        }

        #region Initialize Mission Text

        public static string InitializeMissionIntro()
        {
            string messageBoxText =
                "Before you begin I need some required information. Please enter the information below.\n" +
                " \n" +
                "\tPress any key to begin.";

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
                GenderList += $"\t{Gender}\n";
            }

            messageBoxText += GenderList;

            return messageBoxText;
        }

        public static string InitializeMissionEchoPlayerInfo(Player gamePlayer)
        {
            string messageBoxText =
                $"Very good then {gamePlayer.Name}.\n" +
                " \n" +
                "It appears we have all the necessary data to begin your game. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tPlayer Name: {gamePlayer.Name}\n" +
                $"\tPlayer Gender: {gamePlayer.Gender}\n" +
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
                $"\tPlayer Name: {gamePlayer.Name}\n" +
                $"\tPlayer Gender: {gamePlayer.Gender}\n" +
                " \n";

            return messageBoxText;
        }

        #endregion

        public static List<string> StatusBox(Player Player)
        {
            List<string> statusBoxText = new List<string>();

            statusBoxText.Add($"Player's Gender: {Player.Gender}\n");

            return statusBoxText;
        }
    }
}
