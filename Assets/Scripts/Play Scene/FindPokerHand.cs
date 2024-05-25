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
            List<SlotCard> Cards { get; }
            bool Check(IReadOnlyList<SlotCard> hand);
        }

        public class RoyalFlush : ICombinationAnalyzer
        {
            public string Name => "Флеш-рояль";

            public int Chips => 100;

            public int Factor => 10;

            public List<SlotCard> Cards => _cards;

            List<SlotCard> _cards = new List<SlotCard>();

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 5)
                    return false;
                var flush = hand.GroupBy(c => c.Suit).Count() == 1;
                var royal = false;
                if (flush)
                {
                    var sortedHand = hand.OrderBy(c => c.CardValue).ToArray();
                    royal = sortedHand[0].CardValue == CardValueType.Ten && sortedHand[1].CardValue == CardValueType.Jack && sortedHand[2].CardValue == CardValueType.Queen && sortedHand[3].CardValue == CardValueType.King && sortedHand[4].CardValue == CardValueType.Ace;
                }
                
                if (flush && royal)
                {
                    _cards = hand.ToList();
                }

                return flush && royal;
            }
        }

        public class StraightFlush : ICombinationAnalyzer
        {
            public string Name => "Стрит-флеш";

            public int Chips => 80;

            public int Factor => 8;

            public List<SlotCard> Cards => _cards;

            List<SlotCard> _cards = new List<SlotCard>();

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                var result = new Flush().Check(hand) && new Straight().Check(hand);

                if (result)
                {
                    _cards = hand.ToList();
                }

                return result;
            }
        }

        public class FourofAKind : ICombinationAnalyzer
        {
            public string Name => "Каре";

            public int Chips => 60;

            public int Factor => 7;

            public List<SlotCard> Cards => _cards;

            List<SlotCard> _cards = new List<SlotCard>();

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 4)
                    return false;

                var result = hand.GroupBy(c => c.CardValue).Any(g => g.Count() >= 4);

                if (result)
                {
                    _cards = hand.GroupBy(c => c.CardValue).FirstOrDefault(g => g.Count() >= 4).ToList();
                }

                return result;
            }
        }

        public class FullHouse : ICombinationAnalyzer
        {
            public string Name => "Фул-хаус";

            public int Chips => 40;

            public int Factor => 4;

            public List<SlotCard> Cards => _cards;

            List<SlotCard> _cards = new List<SlotCard>();

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 5)
                    return false;

                var result = hand.GroupBy(c => c.CardValue).Count() == 2 && hand.GroupBy(c => c.CardValue).Any(g => g.Count() == 3);

                if (result)
                {
                    _cards = hand.ToList();
                }

                return result;
            }
        }

        public class Flush : ICombinationAnalyzer
        {
            public string Name => "Флеш";

            public int Chips => 35;

            public int Factor => 4;

            public List<SlotCard> Cards => _cards;

            List<SlotCard> _cards = new List<SlotCard>();

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 5)
                    return false;

                var result = hand.GroupBy(c => c.Suit).Count() == 1;

                if (result)
                {
                    _cards = hand.ToList();
                }

                return result;
            }
        }

        public class Straight : ICombinationAnalyzer
        {
            public string Name => "Стрит";

            public int Chips => 30;

            public int Factor => 4;

            public List<SlotCard> Cards => _cards;

            List<SlotCard> _cards = new List<SlotCard>();

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 5)
                    return false;

                var sortedHand = hand.OrderBy(c => c.CardValue).ToArray();
                var result = (sortedHand[0].CardValue == CardValueType.Two && sortedHand[1].CardValue == CardValueType.Three && sortedHand[2].CardValue == CardValueType.Four && sortedHand[3].CardValue == CardValueType.Five && sortedHand[4].CardValue == CardValueType.Ace) || ((int)sortedHand[0].CardValue == (int)sortedHand[1].CardValue - 1 && (int)sortedHand[1].CardValue == (int)sortedHand[2].CardValue - 1 && (int)sortedHand[2].CardValue == (int)sortedHand[3].CardValue - 1 && (int)sortedHand[3].CardValue == (int)sortedHand[4].CardValue - 1);

                if (result)
                {
                    _cards = hand.ToList();
                }

                return result;
            }
        }

        public class Set : ICombinationAnalyzer
        {
            public string Name => "Тройка";

            public int Chips => 30;

            public int Factor => 3;

            public List<SlotCard> Cards => _cards;

            List<SlotCard> _cards = new List<SlotCard>();

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 3)
                    return false;

                var result = hand.GroupBy(c => c.CardValue).Any(g => g.Count() >= 3);

                if (result)
                {
                    _cards = hand.GroupBy(c => c.CardValue).FirstOrDefault(g => g.Count() >= 3).ToList();
                }

                return result;
            }
        }

        public class TwoPairs : ICombinationAnalyzer
        {
            public string Name => "Две пары";

            public int Chips => 20;

            public int Factor => 2;

            public List<SlotCard> Cards => _cards;

            List<SlotCard> _cards = new List<SlotCard>();

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 4)
                    return false;

                var result = hand.GroupBy(c => c.CardValue).Count(g => g.Count() >= 2) == 2;

                if (result)
                {
                    _cards = hand.GroupBy(c => c.CardValue).Where(g => g.Count() >= 2).SelectMany(g => g).ToList();
                }

                return result;
            }
        }

        public class OnePair : ICombinationAnalyzer
        {
            public string Name => "Одна пара";

            public int Chips => 10;

            public int Factor => 2;

            public List<SlotCard> Cards => _cards;

            List<SlotCard> _cards = new List<SlotCard>();

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 2)
                    return false;

                var result = hand.GroupBy(c => c.CardValue).Any(g => g.Count() >= 2);

                if (result)
                {
                    _cards = hand.GroupBy(c => c.CardValue).FirstOrDefault(g => g.Count() >= 2).ToList();
                }

                return result;
            }
        }

        public class HighCard : ICombinationAnalyzer
        {
            public string Name => "Старшая карта";

            public int Chips => 5;

            public int Factor => 1;

            public List<SlotCard> Cards => _cards;

            List<SlotCard> _cards = new List<SlotCard>();

            public bool Check(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count < 1)
                    return false;

                _cards = hand.Where(c => c.CardValue == hand.Max(c => c.CardValue)).ToList();

                return true;
            }
        }

        static public class AnalyzeCombinations
        {
            static readonly ICombinationAnalyzer[] _combinations = new ICombinationAnalyzer[] { new RoyalFlush(), new StraightFlush(), new FourofAKind(), new FullHouse(), new Flush(), new Straight(), new Set(), new TwoPairs(), new OnePair(), new HighCard() };

            static public (string, int, int, List<SlotCard>) Check(IReadOnlyList<SlotCard> hand)
            {
                var result = _combinations.FirstOrDefault(combination => combination.Check(hand));
                if (result.IsUnityNull())
                    return ("", 0, 0, null);
                return (result.Name, result.Chips, result.Factor, result.Cards);
            }
        }
    }
}