using TMPro;
using UnityEngine;

public class ItemView : MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    public string Text
    {
        get => _text.text;
        set => _text.text = value;
    }
}
