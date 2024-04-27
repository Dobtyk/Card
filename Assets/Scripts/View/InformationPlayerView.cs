using TMPro;
using UnityEngine;

namespace Deck
{
    public class InformationPlayerView : MonoBehaviour
    {
        [SerializeField] TMP_Text _amountHands;
        [SerializeField] TMP_Text _amountResets;
        [SerializeField] TMP_Text _pointsPlayer;
        [SerializeField] CurrentCombinationView _currentCombinationView;

        public string AmountHands
        {
            get => _amountHands.text;
            set => _amountHands.text = value;
        }

        public string AmountResets
        {
            get => _amountResets.text;
            set => _amountResets.text = value;
        }

        public string PointsPlayer
        {
            get => _pointsPlayer.text;
            set => _pointsPlayer.text = value;
        }

        public CurrentCombinationView CurrentCombinationView
        {
            get => _currentCombinationView;
        }
    }
}