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

            view.ImageSprite = slotCard.Sprite;
        }

        void OnSlotCardChanged(SlotCard card)
        {
            if (_view != null)
            {
                _view.ImageSprite = card.Sprite;
            }
        }

        public void OnSlotCardChangedSelect(bool isSelected)
        {
            if (_view != null)
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
}