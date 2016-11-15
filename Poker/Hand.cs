using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    enum Rank
    {
        NONE, PAIR, TWO_PAIRS, THREE_KIND, STRAIGHT, FLUSH, FULL_HOUSE, FOUR_KIND, STRAIGHT_FLUSH, ROYAL_FLUSH
    };

    class Hand : IComparable
    {
        Card[] cards;
        Dictionary<int, int> counts;

        public Hand(Card[] cards)
        {
            this.cards = cards;
            counts = new Dictionary<int, int>();
        }

        bool IsFlush()
        { // same suit
            foreach (Card d in cards)
            {
                if (d.getSuit() != cards[0].getSuit())
                    return false;
            }
            return true;
        }

        bool IsStraightFlush()
        { // same suit and sequential
            return IsFlush() && IsStraight();
        }

        bool IsRoyalFlush()
        { // same suit
            return (IsStraightFlush() && cards[0].getRank() == 10
                && cards[cards.Length - 1].getRank() == 14);
        }

        bool IsFullHouse()
        {
            return IsThreeOfKind() && IsPair();
        }

        bool IsFourOfKind()
        {
            return counts.ContainsValue(4);
        }

        bool IsThreeOfKind()
        {
            return counts.ContainsValue(3);
        }

        bool IsTwoPairs()
        {
            int pair = 0;
            foreach (int i in counts.Values)
                if (i == 2) pair++;

            return pair == 2;
        }

        bool IsPair()
        {
            return counts.ContainsValue(2);
        }

        bool IsStraight()
        { // sequential
            for (int i = 1; i < cards.Length; i++)
            {
                if (cards[i].getRank() != cards[i - 1].getRank() + 1)
                    return false;
            }
            return true;
        }

        public Rank CheckType()
        {
            Array.Sort(cards);
            foreach (Card d in cards)
            {
                if (counts.ContainsKey(d.getRank()))
                    counts[d.getRank()] += 1;
                else
                    counts.Add(d.getRank(), 1);
            }
            Rank type = Rank.NONE;

            if (IsPair())
                type = Rank.PAIR;
            if (IsTwoPairs())
                type = Rank.TWO_PAIRS;
            if (IsThreeOfKind())
                type = Rank.THREE_KIND;
            if (IsStraight())
                type = Rank.STRAIGHT;
            if (IsFlush())
                type = Rank.FLUSH;
            if (IsFullHouse())
                type = Rank.FULL_HOUSE;
            if (IsFourOfKind())
                type = Rank.FOUR_KIND;
            if (IsStraightFlush())
                type = Rank.STRAIGHT_FLUSH;
            if (IsRoyalFlush())
                type = Rank.ROYAL_FLUSH;

            return type;
        }

        public Card[] getHand() { return cards; }

        public int CompareTo(object obj)
        {

            Hand player = obj as Hand;
            int score = (int)CheckType();
            int pScore = (int)player.CheckType();

            if (score > pScore) return 1;
            if (score < pScore) return -1;

            else
            { // check for tie breaker
                Card[] pCards = player.getHand();

                Array.Sort(cards);
                Array.Sort(pCards);

                for (int i = cards.Length - 1; i >= 0; i--)
                {
                    if (cards[i].CompareTo(pCards[i]) != 0)
                        return cards[i].CompareTo(pCards[i]);
                }

            }
            return 0;
        }
    }

}
