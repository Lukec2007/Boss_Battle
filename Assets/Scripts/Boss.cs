using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f; // Speed at which the boss moves
    public bool isFlipped = false;

    private void Update()
    {
        MoveTowardsPlayer();
        LookAtPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Move the boss towards the player's position (including Y-axis)
        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 move = new Vector3(direction.x, direction.y, 0f) * moveSpeed * Time.deltaTime;

        transform.position += move;
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
