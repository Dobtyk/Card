using UnityEngine;
using UnityEngine.UI;

public class TogglerView : MonoBehaviour
{
    [SerializeField] Image _line;

    public Image Line
    {
        get => _line;
        set => _line = value;
    }
}
