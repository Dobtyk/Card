using System;
using System.Collections.Generic;

namespace Deck
{
    public interface IReadOnlyCurrentCombination
    {
        event Action<string> CurrentCombinationNameChanged;

        public string Name { get; }
        public int Chips { get; }
        public int Factor { get; }
    }
}