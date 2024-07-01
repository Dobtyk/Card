using UnityEngine;

public class TogglerEffectsController : MonoBehaviour
{
    [SerializeField] GameObject _togglerView;

    void Start()
    {
        _togglerView.SetActive(AudioManager.Instance.EffectsIsMuted);
    }

    public void Toggle(string nameParameter)
    {
        AudioManager.Instance.EffectsIsMuted = !AudioManager.Instance.EffectsIsMuted;
        AudioManager.Instance.ToggleSound(nameParameter);
        _togglerView.SetActive(!_togglerView.activeSelf);

    }
}
