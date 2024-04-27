using System;
using System.Collections.Generic;

namespace Deck
{
    [Serializable]
    public class DeckRoundData
    {
        public List<SlotCard> Cards = new();
    }
}