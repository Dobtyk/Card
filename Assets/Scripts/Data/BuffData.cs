using System.Collections.Generic;

namespace Deck
{
    public enum BuffDifficulty
    {
        Light,
        Medium,
        Great
    }

    public interface IBuff
    {
        public string Description { get; }

        public BuffDifficulty Type { get; }

    }

    public interface IStaticBuff : IBuff
    {
        public void EnableBuff();
    }

    public interface IAfterCountingBuff : IBuff
    {
        public void PlayBuff(IReadOnlyList<SlotCard> hand);
    }

    public interface IBeforeCountingBuff : IBuff
    {
        public void PlayBuff(IReadOnlyList<SlotCard> hand);
    }
}