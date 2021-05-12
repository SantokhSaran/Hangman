using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_SS
{
    class Program
    {
        static void Main(string[] args)
        {

            // Randomiser to choose word 
            Random random = new Random((int)DateTime.Now.Ticks);
            // Word List
            string[] wordBank = { "Array", "List", "Collection", "Delegate", "Lambda" };

            // Return non-negative random integer
            string wordToGuess = wordBank[random.Next(0, wordBank.Length)];
            string wordToGuessUppercase = wordToGuess.ToUpper();

            //Word length 
            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
                displayToPlayer.Append('_');

            // Stores guesses in list of char    
            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            // Condition variables 
            int lives = 5;
            bool won = false;
            int lettersRevealed = 0;
            string input;
            char guess;

            //Lives not greater than 0
            while (!won && lives > 0)
            {
                Console.WriteLine("Guess a Letter: ");

                input = Console.ReadLine().ToUpper();
                guess = input[0];

                // Displaying already inputted letters to console
                if (correctGuesses.Contains(guess))
                {
                    Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                    continue;
                }

                // If else for correct and incorrect guesses 
                if (wordToGuessUppercase.Contains(guess))
                {
                    correctGuesses.Add(guess);

                    for (int i = 0; i < wordToGuess.Length; i++)
                    {    // Revlealing letters 
                        if (wordToGuessUppercase[i] == guess)
                        {
                            displayToPlayer[i] = wordToGuess[i];
                            lettersRevealed++;
                        }
                    }
                    // length and letters are true to guess 
                    if (lettersRevealed == wordToGuess.Length)
                        won = true;
                }
                // Taking life away from wrong guess. 
                else
                {
                    incorrectGuesses.Add(guess);
                    Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                    lives--;
                }

                Console.WriteLine(displayToPlayer.ToString());
            }
                // Win Condition 
                if (won)
                   Console.WriteLine("You won!");
                 else
                  Console.WriteLine("You lost! It was '{0}'", wordToGuess);

                  Console.Write("Press ENTER to exit....");
                  Console.ReadLine();
        }   
    }
}
