using UnityEngine;

namespace Deck
{

    public class BuffsView : MonoBehaviour
    {
        [SerializeField] BuffView[] _buffs;

        public BuffView GetBuffView(int index)
        {
            return _buffs[index];
        }
    }
}