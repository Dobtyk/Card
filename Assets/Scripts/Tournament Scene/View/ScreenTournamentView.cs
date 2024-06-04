using Deck;
using UnityEngine;

public class ScreenTournamentView : MonoBehaviour
{
    [SerializeField] ItemsView _itemsView;
    [SerializeField] BuffsView _buffsView;
    [SerializeField] EnemyView _enemyView;
    [SerializeField] EnemyView _enemyViewDebuff;
    [SerializeField] GameObject _indicator;

    public ItemsView ItemsView
    {
        get => _itemsView;
        set => _itemsView = value;
    }

    public BuffsView BuffsView
    {
        get => _buffsView;
        set => _buffsView = value;
    }

    public EnemyView EnemyView
    {
        get => _enemyView;
        set => _enemyView = value;
    }

    public EnemyView EnemyViewDebuff
    {
        get => _enemyViewDebuff;
        set => _enemyViewDebuff = value;
    }

    public GameObject Indicator
    {
        get => _indicator;
        set => _indicator = value;
    }
}
