using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] private AudioClip hitByEnemyClip;
    [SerializeField] private AudioClip hitEnemyClip;
    [SerializeField] private AudioClip pickupPotionClip;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayHitByEnemySound()
    {
        PlaySound(hitByEnemyClip);
    }

    public void PlayHitEnemySound()
    {
        PlaySound(hitEnemyClip);
    }

    public void PlayPickupPotionSound()
    {
        PlaySound(pickupPotionClip);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
