using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

namespace Deck
{
    public class FindPokerHand
    {
        public interface ICombinationAnalyzer
        {
            string Name { get; }
            int Chips { get; }
            int Factor { get; }
            bool Check(IReadOnlyList<SlotCard> hand);
        }

        public class RoyalFlush : ICombinationAnalyzer
        {
            public string Name => "RoyalFlush";

            public int Chips => 100;

            public int Factor => 10;

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 5)
                    return false;
                var flush = hand.GroupBy(c => c.Suit).Count() == 1;

                var royal = false;
                if (flush)
                {
                    var sortedHand = hand.OrderBy(c => c.CardValue).ToArray();
                    royal = sortedHand[0].CardValue == CardValueType.Ace && sortedHand[1].CardValue == CardValueType.King && sortedHand[2].CardValue == CardValueType.Queen && sortedHand[3].CardValue == CardValueType.Jack && sortedHand[4].CardValue == CardValueType.Ten;
                }
                return flush && royal;
            }
        }

        public class StraightFlush : ICombinationAnalyzer
        {
            public string Name => "StraightFlush";

            public int Chips => 80;

            public int Factor => 8;

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                return new Flush().Check(hand) && new Straight().Check(hand);
            }
        }

        public class FourofAKind : ICombinationAnalyzer
        {
            public string Name => "FourofAKind";

            public int Chips => 60;

            public int Factor => 70;

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 4)
                    return false;
                return hand.GroupBy(c => c.CardValue).Any(g => g.Count() >= 4);
            }
        }

        public class FullHouse : ICombinationAnalyzer
        {
            public string Name => "FullHouse";

            public int Chips => 40;

            public int Factor => 4;

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 5)
                    return false;
                return hand.GroupBy(c => c.CardValue).Count() == 2 && hand.GroupBy(c => c.CardValue).Any(g => g.Count() == 3);
            }
        }
        
        public class Flush : ICombinationAnalyzer
        {
            public string Name => "Flush";

            public int Chips => 35;

            public int Factor => 4;

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 5)
                    return false;
                return hand.GroupBy(c => c.Suit).Count() == 1;
            }
        }

        public class Straight : ICombinationAnalyzer
        {
            public string Name => "Straight";

            public int Chips => 30;

            public int Factor => 4;

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 5)
                    return false;
                var sortedHand = hand.OrderBy(c => c.CardValue).ToArray();
                if ((int)sortedHand[0].CardValue == (int)sortedHand[1].CardValue - 1 && (int)sortedHand[1].CardValue == (int)sortedHand[2].CardValue - 1 && (int)sortedHand[2].CardValue == (int)sortedHand[3].CardValue - 1 && (int)sortedHand[3].CardValue == (int)sortedHand[4].CardValue - 1)
                    return true;
                return false;
            }
        }

        public class Set : ICombinationAnalyzer
        {
            public string Name => "Set";

            public int Chips => 30;

            public int Factor => 3;

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 3)
                    return false;
                return hand.GroupBy(c => c.CardValue).Any(g => g.Count() >= 3); ;
            }
        }

        public class TwoPairs : ICombinationAnalyzer
        {
            public string Name => "TwoPairs";

            public int Chips => 20;

            public int Factor => 2;

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 4)
                    return false;
                return hand.GroupBy(c => c.CardValue).Count(g => g.Count() >= 2) == 2;
            }
        }

        public class OnePair : ICombinationAnalyzer
        {
            public string Name => "OnePair";

            public int Chips => 10;

            public int Factor => 2;

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 2)
                    return false;
                return hand.GroupBy(c => c.CardValue).Any(g => g.Count() >= 2);
            }
        }

        public class HighCard : ICombinationAnalyzer
        {
            public string Name => "HighCard";

            public int Chips => 5;

            public int Factor => 1;

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 1)
                    return false;
                return true;
            }
        }

        static public class AnalyzeCombinations
        {
            static readonly ICombinationAnalyzer[] _combinations = new ICombinationAnalyzer[] { new RoyalFlush(), new StraightFlush(), new FourofAKind(), new FullHouse(), new Flush(), new Straight(), new Set(), new TwoPairs(), new OnePair(), new HighCard() };

            static public (string, int, int) Check(IReadOnlyList<SlotCard> hand)
            {
                var result = _combinations.FirstOrDefault(combination => combination.Check(hand));
                if (result.IsUnityNull())
                    return ("", 0, 0);
                return (result.Name, result.Chips, result.Factor);
            }
        }
    }
}