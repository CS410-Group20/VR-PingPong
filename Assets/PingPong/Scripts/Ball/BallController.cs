using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    private Vector3 oldPosition;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Hit Area"))
        {
            rb.useGravity = true;
            rb.velocity = -other.transform.up * speed * Time.deltaTime;
        }

        if (other.transform.CompareTag("Wall"))
        {
            rb.velocity = other.transform.up * speed * Time.deltaTime;
        }
    }

    private enum tags
    {
        Paddle
    }
}
