using System;
using System.Collections.Generic;

namespace Deck
{
    public class PlayerHand : IReadOnlyPlayerHand
    {
        public event Action<List<SlotCard>> PlayerHandChanged;

        public List<SlotCard> CardsPlayerHand
        {
            get => _data.Cards;
            set
            {
                if (_data.Cards != value)
                {
                    _data.Cards = value;
                    PlayerHandChanged?.Invoke(value);
                }
            }
        }

        readonly PlayerHandData _data;

        public PlayerHand(PlayerHandData data)
        {
            _data = data;
        }

        public IReadOnlySlotCard[] GetSlotsCard()
        {
            var result = new SlotCard[_data.Cards.Count];
            for (var i = 0; i < _data.Cards.Count; i++)
            {
                result[i] = _data.Cards[i];
            }
            return result;
        }
    }
}