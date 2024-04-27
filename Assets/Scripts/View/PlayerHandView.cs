using UnityEngine;

namespace Deck
{

    public class PlayerHandView : MonoBehaviour
    {
        [SerializeField] SlotCardView[] _cards;

        public SlotCardView GetCardView(int index)
        {
            return _cards[index];
        }
    }
}