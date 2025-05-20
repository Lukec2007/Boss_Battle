using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        BossHealth enemy = hitInfo.GetComponent<BossHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 0.5f); // Destroy the impact effect after 2 seconds

        Destroy(gameObject); // Destroy the bullet immediately (or adjust timing if needed)
    }
}
