using System;
using UnityEngine;

namespace Deck
{
    public interface IReadOnlySlotCard
    {
        event Action<SlotCard> SlotCardChanged;
        event Action<bool> SlotCardChangedSelect;

        SuitType Suit { get; }
        CardValueType CardValue { get; }
        int Points { get; }
        Sprite Sprite { get; }
    }
}