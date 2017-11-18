using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Hangman
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Page
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            Word word = new Word(wordInput.Text);
            Guess guess = new Guess(word);

            NavigationService.Navigate(guess);
        }
    }
}
