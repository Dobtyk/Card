using System;
using UnityEngine;

namespace Deck
{
    public class SlotCard : IReadOnlySlotCard
    {
        public event Action<SlotCard> SlotCardChanged;
        public event Action<bool> SlotCardChangedSelect;

        CardData _data;
        bool _isSelected;

        public SuitType Suit
        {
            get => _data.Suit;
            set
            {
                if (_data.Suit != value)
                {
                    _data.Suit = value;
                }
            }
        }

        public CardValueType CardValue
        {
            get => _data.CardValue;
            set
            {
                if (_data.CardValue != value)
                {
                    _data.CardValue = value;
                }
            }
        }
        public int Points
        {
            get => _data.Points;
            set
            {
                if (_data.Points != value)
                {
                    _data.Points = value;
                }
            }
        }

        public Sprite Sprite
        {
            get => _data.Sprite;
            set
            {
                if (_data.Sprite != value)
                {
                    _data.Sprite = value;
                    SlotCardChanged?.Invoke(this);
                }
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    SlotCardChangedSelect?.Invoke(_isSelected);
                }
            }
        }

        public SlotCard(CardData data)
        {
            _data = data;
            _isSelected = false;
        }
    }
}