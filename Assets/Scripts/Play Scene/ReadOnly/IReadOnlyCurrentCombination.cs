using System;
using System.Collections.Generic;

namespace Deck
{
    public interface IReadOnlyCurrentCombination
    {
        event Action<string> CurrentCombinationNameChanged;
        event Action<int> CurrentCombinationChipsChanged;
        event Action<int> CurrentCombinationFactorChanged;

        public string Name { get; }
        public int Chips { get; }
        public int Factor { get; }
        List<SlotCard> Cards { get; }
    }
}