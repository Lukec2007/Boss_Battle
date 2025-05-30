using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HealingItem : MonoBehaviour
{
    [SerializeField] private int healAmount = 20; // Allows setting this in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {


        // Check if the collider belongs to the player by tag (optional but safer)
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
                Destroy(gameObject); // Destroys only this instance

                // After healing the player
                PlayerAudioManager audioManager = other.GetComponent<PlayerAudioManager>();
                if (audioManager != null)
                {
                    audioManager.PlayPickupPotionSound();
                }

            }
        }
    }
}
