using UnityEngine;
using UnityEngine.UI;

public class EffectView : MonoBehaviour
{
    [SerializeField] TooltipTextUI _description;
    [SerializeField] Image _image;

    public Sprite ImageSprite
    {
        get => _image.sprite;
        set => _image.sprite = value;
    }

    public string Description
    {
        get => _description.text;
        set => _description.text = value;
    }
}
