using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Hangman
{
    /// <summary>
    /// Interaction logic for Guess.xaml
    /// </summary>
    public partial class Guess : Page
    {
        private Word word;
        private readonly int GUESSES = 6;
        private int wrongGuesses = 0;
        private string guessedLetters = "";
        private string wronglyGuessedLetters = "Bokstaver feil gjettet:\n";

        public Guess()
        {
            InitializeComponent();
        }

        public Guess(Word word) : this()
        {
            this.word = word;
            DisplayWord();
            DisplayGuessesLeft();
            DisplayWronglyGuessedLetters();
        }

        private void MakeGuess(object sender, RoutedEventArgs e)
        {
            string guessedLetter = letterInput.Text.ToUpper();

            if (!GuessedBefore(guessedLetter))
            {
                guessedLetters += guessedLetter.ToString();
                letterInput.Text = "";

                bool found = word.FindCharLetter(guessedLetter.ToCharArray().First());

                if (!found)
                {
                    wronglyGuessedLetters += guessedLetter + " ";
                    wrongGuesses++;
                    DisplayGuessesLeft();
                }

                DisplayWronglyGuessedLetters();
                DisplayWord();
                CheckIfWonOrLost();
            }
        }

        public void DisplayWord()
        {
            string show = "";

            foreach (var pair in word.GetIndexLetterPairs())
            {
                if (pair.Value.IsOpen)
                {
                    show = show + pair.Value.letter + " ";
                }
                else
                {
                    show = show + "_ ";
                }
            }

            guessedLettersTextBox.Text = show;
        }

        private void DisplayGuessesLeft()
        {
            guessesLeftLabel.Content = $"Du har {GUESSES - wrongGuesses} forsøk igjen";
        }

        private void DisplayWronglyGuessedLetters()
        {
            wronglyGuessedLettersLabel.Content = wronglyGuessedLetters;
        }

        private bool GuessedBefore(string guessedLetter)
        {
            if (guessedLetters.Contains(guessedLetter.ToString()))
            {
                infoLabel.Content = "Du har gjettet denne bokstaven før!";
                return true;
            }
            else
            {
                infoLabel.Content = "";
                return false;
            }
        }

        private void CheckIfWonOrLost()
        {
            if (word.IsOpen())
            {
                guessedLettersTextBox.Text = $"Gratulerer, du vant! Ordet var {word.GetWord()}";
                makeGuess.IsEnabled = false;
            }
            else if (wrongGuesses >= GUESSES)
            {
                guessedLettersTextBox.Text = $"Du tapte. Ordet var {word.GetWord()}";
                makeGuess.IsEnabled = false;
                letterInput.IsReadOnly = true;
            }
        }
    }
}
