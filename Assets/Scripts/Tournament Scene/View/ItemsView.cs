using UnityEngine;

namespace Deck
{
    public class ItemsView : MonoBehaviour
    {
        [SerializeField] ItemView[] _items;

        public ItemView GetItemView(int index)
        {
            return _items[index];
        }
    }
}