using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyView : MonoBehaviour
{
    [SerializeField] TMP_Text _numberFight;
    [SerializeField] TMP_Text _minimumPoints;
    [SerializeField] TMP_Text _numberVictories;
    [SerializeField] TMP_Text _description;
    [SerializeField] Image _debuff;

    public string NumberFight
    {
        get => _numberFight.text;
        set => _numberFight.text = value;
    }

    public string MinimumPoints
    {
        get => _minimumPoints.text;
        set => _minimumPoints.text = value;
    }

    public string NumberVictories
    {
        get => _numberVictories.text;
        set => _numberVictories.text = value;
    }

    public string Description
    {
        get => _description.text;
        set => _description.text = value;
    }

    public Sprite Debuff
    {
        get => _debuff.sprite;
        set => _debuff.sprite = value;
    }
}
