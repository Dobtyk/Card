using InstantGamesBridge;
using InstantGamesBridge.Modules.Advertisement;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] AudioMixer _audioMixer;
    [SerializeField] AudioSource _backgroundMusic;
    [SerializeField] AudioSource _click;

    public bool MusicIsMuted;
    public bool EffectsIsMuted;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Bridge.advertisement.interstitialStateChanged += AllMuteOrEnable;
    }

    public void PlaySoundOnClickButton()
    {
        _click.Play();
    }

    public void ToggleSound(string nameParameter)
    {
        _audioMixer.GetFloat(nameParameter, out float volume);
        _audioMixer.SetFloat(nameParameter, volume == 0 ? -80 : 0);
    }

    public void ToggleMusic(AudioClip clip)
    {
        _backgroundMusic.Stop();
        _backgroundMusic.clip = clip;
        _backgroundMusic.Play();
    }

    public void AllMuteOrEnable(InterstitialState state)
    {
        var volume = 0;
        if (state == InterstitialState.Opened)
        {
            volume = -80;
        }
        else if (state == InterstitialState.Closed || state == InterstitialState.Failed)
        {
            volume = 0;
        }
        _audioMixer.SetFloat("EffectsVolume", volume);
        _audioMixer.SetFloat("MusicVolume", volume);
    }
}