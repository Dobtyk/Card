using UnityEngine;

namespace Deck
{
    public class ScreenPlayView : MonoBehaviour
    {
        [SerializeField] PlayerHandView _playerHandView;
        [SerializeField] InformationPlayerView _informationPlayerView;
        [SerializeField] EffectsView _buffsView;

        public PlayerHandView PlayerHandView
        {
            get => _playerHandView;
        }

        public InformationPlayerView InformationPlayerView
        {
            get => _informationPlayerView;
        }

        public EffectsView BuffsView
        {
            get => _buffsView;
            set => _buffsView = value;
        }
    }
}