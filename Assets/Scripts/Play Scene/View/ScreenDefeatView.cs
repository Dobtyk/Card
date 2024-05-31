using TMPro;
using UnityEngine;

namespace Deck
{
    public class ScreenDefeatView : MonoBehaviour
    {
        [SerializeField] TMP_Text _lastCombination;
        [SerializeField] TMP_Text _numberPointsScored;
        [SerializeField] TMP_Text _numberResetsUsed;
        [SerializeField] TMP_Text _numberCardsPlayed;

        public string LastCombination
        {
            get => _lastCombination.text;
            set => _lastCombination.text = value;
        }

        public string NumberPointsScored
        {
            get => _numberPointsScored.text;
            set => _numberPointsScored.text = value;
        }

        public string NumberResetsUsed
        {
            get => _numberResetsUsed.text;
            set => _numberResetsUsed.text = value;
        }

        public string NumberCardsPlayed
        {
            get => _numberCardsPlayed.text;
            set => _numberCardsPlayed.text = value;
        }
    }
}