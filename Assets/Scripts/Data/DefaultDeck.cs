using System;
using System.Collections.Generic;

namespace Deck
{
    [Serializable]
    public class DefaultDeck
    {
        public DeckData Deck = new DeckData
        {
            Cards = new List<SlotCard>
            {
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Two, Points = 2}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Three, Points = 3}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Four, Points = 4}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Five, Points = 5}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Six, Points = 6}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Seven, Points = 7}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Eight, Points = 8}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Nine, Points = 9}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Ten, Points = 10}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Jack, Points = 10}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Queen, Points = 10}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.King, Points = 10}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Ace, Points = 11}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Two, Points = 2}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Three, Points = 3}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Four, Points = 4}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Five, Points = 5}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Six, Points = 6}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Seven, Points = 7}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Eight, Points = 8}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Nine, Points = 9}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Ten, Points = 10}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Jack, Points = 10}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Queen, Points = 10}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.King, Points = 10}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Ace, Points = 11}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Two, Points = 2}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Three, Points = 3}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Four, Points = 4}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Five, Points = 5}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Six, Points = 6}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Seven, Points = 7}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Eight, Points = 8}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Nine, Points = 9}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Ten, Points = 10}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Jack, Points = 10}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Queen, Points = 10}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.King, Points = 10}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Ace, Points = 11}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Two, Points = 2}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Three, Points = 3}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Four, Points = 4}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Five, Points = 5}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Six, Points = 6}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Seven, Points = 7}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Eight, Points = 8}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Nine, Points = 9}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Ten, Points = 10}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Jack, Points = 10}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Queen, Points = 10}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.King, Points = 10}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Ace, Points = 11})
            }
        };
    }
}