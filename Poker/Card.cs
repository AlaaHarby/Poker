using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Card : IComparable
    {
        public Card(char suit, int rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public Card(string arg)
        {
            foreach (char c in arg)
            {
                switch (c)
                {
                    case 'H':
                    case 'D':
                    case 'C':
                    case 'S':
                        suit = c;
                        break;
                    case 'T':
                        rank = 10;
                        break;
                    case 'J':
                        rank = 11;
                        break;
                    case 'Q':
                        rank = 12;
                        break;
                    case 'K':
                        rank = 13;
                        break;
                    case 'A':
                        rank = 14;
                        break;
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        rank = c - '0';
                        break;

                    default:
                        throw new Exception("Error parsing cards");
                }

            }
        }

        public char suit { get; }
        public int rank { get; }

        public int CompareTo(object obj)
        {
            return (rank - (obj as Card).rank);
        }
    }
}
