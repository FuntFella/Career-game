using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;

    void Start()
    {
        // Set slider to current volume
        slider.value = audioSource.volume;

        // Listen for slider changes
        slider.onValueChanged.AddListener(ChangeVolume);
    }

    void ChangeVolume(float value)
    {
        audioSource.volume = value;
    }
}
