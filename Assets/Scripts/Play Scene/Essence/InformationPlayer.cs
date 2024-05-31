using System;

namespace Deck
{
    public class InformationPlayer : IReadOnlyInformationPlayer
    {
        public event Action<int> AmountHandsChanged;
        public event Action<int> AmountResetsChanged;
        public event Action<int> PointsPlayerChanged;
        public event Action<int> NumberCardsDeckRoundChanged;

        public int AmountHands
        {
            get => _data.AmountHands;
            set
            {
                if (_data.AmountHands != value)
                {
                    _data.AmountHands = value;
                    AmountHandsChanged?.Invoke(value);
                }
            }
        }

        public int AmountResets
        {
            get => _data.AmountResets;
            set
            {
                if (_data.AmountResets != value)
                {
                    _data.AmountResets = value;
                    AmountResetsChanged?.Invoke(value);
                }
            }
        }

        public int PointsPlayer
        {
            get => _data.PointsPlayer;
            set
            {
                if (_data.PointsPlayer != value)
                {
                    _data.PointsPlayer = value;
                    PointsPlayerChanged?.Invoke(value);
                }
            }
        }

        public int NumberCardsDeckRound
        {
            get => _data.NumberCardsDeckRound;
            set
            {
                if (_data.NumberCardsDeckRound != value)
                {
                    _data.NumberCardsDeckRound = value;
                    NumberCardsDeckRoundChanged?.Invoke(value);
                }
            }
        }

        readonly InformationPlayerData _data;

        public InformationPlayer(InformationPlayerData data)
        {
            _data = data;
        }
    }
}