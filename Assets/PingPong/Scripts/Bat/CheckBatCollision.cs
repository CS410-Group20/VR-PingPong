using UnityEngine;

public class CheckBatCollision : MonoBehaviour
{
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bounds"))
            transform.position = startPosition;
    }
}
