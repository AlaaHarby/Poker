using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{

    class Program
    {
        static string[] deck = new string[] {
            "H2", "S2","C2", "D2", "H3", "S3", "C3", "D3", "H4", "S4", "C4", "D4", "H5",
            "S5", "C5", "D5", "H6", "S6", "C6", "D6", "H7", "S7", "C7", "D7", "H8", "S8",
            "C8", "D8", "H9", "S9", "C9", "D9", "HA", "SA", "CA", "DA", "HJ", "SJ", "CJ",
            "DJ", "HK", "SK", "CK", "DK", "HQ", "SQ", "CQ", "DQ", "HT", "ST", "CT", "DT"
        };

        static int deal;
        static Hand DealHand(string args)
        {

            HashSet<string> deckCards = new HashSet<string> (deck);
            Card[] h = new Card[deal];

            int i = 0;
            string[] hand = args.TrimEnd().Split(',');

            foreach (string s in hand)
            {
                if (s != "")
                {
                    h[i] = new Card(s);
                    i++;
                    deckCards.Remove(s);
                }
            }

            Random r = new Random();

            for (int ind = i; ind < deal; ind++)
            {
                // not enough cards for one hand, deal random cards
                string cc = deckCards.ElementAt(r.Next(0, deckCards.Count));
                h[ind] = new Card(cc);
                deckCards.Remove(cc);
            }

            return new Hand(h);
        }

        static void Main(string[] args)
        {
            // get hand using args


            deal = int.Parse(args[0]);

            string hand1 = args[1].ToUpper();
            string hand2 = args[2].ToUpper();

            Hand h1 = DealHand(hand1);
            Hand h2 = DealHand(hand2);

            for (int i = 0; i < deal; i++)
                Console.Write(((char)h1.cards[i].suit) + "" + h1.cards[i].rank + ",");

            Console.WriteLine();

            for (int i = 0; i < deal; i++)
                Console.Write(((char)h2.cards[i].suit) + "" + h2.cards[i].rank + ",");

            Console.Read();


        }
    }
}
