using TMPro;
using UnityEngine;


public class FieldsRatingView : MonoBehaviour
{
    [SerializeField] FieldRatingView[] _fields;

    public FieldRatingView GetFieldRatingView(int index)
    {
        return _fields[index];
    }
}
