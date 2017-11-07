using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class Word
    {
        private string word;
        private int length;
        private Dictionary<int, Letter> indexLetterPairs; //dictionary storing letter number as key and corresponding letter as value

        public Word(string word)
        {
            this.word = word;
            length = word.Length;
            indexLetterPairs = new Dictionary<int, Letter>();
            decomposeWordToLetters();
        }

        public bool findCharLetter(char letter)
        {
            return findLetter(new Letter(letter));
        }

        public bool isOpen()   //to check if all the letters are open, i.e the game is won
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

        private bool findLetter(Letter Letter)  //returnes true if a specific letter is found, otherwise false. Also "opens" the letter if found.
        {
            bool result = false;

            //Alternative 1:
            foreach (var pair in indexLetterPairs)
            {
                char pairLetter = pair.Value.letter;
                if (pairLetter == Letter.letter)
                {
                    result = true;
                    pair.Value.IsOpen = true;

                }
            }

            //-------------------------

            //Alternative 2:
            //IndexLetterPairs.FirstOrDefault <> (
            //                            (keyValue) => return true;  //condtion for finding the specific letter
            //                          );

            //--------------------------
            return result;
        }

        private void decomposeWordToLetters()
        {
            int index = 1;  //letter number starts with the index of 1
            foreach (var wordLetter in word)
            {
                Letter letter = new Letter(wordLetter);
                indexLetterPairs.Add(index, letter);
                index++;
            }
        }

        public Dictionary<int, Letter> getIndexLetterPairs()
        {
            return indexLetterPairs;
        }


    }
}
