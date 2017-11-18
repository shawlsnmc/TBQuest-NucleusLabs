using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum PlayerAction
    {
        None,
        Admin,
        MissionSetup,
        LookAround,
        LookAt,
        PickUpItem,
        PutDownItem,
        PlayerInfo,
        PlayerInventory,
        ListItems,
        TravelNorth,
        TravelSouth,
        TravelEast,
        TravelWest,
        TravelUp,
        TravelDown,
        Exit
    }
}
