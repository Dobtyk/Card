using System;
using System.Collections.Generic;
using UnityEngine;

namespace Deck
{
    public enum BuffDifficulty
    {
        Light,
        Medium,
        Great
    }

    public enum BuffType
    { 
        StaticBuff,
        AfterCountingBuff,
        BeforeCountingBuff
    }

    public interface IReadOnlyBuff
    {
        event Action<bool> IsSelected;

        public string Description { get; }

        public BuffDifficulty Difficulty { get; }

        public BuffType Type { get; }

        public Sprite Sprite { get; }

        public bool IsSelect { get; }
    }

    public class Buff : IReadOnlyBuff
    {
        public string Description { get; set; }

        public BuffDifficulty Difficulty { get; set; }

        public BuffType Type { get; set; }

        public Sprite Sprite { get; set; }

        public bool IsSelect
        {
            get => _isSelect;
            set
            {
                if (_isSelect != value)
                {
                    _isSelect = value;
                    IsSelected?.Invoke(value);
                }
            }
        }

        bool _isSelect;

        public event Action<bool> IsSelected;

        public virtual void EnableEffectBuff()
        {
            
        }

        public virtual (int, double) EnableEffectBuff(List<SlotCard> list)
        {
            return (0, 0);
        }
    }
}