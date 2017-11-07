using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Letter
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
