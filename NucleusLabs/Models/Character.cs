using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum CharacterType
        {
            Player,
            PlayerNPC,
            Rodent,
            Dog,
            Cat
        }

        #endregion

        #region FIELDS

        private string _name;
        private int _locationID;
        private bool _isNPC;

        #endregion

        #region PROPERTIES
        


        public bool InNPC
        {
            get { return _isNPC; }
            set { _isNPC = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int LocationID
        {
            get { return _locationID; }
            set { _locationID = value; }
        }


        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, int locationID, bool isNPC)
        {
            _name = name;
            _locationID = locationID;
            _isNPC = isNPC;
        }

        #endregion

        #region METHODS



        #endregion
    }
}
