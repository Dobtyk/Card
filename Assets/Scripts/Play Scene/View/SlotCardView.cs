using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Deck
{

    public class SlotCardView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] Image _image;
        int originalSortingOrder;

        public Sprite ImageSprite
        {
            get => _image.sprite;
            set => _image.sprite = value;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            originalSortingOrder = GetComponent<RectTransform>().GetSiblingIndex();

            GetComponent<RectTransform>().SetSiblingIndex(transform.parent.childCount - 1);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            GetComponent<RectTransform>().SetSiblingIndex(originalSortingOrder);
        }
    }
}