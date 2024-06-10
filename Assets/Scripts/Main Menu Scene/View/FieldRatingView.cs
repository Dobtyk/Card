using TMPro;
using UnityEngine;


public class FieldRatingView : MonoBehaviour
{
    [SerializeField] TMP_Text _textName;
    [SerializeField] TMP_Text _textPoints;

    public string TextName
    {
        get => _textName.text;
        set => _textName.text = value;
    }

    public string TextPoints
    {
        get => _textPoints.text;
        set => _textPoints.text = value;
    }
}
