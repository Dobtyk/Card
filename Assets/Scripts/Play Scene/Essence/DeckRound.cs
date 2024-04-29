using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Deck
{
    public class DeckRound : IReadOnlyDeckRound
    {
        public event Action<List<SlotCard>> DeckRoundChanged;

        public List<SlotCard> CardsDeckRound 
        {
            get => _data.Cards;
            set
            {
                if (_data.Cards != value)
                {
                    _data.Cards = value;
                    DeckRoundChanged?.Invoke(value);
                }
            }
        }

        readonly DeckRoundData _data;

        public DeckRound(DeckRoundData data)
        {
            _data = data;
        }

        public List<SlotCard> TakeRandomCards(int amount)
        {
            var result = new List<SlotCard>();
            var random = new Random();
            for (var i = 0; i < amount; i++)
            {
                var value = random.Next(0, CardsDeckRound.Count - 1);
                result.Add(CardsDeckRound[value]);
                CardsDeckRound.RemoveAt(value);
            }
            return result;
        }
    }
}