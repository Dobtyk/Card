using UnityEngine;

public class TogglerMusicController : MonoBehaviour
{
    [SerializeField] GameObject _togglerView;

    void Start()
    {
        _togglerView.SetActive(AudioManager.Instance.MusicIsMuted);
    }

    public void Toggle(string nameParameter)
    {
        AudioManager.Instance.MusicIsMuted = !AudioManager.Instance.MusicIsMuted;
        AudioManager.Instance.ToggleSound(nameParameter);
        _togglerView.SetActive(!_togglerView.activeSelf);

    }
}
