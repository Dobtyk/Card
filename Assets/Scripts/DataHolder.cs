using System.Collections.Generic;

namespace Deck
{
    static public class DataHolder
    {
        public static int PlayerPointsOnLevel;
        static public int MaxAmountHands;
        static public int MaxAmountResets;
        static public int MaxLevel;
        static public int CurrentLevel;
        static public Deck Deck;

        static public int NumberResetsUsed;
        static public int NumberCardsPlayed;
        static public int TotalNumberPointsScored;
        static public string LastCombination;

        static public List<Buff> Buffs;

        public static void InitializeNewGame()
        {
            DataHolder.CurrentLevel = 1;
            DataHolder.PlayerPointsOnLevel = 0;
            DataHolder.MaxAmountHands = 3;
            DataHolder.MaxAmountResets = 3;
            DataHolder.MaxLevel = 8;
            DataHolder.Deck = new Deck(new DeckData() { Cards = new DefaultDeck().Deck.Cards });
            DataHolder.Buffs = new List<Buff>();


            DataHolder.NumberResetsUsed = 0;
            DataHolder.NumberCardsPlayed = 0;
            DataHolder.TotalNumberPointsScored = 0;
            DataHolder.LastCombination = "";
        }
    }
}