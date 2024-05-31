using TMPro;
using UnityEngine;

public class BuffView : MonoBehaviour
{
    [SerializeField] TMP_Text _description;

    public string Description
    {
        get => _description.text;
        set => _description.text = value;
    }
}
