using System;
using System.Collections.Generic;

namespace Deck
{
    [Serializable]
    public class PlayerHandData
    {
        public List<SlotCard> Cards = new();
    }
}