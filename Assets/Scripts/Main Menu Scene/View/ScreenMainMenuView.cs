using Deck;
using UnityEngine;


public class ScreenMainMenuView : MonoBehaviour
{
    [SerializeField] EffectsView _buffsView;
    [SerializeField] EffectsView _debuffsView;
    [SerializeField] FieldsRatingView _fieldsRatingView;

    public EffectsView BuffsView
    {
        get => _buffsView;
        set => _buffsView = value;
    }

    public EffectsView DebuffsView
    {
        get => _debuffsView;
        set => _debuffsView = value;
    }

    public FieldsRatingView FieldsRatingView
    {
        get => _fieldsRatingView;
        set => _fieldsRatingView = value;
    }
}
