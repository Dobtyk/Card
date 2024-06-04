using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] Image _image;
    [SerializeField] Image _field;

    public Image ImageSprite
    {
        get => _image;
        set => _image = value;
    }

    public Sprite Field
    {
        get => _field.sprite;
        set => _field.sprite = value;
    }

    public TMP_Text Text
    {
        get => _text;
        set => _text = value;
    }
}
