using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    public Slider volumeSlider;
    private float currentVolume = 0;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("AudioValue"))
        {
            currentVolume = PlayerPrefs.GetFloat("AudioValue");
            volumeSlider.value = currentVolume;
            AudioListener.volume = currentVolume;
        }
        else
        {
            currentVolume = AudioListener.volume;
            volumeSlider.value = currentVolume;
            PlayerPrefs.SetFloat("AudioValue", currentVolume);
        }
    }

    void Start()
    {
        currentVolume = PlayerPrefs.GetFloat("AudioValue");
        AudioListener.volume = currentVolume;
        volumeSlider.value = currentVolume;
    }

    public void SetVolume()
    {
        // Update the volume based on the slider value
        AudioListener.volume = volumeSlider.value;
        currentVolume = AudioListener.volume;
        PlayerPrefs.SetFloat("AudioValue", currentVolume);
    }

    public void Mute()
    {
        // Mute or unmute the audio based on the toggle value
        volumeSlider.value = 0;
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("AudioValue", 0);
    }
}
