using System;
using System.Collections.Generic;

namespace Deck
{
    public interface IReadOnlyDeck
    {
        event Action<List<SlotCard>> DeckChanged;

        List<SlotCard> CardsDeck { get; }
    }
}