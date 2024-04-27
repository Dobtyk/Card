using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Deck
{

    public class SlotCardView : MonoBehaviour
    {
        [SerializeField] Image _image;
        [SerializeField] TMP_Text _text;

        public Sprite ImageSprite
        {
            get => _image.sprite;
            set => _image.sprite = value;
        }

        public string Text
        {
            get => _text.text;
            set => _text.text = value;
        }
    }
}