using UnityEngine;
using UnityEngine.UI;

public class PersistentAudioSettings : MonoBehaviour
{
    public static PersistentAudioSettings Instance;

    public AudioSource audioSource;
    public Slider volumeSlider;

    private const string VolumePrefKey = "AudioSourceVolume";

    private void Awake()
    {
        // Singleton pattern to persist across scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(VolumePrefKey, 1f);

        if (audioSource != null)
            audioSource.volume = savedVolume;

        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    public void SetVolume(float volume)
    {
        if (audioSource != null)
            audioSource.volume = volume;

        PlayerPrefs.SetFloat(VolumePrefKey, volume);
    }
}
