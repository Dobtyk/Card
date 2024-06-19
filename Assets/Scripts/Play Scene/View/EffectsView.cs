using UnityEngine;

namespace Deck
{

    public class EffectsView : MonoBehaviour
    {
        [SerializeField] EffectView[] _effects;

        public EffectView GetEffectView(int index)
        {
            return _effects[index];
        }
    }
}