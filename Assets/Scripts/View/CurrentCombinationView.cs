using TMPro;
using UnityEngine;

public class CurrentCombinationView : MonoBehaviour
{
    [SerializeField] TMP_Text _nameCombination;
    [SerializeField] TMP_Text _factor;
    [SerializeField] TMP_Text _chips;

    public string NameCombination
    {
        get => _nameCombination.text;
        set => _nameCombination.text = value;
    }

    public string Factor
    {
        get => _factor.text;
        set => _factor.text = value;
    }

    public string Chips
    {
        get => _chips.text;
        set => _chips.text = value;
    }
}
