using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Card : IComparable
    {
        char suit;
        int rank;

        public Card(char suit, int rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public char getSuit() { return suit; }
        public int getRank() { return rank; }

        public int CompareTo(object obj)
        {
            return (rank - (obj as Card).getRank());
        }
    }
}
