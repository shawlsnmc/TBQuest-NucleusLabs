using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Player : Character
    {
        #region ENUMERABLES
        public enum Genders
        {
            Male,
            Female
        }

        #endregion

        #region FIELDS
        private int _health;
        private Genders _gender;

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }


        public Genders Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }


        #endregion
        #region PROPERTIES


        #endregion


        #region CONSTRUCTORS

        public Player()
        {

        }

        public Player(string name, Genders gender, int locationID, bool isNPC) : base(name, locationID, isNPC)
        {

        }
        public Player(string name, Genders gender, int locationID, bool isNPC, int health) : base(name, locationID, isNPC)
        {

        }

        #endregion


        #region METHODS


        #endregion
    }
}
