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
            Description = "���� +100, ���� ���� �������� ���� (����� �������� �����)";
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
            Description = "���� +100, ���� ���� �������� ��� ���� (����� �������� �����)";
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
            Description = "���� +100, ���� ���� �������� ������ (����� �������� �����)";
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
            Description = "���� +20, ��������� +1, ���� ���� �������� ���� (����� ��������� �����)";
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
            Description = "���� +20, ��������� +1.5, ���� ���� �������� ��� ���� (����� ��������� �����)";
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
            Description = "���� +100 (����� �������� �����)";
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
            Description = "���� +150, ���� ���� �������� ����� (����� �������� �����)";
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
            Description = "���� +150, ���� ���� �������� ���� (����� �������� �����)";
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
            Description = "���� +200, ���� ���� �������� ����-���� (����� �������� �����)";
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
            Description = "���� +200, ���� ���� �������� ���� (����� �������� �����)";
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
            Description = "���� +25, ��������� +2, ���� ���� �������� ������ (����� ��������� �����)";
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
            Description = "���� +25, ��������� +2.5, ���� ���� �������� ����� (����� ��������� �����)";
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
            Description = "���������� ��� +1";
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
            Description = "���������� ������� +1";
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
            Description = "���� +30, ��������� +3, ���� ���� �������� ���� (����� ��������� �����)";
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
            Description = "���� +30, ��������� +3.5, ���� ���� �������� ����-���� (����� ��������� �����)";
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
            Description = "���� +35, ��������� +4, ���� ���� �������� ���� (����� ��������� �����)";
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
            Description = "��������� + 4 (����� ��������� �����)";
            Difficulty = BuffDifficulty.Great;
            Type = BuffType.BeforeCountingBuff;
        }

        public override (int, double) EnableEffectBuff(List<SlotCard> hand)
        {
            return (0, 4);
        }
    }
}