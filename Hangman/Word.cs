using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Word
    {
        public Word(string wordContent)
        {
            WordContent = wordContent;
            Length = wordContent.Length;
            IndexLetterPairs = new Dictionary<int, Letter>();
            decompose();
        }

        public string WordContent { get; set; }  //the word itself  as string
        public int Length { get; set; }          //the length of the word
        public Dictionary<int, Letter> IndexLetterPairs { get; set; }     //dictionary storing letter number as key and corresponding letter as value

        void decompose()
        {
            int index = 1;  //letter number starts with the index of 1
            foreach (var wordLetter in WordContent)
            {
                Letter letter = new Letter(wordLetter);
                IndexLetterPairs.Add(index, letter);
                index++;
            }
        }

        public bool findLetter(Letter Letter)  //returnes true if a specific letter is found, otherwise false. Also "opens" the letter if found.
        {
            bool result = false;

            //Alternative 1:
            foreach (var pair in IndexLetterPairs)
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

        public bool findCharLetter(char letter)
        {
            return findLetter(new Letter(letter));
        }

        public bool isOpen()   //to check if all the letters are open, i.e the game is won
        {
            foreach (var pair in IndexLetterPairs)
            {
                if (!pair.Value.IsOpen)
                {
                    return false;
                }
            }
            return true;
        }

        ////-------------Only for Console App test------------------------
        //public void printWord(Word word)
        //{
        //    Console.WriteLine("{0}", word.WordContent);
        //}
    }



    //--------------------------------------------------------------------------------------------

    class AnimalWord : Word
    {
        public AnimalWord(string word) : base(word)
        {

        }
    }
}
