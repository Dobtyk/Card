using System;
using System.Collections.Generic;

namespace Deck
{

    [Serializable]
    public class Buffs
    {
        public class Pair100 : IAfterCountingBuff
        {
            public string Description => "Очки +100, если рука содержит пару (после подсчёта очков)";

            public BuffDifficulty Type => BuffDifficulty.Light;

            public void PlayBuff(IReadOnlyList<SlotCard> hand)
            {
                if (hand.Count > 0)
                {

                }
            }
        }
    }
}