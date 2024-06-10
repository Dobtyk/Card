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

    public interface IReadOnlyEffect
    {
        event Action<bool> IsSelected;

        public string Description { get; }

        public BuffDifficulty Difficulty { get; }

        public BuffType Type { get; }

        public Sprite Sprite { get; }

        public bool IsSelect { get; }

        public int Id { get;  }
    }

    public class Effect : IReadOnlyEffect
    {
        public string Description { get; set; }

        public BuffDifficulty Difficulty { get; set; }

        public BuffType Type { get; set; }

        public Sprite Sprite { get; set; }

        public int Id { get; set; }

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

        /// <returns> ортеж, где 1-ый элемент - количество, добавл€емых к очкам, где 2-ой элемент - количество, добавл€емых к множителю, где 3-ий элемент - количество, умножаемое на множитель.</returns>
        public virtual (int, double, double) EnableEffectBuff(List<SlotCard> list)
        {
            return (0, 0, 0);
        }

        public virtual List<SlotCard> EnableEffectDebuff(List<SlotCard> list)
        {
            return null;
        }
    }
}