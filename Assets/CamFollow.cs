using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;    // Assign the player transform in Inspector
    public float followSpeed = 5f;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 newPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}
