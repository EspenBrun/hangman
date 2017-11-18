namespace Hangman
{
    public class Letter
    {
        public Letter(char letter)
        {
            this.letter = letter;
            IsOpen = false;
        }

        public char letter { get; set; }
        public bool IsOpen { get; set; }

    }
}
