using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    /// <summary>
    /// static class to hold key/value pairs for menu options
    /// </summary>
    public static class ActionMenu
    {

        public enum CurrentMenu
        {
            MissionIntro,
            InitializeMission,
            MainMenu,
            InventoryMenu,
            AdminMenu
        }



        public static CurrentMenu currentMenu = CurrentMenu.MainMenu;
        public static Menu MissionIntro = new Menu()
        {
            MenuName = "MissionIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, PlayerAction>()
                    {
                        { ' ', PlayerAction.None }
                    }
        };

        public static Menu InitializeMission = new Menu()
        {
            MenuName = "InitializeMission",
            MenuTitle = "Initialize Mission",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '0', PlayerAction.Exit }
                }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.PlayerInfo },
                    { '2', PlayerAction.LookAround },
                    { '3', PlayerAction.LookAt },
                    { '4', PlayerAction.PickUpItem },
                    { '5', PlayerAction.PlayerInventory },
                    { '9', PlayerAction.Admin },
                    { '0', PlayerAction.Exit }
                }
        };

        public static Menu InventoryMenu = new Menu()
        {
            MenuName = "InventoryMenu",
            MenuTitle = "Inventory Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                    { '1', PlayerAction.ConsumeItem },
                    { '2', PlayerAction.LookAt },
                    { '3', PlayerAction.PutDownItem },
                    { '0', PlayerAction.ReturnToMain }
            }
        };
    }
}
