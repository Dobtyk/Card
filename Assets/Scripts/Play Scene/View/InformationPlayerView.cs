using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Deck
{
    public class InformationPlayerView : MonoBehaviour
    {
        [SerializeField] TMP_Text _amountHands;
        [SerializeField] TMP_Text _amountResets;
        [SerializeField] TMP_Text _pointsPlayer;
        [SerializeField] TMP_Text _numberlevel;
        [SerializeField] TMP_Text _currentLevelPoints;
        [SerializeField] TMP_Text _nameBlind;
        [SerializeField] TMP_Text _numberCardsDeckRound;
        [SerializeField] CurrentCombinationView _currentCombinationView;
        [SerializeField] Image _icon;

        public Sprite Icon
        {
            get => _icon.sprite;
            set => _icon.sprite = value;
        }

        public string NumberCardsDeckRound
        {
            get => _numberCardsDeckRound.text;
            set => _numberCardsDeckRound.text = value;
        }

        public string NameBlind
        {
            get => _nameBlind.text;
            set => _nameBlind.text = value;
        }

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

        public string NumberLevel
        {
            get => _numberlevel.text;
            set => _numberlevel.text = value;
        }

        public string CurrentLevelPoints
        {
            get => _currentLevelPoints.text;
            set => _currentLevelPoints.text = value;
        }

        public CurrentCombinationView CurrentCombinationView
        {
            get => _currentCombinationView;
        }
    }
}