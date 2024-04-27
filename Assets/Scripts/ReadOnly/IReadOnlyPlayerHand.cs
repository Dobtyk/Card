using System;
using System.Collections.Generic;

namespace Deck
{
    public interface IReadOnlyPlayerHand
    {
        event Action<List<SlotCard>> PlayerHandChanged;

        List<SlotCard> CardsPlayerHand { get; }

        IReadOnlySlotCard[] GetSlotsCard();
    }
}