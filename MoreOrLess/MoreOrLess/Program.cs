using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoreOrLess
{
    class Program
    {
        /// <summary>
        /// Main method
        /// Call for the game class -> launch game
        /// Call for the restart method -> if player wants to play again
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Game game = new Game(); // launch the game
            while (Restart()) // while player wants to play, we load a new game
            {
                game = new Game();
            }
            Console.WriteLine("Thank you for playing this game. Press any key to exit..."); // little sentence at the end just to be nice
            Console.ReadLine();
        }

        /// <summary>
        /// Restart method
        /// Ask the player if he wants to play again
        /// Writes on the console and get pressed key
        /// </summary>
        /// <returns>Boolean corresponding to the willing of playing again</returns>
        private static bool Restart()
        {
            try
            {
                // A few lines to ask nicely if the player wants to go at it again
                Console.WriteLine("\nI hope you had a lot of fun.");
                Console.WriteLine("Maybe you want to try again to improve your score ?");
                Console.Write("Type Y if you want to restart : ");
                string restart = Console.ReadLine(); // read the entry
                if (restart.ToUpper().Equals("Y")) // if entry is "y" or "Y" then return true
                    return true;
                else 
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
