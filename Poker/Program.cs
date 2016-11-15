using System;
using System.Collections.Generic;

namespace Poker
{
    
    class Program
    {

        static void Main(string[] args)
        {
            // get hand using args
            // get hand using dealer

            Card[] hand = new Card[5];

            hand[0] = new Card('S', 11);
            hand[1] = new Card('S', 11);
            hand[2] = new Card('S', 10);
            hand[3] = new Card('S', 10);
            hand[4] = new Card('C', 2);

            Card[] hand2 = new Card[5];

            hand2[0] = new Card('S', 11);
            hand2[1] = new Card('D', 11);
            hand2[2] = new Card('D', 10);
            hand2[3] = new Card('D', 10);
            hand2[4] = new Card('D', 14);

            Hand d = new Poker.Hand(hand);
            Hand d2 = new Poker.Hand(hand2);

            Console.WriteLine(d.CheckType());
            Console.WriteLine(d2.CheckType());

            Console.WriteLine(d.CompareTo(d2));


            Console.Read();

        }
    }
}
