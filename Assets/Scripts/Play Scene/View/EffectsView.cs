using UnityEngine;

namespace Deck
{

    public class EffectsView : MonoBehaviour
    {
        [SerializeField] EffectView[] _buffs;

        public EffectView GetBuffView(int index)
        {
            return _buffs[index];
        }
    }
}