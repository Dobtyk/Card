using System;

namespace Deck
{
    public class CurrentCombination : IReadOnlyCurrentCombination
    {
        public event Action<string> CurrentCombinationNameChanged;
        public event Action<int> CurrentCombinationChipsChanged;
        public event Action<int> CurrentCombinationFactorChanged;

        public string Name
        {
            get => _data.Name;
            set
            {
                if (_data.Name != value)
                {
                    _data.Name = value;
                    CurrentCombinationNameChanged?.Invoke(value);
                }
            }
        }

        public int Chips
        {
            get => _data.Chips;
            set
            {
                if (_data.Chips != value)
                {
                    _data.Chips = value;
                    CurrentCombinationChipsChanged?.Invoke(value);
                }
            }
        }

        public int Factor
        {
            get => _data.Factor;
            set
            {
                if (_data.Factor != value)
                {
                    _data.Factor = value;
                    CurrentCombinationFactorChanged?.Invoke(value);
                }
            }
        }

        public CombinationData _data;

        public CurrentCombination(CombinationData data)
        {
            _data = data;
        }
    }
}