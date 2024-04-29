using System;
using System.Collections.Generic;

namespace Deck
{
    [Serializable]
    public class DeckData
    {
        public List<SlotCard> Cards = new();
    }
}