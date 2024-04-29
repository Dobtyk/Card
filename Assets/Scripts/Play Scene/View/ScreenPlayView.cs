using UnityEngine;

namespace Deck
{
    public class ScreenPlayView : MonoBehaviour
    {
        [SerializeField] PlayerHandView _playerHandView;
        [SerializeField] InformationPlayerView _informationPlayerView;

        public PlayerHandView PlayerHandView
        {
            get => _playerHandView;
        }

        public InformationPlayerView InformationPlayerView
        {
            get => _informationPlayerView;
        }
    }
}