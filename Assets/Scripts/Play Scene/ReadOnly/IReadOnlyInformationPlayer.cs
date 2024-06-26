using System;

namespace Deck
{
    public interface IReadOnlyInformationPlayer
    {
        event Action<int> AmountHandsChanged;
        event Action<int> AmountResetsChanged;
        event Action<int> PointsPlayerChanged;
        event Action<int> NumberCardsDeckRoundChanged;

        public int AmountHands { get; }
        public int AmountResets { get; }
        public int PointsPlayer { get; }
        public int NumberCardsDeckRound {  get; }
    }
}