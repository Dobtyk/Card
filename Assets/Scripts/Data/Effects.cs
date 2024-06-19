using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Deck.FindPokerHand;

namespace Deck
{
    
    [Serializable]
    public class Effects
    {
        public List<Effect> Buffs = new List<Effect>
        {
            new Pair100(),
            new TwoPairs100(),
            new Set100(),
            new Heart3(),
            new Club3(),
            new Diamond3(),
            new Spade3(),
            new OnePair20(),
            new TwoPairs20(),
            new Figure50(),
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
            new Hand150(),
            new Hand200(),
            new Figure2(),
            new Figure15(),
            new Factor4(),
            new Factor15(),
        };

        public List<Effect> Debuffs = new List<Effect>
        {
            new Heart(),
            new Diamond(),
            new Spade(),
            new Club(),
        };
    }

    public class UnknownDebuff : Effect
    {
        public UnknownDebuff()
        {
            Description = "����������";
            Sprite = Resources.Load<Sprite>("Effects/Debuffs/Unknown");
        }
    }

    public class UnknownBuff : Effect
    {
        public UnknownBuff()
        {
            Description = "����������";
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Unknown");
        }
    }

    public class Pair100 : Effect
    {
        public Pair100()
        {
            Id = 1;
            Description = "���� +100, ���� ���� �������� ���� (����� �������� �����)";
            Difficulty = BuffDifficulty.Light;
            Type = BuffType.AfterCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Pair100");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new OnePair().Check(hand))
            {
                return (100, 0, 1);
            }
            return (0, 0, 1);
        }
    }

    public class TwoPairs100 : Effect
    {
        public TwoPairs100()
        {
            Id = 2;
            Description = "���� +100, ���� ���� �������� ��� ���� (����� �������� �����)";
            Difficulty = BuffDifficulty.Light;
            Type = BuffType.AfterCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/TwoPairs100");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new TwoPairs().Check(hand))
            {
                return (100, 0, 1);
            }
            return (0, 0, 1);
        }
    }

    public class Set100 : Effect
    {
        public Set100()
        {
            Id = 3;
            Description = "���� +100, ���� ���� �������� ������ (����� �������� �����)";
            Difficulty = BuffDifficulty.Light;
            Type = BuffType.AfterCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Set100");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new Set().Check(hand))
            {
                return (100, 0, 1);
            }
            return (0, 0, 1);
        }
    }

    public class Heart3 : Effect
    {
        public Heart3()
        {
            Id = 4;
            Description = "��� ����� ����� ����� �������� +3 ���� � ����� ���������";
            Difficulty = BuffDifficulty.Light;
            Type = BuffType.StaticBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Heart3");
        }

        public override void EnableEffectBuff()
        {
            DataHolder.Deck.CardsDeck.Where(c => c.Suit == SuitType.Heart).ToList().ForEach(c => c.Points += 3);
        }
    }

    public class Diamond3 : Effect
    {
        public Diamond3()
        {
            Id = 5;
            Description = "��� ����� ����� ����� �������� +3 ���� � ����� ���������";
            Difficulty = BuffDifficulty.Light;
            Type = BuffType.StaticBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Diamond3");
        }

        public override void EnableEffectBuff()
        {
            DataHolder.Deck.CardsDeck.Where(c => c.Suit == SuitType.Diamond).ToList().ForEach(c => c.Points += 3);
        }
    }

    public class Club3 : Effect
    {
        public Club3()
        {
            Id = 6;
            Description = "��� ����� ����� ����� �������� +3 ���� � ����� ���������";
            Difficulty = BuffDifficulty.Light;
            Type = BuffType.StaticBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Club3");
        }

        public override void EnableEffectBuff()
        {
            DataHolder.Deck.CardsDeck.Where(c => c.Suit == SuitType.Club).ToList().ForEach(c => c.Points += 3);
        }
    }

    public class Spade3 : Effect
    {
        public Spade3()
        {
            Id = 7;
            Description = "��� ����� ����� ���� �������� +3 ���� � ����� ���������";
            Difficulty = BuffDifficulty.Light;
            Type = BuffType.StaticBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Spade3");
        }

        public override void EnableEffectBuff()
        {
            DataHolder.Deck.CardsDeck.Where(c => c.Suit == SuitType.Spade).ToList().ForEach(c => c.Points += 3);
        }
    }

    public class OnePair20 : Effect
    {
        public OnePair20()
        {
            Id = 8;
            Description = "���� +20, ��������� +1, ���� ���� �������� ���� (����� ��������� �����)";
            Difficulty = BuffDifficulty.Light;
            Type = BuffType.BeforeCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/OnePair20");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new OnePair().Check(hand))
            {
                return (20, 1, 1);
            }
            return (0, 0, 1);
        }
    }

    public class TwoPairs20 : Effect
    {
        public TwoPairs20()
        {
            Id = 9;
            Description = "���� +20, ��������� +1.5, ���� ���� �������� ��� ���� (����� ��������� �����)";
            Difficulty = BuffDifficulty.Light;
            Type = BuffType.BeforeCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/TwoPairs20");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new TwoPairs().Check(hand))
            {
                return (20, 1.5, 1);
            }
            return (0, 0, 1);
        }
    }

    public class Figure50 : Effect
    {
        public Figure50()
        {
            Id = 10;
            Description = "��� ����� ����, ������, ���� � ������ �������� +50 ����� � ����� ���������";
            Difficulty = BuffDifficulty.Great;
            Type = BuffType.StaticBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Figure50");
        }

        public override void EnableEffectBuff()
        {
            DataHolder.Deck.CardsDeck.Where(c => (int)c.CardValue >= 9 && (int)c.CardValue <= 12).ToList().ForEach(c => c.Points += 50);
        }
    }

    public class Get100 : Effect
    {
        public Get100()
        {
            Id = 11;
            Description = "���� +100 (����� �������� �����)";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.AfterCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Get100");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            return (100, 0, 1);
        }
    }

    public class AmountHand1 : Effect
    {
        public AmountHand1()
        {
            Id = 12;
            Description = "���������� ��� +1";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.StaticBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/AmountHand1");
        }

        public override void EnableEffectBuff()
        {
            DataHolder.MaxAmountHands += 1;
        }
    }

    public class AmountReset1 : Effect
    {
        public AmountReset1()
        {
            Id = 13;
            Description = "���������� ������� +1";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.StaticBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/AmountReset1");
        }

        public override void EnableEffectBuff()
        {
            DataHolder.MaxAmountResets += 1;
        }
    }

    public class Hand150 : Effect
    {
        public Hand150()
        {
            Id = 14;
            Description = "���� +150, ���� ���������� ������� �� 4-5 ���� (����� �������� �����)";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.AfterCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Hand150");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new Flush().Check(hand) || new Straight().Check(hand) || new FullHouse().Check(hand) || new FourofAKind().Check(hand) || new TwoPairs().Check(hand))
            {
                return (150, 0, 1);
            }
            return (0, 0, 1);
        }
    }

    public class Hand200 : Effect
    {
        public Hand200()
        {
            Id = 15;
            Description = "���� +200, ���� ���������� ������� �� 5 ���� (����� �������� �����)";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.AfterCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Hand200");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new Flush().Check(hand) || new Straight().Check(hand) || new FullHouse().Check(hand))
            {
                return (200, 0, 1);
            }
            return (0, 0, 1);
        }
    }

    public class Straight150 : Effect
    {
        public Straight150()
        {
            Id = 16;
            Description = "���� +150, ���� ���� �������� ����� (����� �������� �����)";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.AfterCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Straight150");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new Straight().Check(hand))
            {
                return (150, 0, 1);
            }
            return (0, 0, 1);
        }
    }

    public class Flush150 : Effect
    {
        public Flush150()
        {
            Id = 17;
            Description = "���� +150, ���� ���� �������� ���� (����� �������� �����)";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.AfterCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Flush150");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new Flush().Check(hand))
            {
                return (150, 0, 1);
            }
            return (0, 0, 1);
        }
    }

    public class FullHouse200 : Effect
    {
        public FullHouse200()
        {
            Id = 18;
            Description = "���� +200, ���� ���� �������� ����-���� (����� �������� �����)";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.AfterCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/FullHouse200");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new FullHouse().Check(hand))
            {
                return (200, 0, 1);
            }
            return (0, 0, 1);
        }
    }

    public class FourofAKind200 : Effect
    {
        public FourofAKind200()
        {
            Id = 19;
            Description = "���� +200, ���� ���� �������� ���� (����� �������� �����)";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.AfterCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/FourofAKind200");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new FourofAKind().Check(hand))
            {
                return (200, 0, 1);
            }
            return (0, 0, 1);
        }
    }

    public class Set25 : Effect
    {
        public Set25()
        {
            Id = 20;
            Description = "���� +25, ��������� +2, ���� ���� �������� ������ (����� ��������� �����)";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.BeforeCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Set25");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new Set().Check(hand))
            {
                return (25, 2, 1);
            }
            return (0, 0, 1);
        }
    }

    public class Straight25 : Effect
    {
        public Straight25()
        {
            Id = 21;
            Description = "���� +25, ��������� +2.5, ���� ���� �������� ����� (����� ��������� �����)";
            Difficulty = BuffDifficulty.Medium;
            Type = BuffType.BeforeCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Straight25");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new Straight().Check(hand))
            {
                return (25, 2.5, 1);
            }
            return (0, 0, 1);
        }
    }

    public class Flush30 : Effect
    {
        public Flush30()
        {
            Id = 22;
            Description = "���� +30, ��������� +3, ���� ���� �������� ���� (����� ��������� �����)";
            Difficulty = BuffDifficulty.Great;
            Type = BuffType.BeforeCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Flush30");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new Flush().Check(hand))
            {
                return (30, 3, 1);
            }
            return (0, 0, 1);
        }
    }

    public class FullHouse30 : Effect
    {
        public FullHouse30()
        {
            Id = 23;
            Description = "���� +30, ��������� +3.5, ���� ���� �������� ����-���� (����� ��������� �����)";
            Difficulty = BuffDifficulty.Great;
            Type = BuffType.BeforeCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/FullHouse30");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new FullHouse().Check(hand))
            {
                return (30, 3.5, 1);
            }
            return (0, 0, 1);
        }
    }

    public class FourofAKind35 : Effect
    {
        public FourofAKind35()
        {
            Id = 24;
            Description = "���� +35, ��������� +4, ���� ���� �������� ���� (����� ��������� �����)";
            Difficulty = BuffDifficulty.Great;
            Type = BuffType.BeforeCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/FourofAKind35");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new FourofAKind().Check(hand))
            {
                return (35, 4, 1);
            }
            return (0, 0, 1);
        }
    }

    public class Figure2 : Effect
    {
        public Figure2()
        {
            Id = 25;
            Description = "��� ������� � ���� ������� 1 ����� ����, ������, ���� ��� ������ ��������� *2 (����� ��������� �����)";
            Difficulty = BuffDifficulty.Great;
            Type = BuffType.BeforeCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Figure2");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (hand.Any(c => (int)c.CardValue >= 9 && (int)c.CardValue <= 12))
            {
                return (0, 0, 2);
            }
            return (0, 0, 1);
        }
    }

    public class Figure15 : Effect
    {
        public Figure15()
        {
            Id = 26;
            Description = "������ ����������� ����� ����, ������, ���� � ������ � ���������� ��� ��������� +1,5 (����� ��������� �����)";
            Difficulty = BuffDifficulty.Great;
            Type = BuffType.BeforeCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Figure15");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            var combinations = new ICombinationAnalyzer[] { new RoyalFlush(), new StraightFlush(), new FourofAKind(), new FullHouse(), new Flush(), new Straight(), new Set(), new TwoPairs(), new OnePair(), new HighCard() };
            var result = (0, combinations.FirstOrDefault(combination => combination.Check(hand)).Cards.Where(c => (int)c.CardValue >= 9 && (int)c.CardValue <= 12).Count() * 1.5, 1);
            return result;
        }
    }

    public class Factor4 : Effect
    {
        public Factor4()
        {
            Id = 27;
            Description = "��������� + 4 (����� ��������� �����)";
            Difficulty = BuffDifficulty.Great;
            Type = BuffType.BeforeCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Factor4");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            return (0, 4, 1);
        }
    }

    public class Factor15 : Effect
    {
        public Factor15()
        {
            Id = 28;
            Description = "��������� *15 ,���� ���������� - ������ (����� ��������� �����)";
            Difficulty = BuffDifficulty.Great;
            Type = BuffType.BeforeCountingBuff;
            Sprite = Resources.Load<Sprite>("Effects/Buffs/Factor15");
        }

        public override (int, double, double) EnableEffectBuff(List<SlotCard> hand)
        {
            if (new Set().Check(hand) && !new FourofAKind().Check(hand) && !new FullHouse().Check(hand))
            {
                return (0, 0, 15);
            }
            return (0, 0, 1);
        }
    }







    public class Heart : Effect
    {
        public Heart()
        {
            Id = 29;
            Description = "����� ����� ����� �� ����������� ��� ��������";
            Sprite = Resources.Load<Sprite>("Effects/Debuffs/Heart");
        }

        public override List<SlotCard> EnableEffectDebuff(List<SlotCard> hand)
        {
            return hand.Where(c => c.Suit != SuitType.Heart).ToList();
        }
    }

    public class Spade : Effect
    {
        public Spade()
        {
            Id = 30;
            Description = "����� ����� ���� �� ����������� ��� ��������";
            Sprite = Resources.Load<Sprite>("Effects/Debuffs/Spade");
        }

        public override List<SlotCard> EnableEffectDebuff(List<SlotCard> hand)
        {
            return hand.Where(c => c.Suit != SuitType.Spade).ToList();
        }
    }

    public class Diamond : Effect
    {
        public Diamond()
        {
            Id = 31;
            Description = "����� ����� ����� �� ����������� ��� ��������";
            Sprite = Resources.Load<Sprite>("Effects/Debuffs/Diamond");
        }

        public override List<SlotCard> EnableEffectDebuff(List<SlotCard> hand)
        {
            return hand.Where(c => c.Suit != SuitType.Diamond).ToList();
        }
    }

    public class Club : Effect
    {
        public Club()
        {
            Id = 32;
            Description = "����� ����� ����� �� ����������� ��� ��������";
            Sprite = Resources.Load<Sprite>("Effects/Debuffs/Club");
        }

        public override List<SlotCard> EnableEffectDebuff(List<SlotCard> hand)
        {
            return hand.Where(c => c.Suit != SuitType.Club).ToList();
        }
    }
}