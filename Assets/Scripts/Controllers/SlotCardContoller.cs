using UnityEngine;

namespace Deck
{
    public class SlotCardController
    {
        readonly SlotCardView _view;
        const int extraHeightRaisedCard = 63;
        public SlotCardController(IReadOnlySlotCard slotCard, SlotCardView view)
        {
            _view = view;
            slotCard.SlotCardChanged += OnSlotCardChanged;
            slotCard.SlotCardChangedSelect += OnSlotCardChangedSelect;
            //view.ImageSprite = slotCard.Sprite;
            view.Text = slotCard.Suit.ToString() + "\n" + slotCard.CardValue.ToString();
        }

        void OnSlotCardChanged(SlotCard card)
        {
            //_view.ImageSprite = card.Sprite;
            _view.Text = card.Suit.ToString() + "\n" + card.CardValue.ToString();
        }

        public void OnSlotCardChangedSelect(bool isSelected)
        {
            var x = _view.transform.localPosition.x;
            var y = _view.transform.localPosition.y;
            var z = _view.transform.localPosition.z;
            if (isSelected)
            {
                _view.transform.localPosition = new Vector3 { x = x, y = y + extraHeightRaisedCard, z = z };
            }
            else
            {
                _view.transform.localPosition = new Vector3 { x = x, y = y - extraHeightRaisedCard, z = z };
            }
        }
    }
}