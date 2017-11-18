using System.Collections.Generic;

namespace Hangman
{
    public class Word
    {
        private string word;
        private int length;
        private Dictionary<int, Letter> indexLetterPairs; //dictionary storing letter number as key and corresponding letter as value

        public Word(string word)
        {
            this.word = word.ToUpper();
            length = word.Length;
            indexLetterPairs = new Dictionary<int, Letter>();
            DecomposeWordToLetters();
        }

        public bool FindCharLetter(char letter)
        {
            return FindLetter(new Letter(letter));
        }

        public bool IsOpen()   //to check if all the letters are open, i.e the game is won
        {
            foreach (var pair in indexLetterPairs)
            {
                if (!pair.Value.IsOpen)
                {
                    return false;
                }
            }
            return true;
        }

        private bool FindLetter(Letter Letter)  //returnes true if a specific letter is found, otherwise false. Also "opens" the letter if found.
        {
            bool result = false;

            foreach (var pair in indexLetterPairs)
            {
                char pairLetter = pair.Value.letter;
                if (pairLetter == Letter.letter)
                {
                    result = true;
                    pair.Value.IsOpen = true;

                }
            }

            return result;
        }

        private void DecomposeWordToLetters()
        {
            int index = 1;  //letter number starts with the index of 1
            foreach (var wordLetter in word)
            {
                Letter letter = new Letter(wordLetter);
                indexLetterPairs.Add(index, letter);
                index++;
            }
        }

        public string GetWord()
        {
            return word;
        }

        public Dictionary<int, Letter> GetIndexLetterPairs()
        {
            return indexLetterPairs;
        }

        public int GetLength()
        {
            return length;
        }

    }
}
