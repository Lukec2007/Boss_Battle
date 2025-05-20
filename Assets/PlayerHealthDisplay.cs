using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    public PlayerHealth playerHealth;  // Reference to your player health script
    public Text healthText;            // Reference to the UI Text component

    void Update()
    {
        if (playerHealth != null && healthText != null)
        {
            healthText.text = "Health: " + playerHealth.currentHealth.ToString();
        }
    }
}
