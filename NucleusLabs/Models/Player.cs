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
            None,
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
            set {
                    if (value < 1)
                    {
                        //player died
                        _health = 0;
                    }else if (value > 100)
                    {
                        _health = 100;
                    }
                    else
                    {
                        _health = value;
                    }
                }
        }

        public int Xp { get; set; }

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
            this.Health = 100;
        }


        public Player(string name, Genders gender, int locationID, bool isNPC, int health = 100) : base(name, locationID, isNPC)
        {
            this.Health = health;
        }

        #endregion


        #region METHODS

        public override string Greeting()
        {
            return "Welcome Player whom goes by " + this.Name+"!" ;
        }

        public void TravelTo(int LocationID, GameMap map)
        {
            //If we want to trigger code on character travel we do it here
            this.UpdateLocation(LocationID);
            if(!map.GetLocationVisited(LocationID)){
                this.Xp++;
                map.SetLocationVisited(LocationID);
            }
        }
        

        #endregion
    }
}
