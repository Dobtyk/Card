using System;
using System.Collections.Generic;

namespace Deck
{
    public class Deck : IReadOnlyDeck
    {
        public event Action<List<SlotCard>> DeckChanged;

        public List<SlotCard> CardsDeck
        {
            get => _data.Cards;
            set
            {
                if (_data.Cards != value)
                {
                    _data.Cards = value;
                    DeckChanged?.Invoke(value);
                }
            }
        }

        readonly DeckData _data;

        public Deck(DeckData data)
        {
            _data = data;
        }
    }
}