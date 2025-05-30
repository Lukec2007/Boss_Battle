using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    private const string VolumeKey = "VolumeLevel";

    void Start()
    {
        // Load saved volume or set default
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        audioSource.volume = savedVolume;
        volumeSlider.value = savedVolume;

        // Add listener to slider
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat(VolumeKey, value); // Save volume
    }

    private void OnDestroy()
    {
        // Clean up listener
        volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
    }
}



