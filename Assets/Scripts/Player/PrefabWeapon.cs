using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f; // Time in seconds between shots

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Optional: null check
        PlayerAudioManager audioManager = FindObjectOfType<PlayerAudioManager>();
        if (audioManager != null)
        {
            audioManager.PlayHitEnemySound();
        }

        Debug.Log("shoot");
    }
}
