using TMPro;
using UnityEngine;

namespace Deck
{
    public class ScreenVictoryView : MonoBehaviour
    {
        [SerializeField] TMP_Text _amountPoints;
        [SerializeField] TMP_Text _nameBlind;
        [SerializeField] BuffsView _buffsView;

        public string AmountPoints
        {
            get => _amountPoints.text;
            set => _amountPoints.text = value;
        }

        public string NameBlind
        {
            get => _nameBlind.text;
            set => _nameBlind.text = value;
        }

        public BuffsView BuffsView
        {
            get => _buffsView;
            set => _buffsView = value;
        }
    }
}