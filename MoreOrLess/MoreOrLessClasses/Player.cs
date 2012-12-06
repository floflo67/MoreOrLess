using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoreOrLessClasses
{

    /// <summary>
    /// Class for the player
    /// Not really needed for the moment but maybe later if we want to add a few things like a DB
    /// </summary>
    public class Player
    {
        // List of all the number tried by the player
        private List<int> numberTried;
        public List<int> NumberTried
        {
            get
            {
                return numberTried;
            }
            set
            {
                numberTried = value;
            }
        }        

        // Int corresponding of the number of try the player used until now
        private int numberOfTry;
        public int NumberOfTry
        {
            get
            {
                return numberOfTry;
            }
            set
            {
                numberOfTry = value;
            }
        }

        /// <summary>
        /// Constructor for the class
        /// Creates the list and initialize the number of try to 0
        /// </summary>
        public Player()
        {
            NumberTried = new List<int>();
            NumberOfTry = 0;
        }
        
    }
}
