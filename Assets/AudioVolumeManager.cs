using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioVolumeManager : MonoBehaviour
{
    public static AudioVolumeManager Instance;

    public float Volume { get; private set; } = 1f;

    private const string VolumeKey = "AudioSourceVolume";

    private void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Load volume from PlayerPrefs
        Volume = PlayerPrefs.GetFloat(VolumeKey, 1f);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Delay initialization to allow UI to load
        Invoke(nameof(ApplyVolumeToScene), 0.1f);
    }

    public void SetVolume(float volume)
    {
        Volume = volume;
        PlayerPrefs.SetFloat(VolumeKey, volume);
        PlayerPrefs.Save();

        ApplyVolumeToScene();
    }

    private void ApplyVolumeToScene()
    {
        // Update AudioSource
        AudioSource source = FindObjectOfType<AudioSource>();
        if (source != null)
        {
            source.volume = Volume;
        }
        else
        {
            Debug.LogWarning("No AudioSource found in scene.");
        }

        // Update Slider
        Slider slider = FindObjectOfType<Slider>();
        if (slider != null)
        {
            slider.SetValueWithoutNotify(Volume);
            slider.onValueChanged.RemoveAllListeners();
            slider.onValueChanged.AddListener(SetVolume);
        }
        else
        {
            Debug.LogWarning("No Slider found in scene.");
        }
    }
}
