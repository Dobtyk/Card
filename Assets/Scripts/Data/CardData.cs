using System;
using UnityEngine;

namespace Deck
{
    public enum SuitType
    {
        Diamond,
        Club,
        Heart,
        Spade
    }

    public enum CardValueType
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    [Serializable]
    public class CardData
    {
        public SuitType Suit;
        public CardValueType CardValue;
        public int Points;
        public Sprite Sprite;
    }
}