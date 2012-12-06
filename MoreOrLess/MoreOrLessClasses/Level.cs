using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoreOrLessClasses
{
    /// <summary>
    /// Class managing the levels
    /// Really usefull if we want to add a level
    /// </summary>
    public class Level
    {
        // Int for the number to find
        private int mysteryNumber;
        public int MysteryNumber
        {
            get 
            { 
                return mysteryNumber; 
            }
            set 
            {
                mysteryNumber = value; 
            }
        }

        /* Int to know the lower number we can have 
         * May become usefull if we want to check the number entered is within the range of the level  */
        private int lowerNumber;
        public int LowerNumber
        {
            get 
            { 
                return lowerNumber; 
            }
            set 
            { 
                lowerNumber = value; 
            }
        }

        // Int to know the higher number we can have
        private int higherNumber;
        public int HigherNumber
        {
            get 
            { 
                return higherNumber; 
            }
            set 
            { 
                higherNumber = value; 
            }
        }        

        /// <summary>
        /// Constructor of the class
        /// Will use the int corresponding to the level to initialize all the attributes
        /// </summary>
        /// <param name="_level">Int corresponding to the level we want</param>
        public Level(int _level)
        {
            switch (_level)
            {
                case 1: // level is easy
                    MysteryNumber = new Random().Next(50);
                    HigherNumber = 50;
                    LowerNumber = 0;
                    break;
                case 2: // level is average
                    MysteryNumber = new Random().Next(100);
                    HigherNumber = 100;
                    LowerNumber = 0;
                    break;
                case 3: // level is hard
                    /* limits are -100 and 100
                     * we get a random number between 0 and 200
                     * we substract 100 to be in the correct range */
                    MysteryNumber = new Random().Next(200) - 100; 
                    HigherNumber = 100;
                    LowerNumber = -100;
                    break;
                default: // should never happen but initialize like level is average
                    MysteryNumber = new Random().Next(100);
                    HigherNumber = 100;
                    LowerNumber = 0;
                    break;
            }
        }
    }
}
