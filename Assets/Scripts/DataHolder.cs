using System.Collections.Generic;

namespace Deck
{
    static public class DataHolder
    {
        static public int MaxAmountHands;
        static public int MaxAmountResets;
        static public int MaxLevel;
        static public int CurrentLevel;
        static public Deck Deck;

        static public int NumberResetsUsed;
        static public int NumberCardsPlayed;
        static public int TotalNumberPointsScored;
        static public string LastCombination;

        static public List<Effect> Buffs;
        static public Effect Debuff;

        public static void InitializeNewGame()
        {
            CurrentLevel = 1;
            MaxAmountHands = 3;
            MaxAmountResets = 3;
            MaxLevel = 8;
            Deck = new Deck(new DeckData() { Cards = new DefaultDeck().Deck.Cards });
            Buffs = new List<Effect>();
            Debuff = null;


            NumberResetsUsed = 0;
            NumberCardsPlayed = 0;
            TotalNumberPointsScored = 0;
            LastCombination = "";
        }
    }
}