using System;
using System.Collections.Generic;
using UnityEngine;

namespace Deck
{
    [Serializable]
    public class DefaultDeck
    {
        public DeckData Deck = new DeckData
        {
            Cards = new List<SlotCard>
            {
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Two, Points = 2, Sprite = Resources.Load<Sprite>("Cards/HeartTwo")}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Three, Points = 3, Sprite = Resources.Load<Sprite>("Cards/HeartThree")}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Four, Points = 4, Sprite = Resources.Load<Sprite>("Cards/HeartFour")}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Five, Points = 5, Sprite = Resources.Load<Sprite>("Cards/HeartFive")}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Six, Points = 6, Sprite = Resources.Load<Sprite>("Cards/HeartSix")}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Seven, Points = 7, Sprite = Resources.Load<Sprite>("Cards/HeartSeven")}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Eight, Points = 8, Sprite = Resources.Load<Sprite>("Cards/HeartEight")}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Nine, Points = 9, Sprite = Resources.Load<Sprite>("Cards/HeartNine")}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Ten, Points = 10, Sprite = Resources.Load<Sprite>("Cards/HeartTen")}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Jack, Points = 10, Sprite = Resources.Load<Sprite>("Cards/HeartJack")}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Queen, Points = 10, Sprite = Resources.Load<Sprite>("Cards/HeartQueen")}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.King, Points = 10, Sprite = Resources.Load<Sprite>("Cards/HeartKing")}),
                new SlotCard(new CardData {Suit = SuitType.Heart, CardValue = CardValueType.Ace, Points = 11, Sprite = Resources.Load<Sprite>("Cards/HeartAce")}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Two, Points = 2, Sprite = Resources.Load<Sprite>("Cards/SpadeTwo")}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Three, Points = 3, Sprite = Resources.Load<Sprite>("Cards/SpadeThree")}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Four, Points = 4, Sprite = Resources.Load<Sprite>("Cards/SpadeFour")}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Five, Points = 5, Sprite = Resources.Load<Sprite>("Cards/SpadeFive")}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Six, Points = 6, Sprite = Resources.Load<Sprite>("Cards/SpadeSix")}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Seven, Points = 7, Sprite = Resources.Load<Sprite>("Cards/SpadeSeven")}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Eight, Points = 8, Sprite = Resources.Load<Sprite>("Cards/SpadeEight")}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Nine, Points = 9, Sprite = Resources.Load<Sprite>("Cards/SpadeNine")}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Ten, Points = 10, Sprite = Resources.Load<Sprite>("Cards/SpadeTen")}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Jack, Points = 10, Sprite = Resources.Load<Sprite>("Cards/SpadeJack")}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Queen, Points = 10, Sprite = Resources.Load<Sprite>("Cards/SpadeQueen")}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.King, Points = 10, Sprite = Resources.Load<Sprite>("Cards/SpadeKing")}),
                new SlotCard(new CardData {Suit = SuitType.Spade, CardValue = CardValueType.Ace, Points = 11, Sprite = Resources.Load<Sprite>("Cards/SpadeAce")}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Two, Points = 2, Sprite = Resources.Load<Sprite>("Cards/DiamondTwo")}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Three, Points = 3, Sprite = Resources.Load<Sprite>("Cards/DiamondThree")}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Four, Points = 4, Sprite = Resources.Load<Sprite>("Cards/DiamondFour")}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Five, Points = 5, Sprite = Resources.Load<Sprite>("Cards/DiamondFive")}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Six, Points = 6, Sprite = Resources.Load<Sprite>("Cards/DiamondSix")}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Seven, Points = 7, Sprite = Resources.Load<Sprite>("Cards/DiamondSeven")}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Eight, Points = 8, Sprite = Resources.Load<Sprite>("Cards/DiamondEight")}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Nine, Points = 9, Sprite = Resources.Load<Sprite>("Cards/DiamondNine")}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Ten, Points = 10, Sprite = Resources.Load<Sprite>("Cards/DiamondTen")}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Jack, Points = 10, Sprite = Resources.Load<Sprite>("Cards/DiamondJack")}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Queen, Points = 10, Sprite = Resources.Load<Sprite>("Cards/DiamondQueen")}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.King, Points = 10, Sprite = Resources.Load<Sprite>("Cards/DiamondKing")}),
                new SlotCard(new CardData {Suit = SuitType.Diamond, CardValue = CardValueType.Ace, Points = 11, Sprite = Resources.Load<Sprite>("Cards/DiamondAce")}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Two, Points = 2, Sprite = Resources.Load<Sprite>("Cards/ClubTwo")}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Three, Points = 3, Sprite = Resources.Load<Sprite>("Cards/ClubThree")}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Four, Points = 4, Sprite = Resources.Load<Sprite>("Cards/ClubFour")}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Five, Points = 5, Sprite = Resources.Load<Sprite>("Cards/ClubFive")}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Six, Points = 6, Sprite = Resources.Load<Sprite>("Cards/ClubSix")}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Seven, Points = 7, Sprite = Resources.Load<Sprite>("Cards/ClubSeven")}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Eight, Points = 8, Sprite = Resources.Load<Sprite>("Cards/ClubEight")}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Nine, Points = 9, Sprite = Resources.Load<Sprite>("Cards/ClubNine")}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Ten, Points = 10, Sprite = Resources.Load<Sprite>("Cards/ClubTen")}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Jack, Points = 10, Sprite = Resources.Load<Sprite>("Cards/ClubJack")}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Queen, Points = 10, Sprite = Resources.Load<Sprite>("Cards/ClubQueen")}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.King, Points = 10, Sprite = Resources.Load<Sprite>("Cards/ClubKing")}),
                new SlotCard(new CardData {Suit = SuitType.Club, CardValue = CardValueType.Ace, Points = 11, Sprite = Resources.Load<Sprite>("Cards/ClubAce")}),
            }
        };
    }
}