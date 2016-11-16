using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{

    class Program
    {
        static HashSet<string> deckCards;
        static int deal;

        static void Shuffle() {
            deckCards = new HashSet<string>();

            char[] suit = { 'D', 'H', 'S', 'C' };
            char[] rank = { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };

            foreach (char s in suit)
                foreach (char r in rank)
                    deckCards.Add(s + "" + r + "");
        }

        static Hand DealHand(string args)
        {
            Card[] h = new Card[deal];

            int i = 0;
            string[] hand = args.Split(',');

            foreach (string s in hand)
            {
                if (deckCards.Contains(s))
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

            deal = args.Length == 0 ? 5 : int.Parse(args[0]);
   
            string hand1 = args.Length < 2 ? "" : args[1].ToUpper();
            string hand2 = args.Length < 3 ? "" : args[2].ToUpper();

            Shuffle();

            Hand h1 = DealHand(hand1);
            Hand h2 = DealHand(hand2);

            Console.Write("First player cards: ");
            for (int i = 0; i < deal; i++)
                Console.Write(((char)h1.cards[i].suit) + "" + h1.cards[i].rank + " ");

            Console.Write("\nSecond Player cards: ");

            for (int i = 0; i < deal; i++)
                Console.Write(((char)h2.cards[i].suit) + "" + h2.cards[i].rank + " ");

            int winner = h1.CompareTo(h2);
            string w = "No winner";

            if (winner > 0) w = "Player 1 is the winner: " + h1.CheckType();
            if (winner < 0) w = "Player 2 is the winner: " + h2.CheckType();

            Console.Write("\n" + w.Replace("NONE", "HIGHER_CARD"));

            Console.Read();


        }
    }
}
