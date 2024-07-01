using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    public void ClickSound()
    {
        AudioManager.Instance.PlaySoundOnClickButton();
    }
}
