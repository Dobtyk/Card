using System;
using System.Collections.Generic;

namespace Deck
{
    [Serializable]
    public class CombinationData
    {
        public string Name;
        public int Chips;
        public int Factor;
        public List<SlotCard> Cards;
    }
}