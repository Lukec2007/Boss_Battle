using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public int healAmount = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
