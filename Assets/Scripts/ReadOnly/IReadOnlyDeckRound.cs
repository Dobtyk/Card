using System;
using System.Collections.Generic;

namespace Deck
{
    public interface IReadOnlyDeckRound
    {
        event Action<List<SlotCard>> DeckRoundChanged;

        List<SlotCard> CardsDeckRound { get; }
    }
}