using System;
using System.Collections.Generic;
using static Deck.FindPokerHand;

namespace Deck
{

    [Serializable]
    public class Buffs
    {
        public List<Buff> List = new List<Buff>
        {
            new Pair100(),
            new TwoPairs100(),
            new Set100(),
            new OnePair20(),
            new TwoPairs20(),
            new Get100(),
            new Straight150(),
            new Flush150(),
            new FullHouse200(),
            new FourofAKind200(),
            new Set25(),
            new Straight25(),
            new Flush30(),
            new FullHouse30(),
            new FourofAKind35(),
            new AmountHand1(),
            new AmountReset1(),
            new Factor4()
        };
    }

    public class Pair100 : Buff
    {
        public Pair100()
        {
            Description = "Очки +100, если рука содержит пару (после подсчёта очков)";
            Difficulty = BuffDifficulty.Light;
            Type = BuffType.AfterCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new OnePair().Check(hand))
            {
                return (100, 0);
            }
            return (0, 0);
        }
    }

    public class TwoPairs100 : Buff
    {
        public TwoPairs100()
        {
            Description = "Очки +100, если рука содержит две пары (после подсчёта очков)";
            Difficulty = BuffDifficulty.Light;
            Type = BuffType.AfterCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new TwoPairs().Check(hand))
            {
                return (100, 0);
            }
            return (0, 0);
        }
    }

    public class Set100 : Buff
    {
        public Set100()
        {
            Description = "Очки +100, если рука содержит тройку (после подсчёта очков)";
            Difficulty = BuffDifficulty.Light;
            Type = BuffType.AfterCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new Set().Check(hand))
            {
                return (100, 0);
            }
            return (0, 0);
        }
    }

    public class OnePair20 : Buff
    {
        public OnePair20()
        {
            Description = "Очки +20, множитель +1, если рука содержит пару (перед подсчётом очков)";
            Difficulty = BuffDifficulty.Light;
            Type = BuffType.BeforeCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new OnePair().Check(hand))
            {
                return (20, 1);
            }
            return (0, 0);
        }
    }

    public class TwoPairs20 : Buff
    {
        public TwoPairs20()
        {
            Description = "Очки +20, множитель +1.5, если рука содержит две пары (перед подсчётом очков)";
            Difficulty = BuffDifficulty.Light;
            Type = BuffType.BeforeCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new TwoPairs().Check(hand))
            {
                return (20, 1.5);
            }
            return (0, 0);
        }
    }

    public class Get100 : Buff
    {
        public Get100()
        {
            Description = "Очки +100 (после подсчёта очков)";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.AfterCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            return (100, 0);
        }
    }

    public class Straight150 : Buff
    {
        public Straight150()
        {
            Description = "Очки +150, если рука содержит стрит (после подсчёта очков)";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.AfterCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new Straight().Check(hand))
            {
                return (150, 0);
            }
            return (0, 0);
        }
    }

    public class Flush150 : Buff
    {
        public Flush150()
        {
            Description = "Очки +150, если рука содержит флеш (после подсчёта очков)";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.AfterCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new Flush().Check(hand))
            {
                return (150, 0);
            }
            return (0, 0);
        }
    }

    public class FullHouse200 : Buff
    {
        public FullHouse200()
        {
            Description = "Очки +200, если рука содержит фулл-хаус (после подсчёта очков)";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.AfterCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new FullHouse().Check(hand))
            {
                return (200, 0);
            }
            return (0, 0);
        }
    }

    public class FourofAKind200 : Buff
    {
        public FourofAKind200()
        {
            Description = "Очки +200, если рука содержит каре (после подсчёта очков)";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.AfterCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new FourofAKind().Check(hand))
            {
                return (200, 0);
            }
            return (0, 0);
        }
    }

    public class Set25 : Buff
    {
        public Set25()
        {
            Description = "Очки +25, множитель +2, если рука содержит тройку (перед подсчётом очков)";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.BeforeCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new Set().Check(hand))
            {
                return (25, 2);
            }
            return (0, 0);
        }
    }

    public class Straight25 : Buff
    {
        public Straight25()
        {
            Description = "Очки +25, множитель +2.5, если рука содержит стрит (перед подсчётом очков)";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.BeforeCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new Straight().Check(hand))
            {
                return (25, 2.5);
            }
            return (0, 0);
        }
    }

    public class AmountHand1 : Buff
    {
        public AmountHand1()
        {
            Description = "Количество рук +1";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.StaticBuff;
        }

        public override void EnableEffectBuff()
        {
            DataHolder.MaxAmountHands += 1;
        }
    }

    public class AmountReset1 : Buff
    {
        public AmountReset1()
        {
            Description = "Количество сбросов +1";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.StaticBuff;
        }

        public override void EnableEffectBuff()
        {
            DataHolder.MaxAmountResets += 1;
        }
    }

    public class Flush30 : Buff
    {
        public Flush30()
        {
            Description = "Очки +30, множитель +3, если рука содержит флеш (перед подсчётом очков)";
            Difficulty = BuffDifficulty.Great;
            Type = BuffType.BeforeCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new Flush().Check(hand))
            {
                return (30, 3);
            }
            return (0, 0);
        }
    }

    public class FullHouse30 : Buff
    {
        public FullHouse30()
        {
            Description = "Очки +30, множитель +3.5, если рука содержит фулл-хаус (перед подсчётом очков)";
            Difficulty = BuffDifficulty.Great;
            Type = BuffType.BeforeCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new FullHouse().Check(hand))
            {
                return (30, 3.5);
            }
            return (0, 0);
        }
    }

    public class FourofAKind35 : Buff
    {
        public FourofAKind35()
        {
            Description = "Очки +35, множитель +4, если рука содержит каре (перед подсчётом очков)";
            Difficulty = BuffDifficulty.Great;
            Type = BuffType.BeforeCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new FourofAKind().Check(hand))
            {
                return (35, 4);
            }
            return (0, 0);
        }
    }

    public class Factor4 : Buff
    {
        public Factor4()
        {
            Description = "Множитель + 4 (перед подсчётом очков)";
            Difficulty = BuffDifficulty.Great;
            Type = BuffType.BeforeCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            return (0, 4);
        }
    }
}