using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHangman.Hangman
{
    class Game
    {
        public Game()
        {

        }

        Word word = new Word("ELEPHANT");

        public void showWordOnScreen()
        {
            string show = "";

            foreach (var pair in word.IndexLetterPairs)
            {
                if (pair.Value.IsOpen)
                {
                    show = show + pair.Value.letter;
                }
                else
                {
                    show = show + " ";
                }
            }

            Console.WriteLine(show);

            show = "";

            foreach (var pair in word.IndexLetterPairs)
            {
                show = show + "&";
            }

            Console.WriteLine(show);
        }

        public void guessLetter()
        {
            char guessLetter = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine("\n");
            Console.WriteLine("Your guess is: {0}\n",guessLetter);
            bool found = word.findCharLetter(guessLetter);
        }

        public void runGame()
        {
            Console.WriteLine("Welcome to Hangman ! ! ! \nGuess a letter !");
            showWordOnScreen();
            
            while (!word.isOpen())  //play the game while the word is not open entirely
            {
                guessLetter();
                showWordOnScreen();

            }

            Console.WriteLine("Congratz");
        } 
    }
}
