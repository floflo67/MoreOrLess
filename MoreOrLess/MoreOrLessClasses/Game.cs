using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoreOrLessClasses
{
    /// <summary>
    /// Class for the game in itself
    /// Most important class of all
    /// Will manage the game from the begining to the end
    /// </summary>
    public class Game
    {
        /* See describtion of the class in the Player.cs file */
        private Player player1;
        public Player Player1
        {
            get 
            { 
                return player1; 
            }
            set 
            { 
                player1 = value; 
            }
        }

        /* See describtion of the class in the Level.cs file */
        private Level level;
        public Level Level
        {
            get 
            { 
                return level; 
            }
            set 
            { 
                level = value; 
            }
        }

        /* Int needed to know the number of players 
         * Will add a screen if there are two players to ask the second player for the mystery number */
        private int numberOfPlayer;
        public int NumberOfPlayer
        {
            get 
            { 
                return numberOfPlayer; 
            }
            set 
            { 
                numberOfPlayer = value; 
            }
        }

        /// <summary>
        /// Constructor of the class
        /// Calls the method needed to play
        /// </summary>
        public Game()
        {
            Console.Clear(); // Clears the console of all previous text
            MessageOutputLaunch();
            MessageOutputLevel();
            PlayGame();
        }

        /// <summary>
        /// First message on the console
        /// Asks for the number of player
        /// </summary>
        /// <returns>Boolean corresponding to the success of the operation</returns>
        private bool MessageOutputLaunch()
        {
            try
            {
                Console.WriteLine("Welcome on this new game.");
                Console.Write("Please enter the number of player : ");
                int numberPlayer = CheckNumberEntered(Console.ReadLine()); // Gets the number entered and check if the format is correct

                /* if format is incorrect or the number entered is different than 1 or 2
                 * will show the same question again and again until a good number is entered */
                while (numberPlayer != 1 && numberPlayer != 2) 
                {
                    Console.WriteLine("Error in the number of player.");
                    Console.Write("Please enter 1 or 2 : ");
                    numberPlayer = CheckNumberEntered(Console.ReadLine());
                }

                InitPlayers(numberPlayer); /* Calls the method to initialize the player
                                            * Number entered before send in variable */
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Initialize the player1 variable by creating a new Player()
        /// Initialize the numberOfPlayer variable
        /// </summary>
        /// <param name="_numberOfPlayer">Int corresponding to the number of player. Can be 1 or 2</param>
        /// <returns>Boolean corresponding to the success of the operation</returns>
        private bool InitPlayers(int _numberOfPlayer)
        {
            try
            {
                Player1 = new Player(); // Creates a new player
                NumberOfPlayer = _numberOfPlayer; // Initialize the numberOfPlayer variable
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Boolean corresponding to the success of the operation</returns>
        private bool MessageOutputLevel()
        {
            try
            {
                if (NumberOfPlayer == 2)
                {
                    Level = new Level(1);
                    Console.WriteLine("The first player will now choose a number : ");
                    Level.MysteryNumber = CheckNumberEntered(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Please choose your level now.");
                    Console.WriteLine("Level 1 will be between 0 and 50.");
                    Console.WriteLine("Level 2 will be between 0 and 100.");
                    Console.WriteLine("Level 3 will be between -100 and 100.");
                    Console.Write("Please enter the level you want : ");

                    int numberLevel = CheckNumberEntered(Console.ReadLine());

                    while (numberLevel < 1 || numberLevel > 3)
                    {
                        Console.WriteLine("Error in the choice of level.");
                        Console.Write("Please enter a level between 1 and 3 : ");
                        numberLevel = CheckNumberEntered(Console.ReadLine());
                    }

                    InitLevel(numberLevel);
                }
                Console.Clear();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_level"></param>
        /// <returns>Boolean corresponding to the success of the operation</returns>
        private bool InitLevel(int _level)
        {
            try
            {
                Level = new Level(_level);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Boolean corresponding to the success of the operation</returns>
        private bool PlayGame()
        {
            try
            {
                Console.WriteLine("What number do you think is the mystery number ?");
                Console.Write("Your number : ");
                int numberEntered = CheckNumberEntered(Console.ReadLine());

                while (!IsGoodNumber(numberEntered))
                {
                    Console.Write("Try another number : ");
                    if (!int.TryParse(Console.ReadLine(), out numberEntered))
                    {
                        numberEntered = Player1.NumberTried.Last();
                    }
                }

                Winner();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_number"></param>
        /// <returns>Boolean true if the number is the same as the mystery number</returns>
        private bool IsGoodNumber(int _number)
        {
            try
            {
                Player1.NumberTried.Add(_number);
                Player1.NumberOfTry++;
                if (_number > Level.MysteryNumber)
                {
                    Console.WriteLine("Your number is too high. It is less.");
                    return false;
                }
                else if (_number < Level.MysteryNumber)
                {
                    Console.WriteLine("Your number is too low. It is more.");
                    return false;
                }
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Boolean corresponding to the success of the operation</returns>
        private bool Winner()
        {
            try
            {
                Console.WriteLine("Congratulations ! You won !");
                Console.WriteLine("It took you " + Player1.NumberOfTry + " tries.");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_intToCheck"></param>
        /// <returns></returns>
        private int CheckNumberEntered(string _intToCheck)
        {
            int intChecked;
            int.TryParse(_intToCheck, out intChecked);

            while (!int.TryParse(_intToCheck, out intChecked))
            {
                Console.WriteLine("Error in the format.");
                Console.Write("Please enter a new number : ");
                _intToCheck = Console.ReadLine();
            }
            return intChecked;
        }
    }
}
