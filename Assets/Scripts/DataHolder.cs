using System;

namespace Deck
{
    static public class DataHolder
    {
        public static int PlayerPointsOnLevel;       
        static public int MaxAmountHands;
        static public int MaxAmountResets;
        static public int MaxLevel;
        static public int CurrentLevel;
        static public int CurrentLevelPoints;
        static public Deck Deck = new Deck(new DeckData());

        static public int NumberResetsUsed;
        static public int NumberCardsPlayed;
        static public int TotalNumberPointsScored;
        static public string LastCombination;

    }
}