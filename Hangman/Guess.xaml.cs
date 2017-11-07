using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hangman
{
    /// <summary>
    /// Interaction logic for Guess.xaml
    /// </summary>
    public partial class Guess : Page
    {
        private Word word;
        private readonly int GUESSES = 6;
        private int currentGuess = 0;

        public Guess()
        {
            InitializeComponent();
        }

        public Guess(object data, Word word) : this()
        {
            this.DataContext = data;
            this.word = word;
        }

        private void MakeGuess(object sender, RoutedEventArgs e)
        {
            if (currentGuess >= GUESSES)
            {
                guessedLettersLabel.Content = $"You loose. The word was {word.getWord()}";
                makeGuess.IsEnabled = false;
            }
            else
            {
                currentGuess++;
                char guessedLetter = letterInput.Text.ToUpper().ToCharArray().First();
                letterInput.Text = "";
                bool found = word.findCharLetter(guessedLetter);
                displayWord();
                checkWin();
            }
        }

        public void displayWord()
        {
            string show = "";

            foreach (var pair in word.getIndexLetterPairs())
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

            guessedLettersLabel.Content = show;
        }

        public void guessLetter()
        {
            char guessLetter = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine("\n");
            Console.WriteLine("Your guess is: {0}\n", guessLetter);
            bool found = word.findCharLetter(guessLetter);
        }

        private void checkWin()
        {
            if (word.isOpen())
            {
                guessedLettersLabel.Content = $"Congratulations! The word was {word.getWord()}";
                makeGuess.IsEnabled = false;
            }
        }

        public void runGame()
        {
            Console.WriteLine("Welcome to Hangman ! ! ! \nGuess a letter !");
            displayWord();

            while (!word.isOpen())  //play the game while the word is not open entirely
            {
                guessLetter();
                displayWord();

            }

            Console.WriteLine("Congratz");
        }
    }
}
