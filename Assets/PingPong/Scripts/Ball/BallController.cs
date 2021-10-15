using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    public float AiSpeed;

    private Rigidbody rb;

    private Vector3 oldPosition;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Time.timeScale = .7f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Hit Area"))
        {
            rb.useGravity = true;
            rb.velocity = -other.transform.up * speed * Time.fixedDeltaTime;
        }

        if (other.transform.CompareTag("Wall"))
        {
            rb.velocity = other.transform.up * AiSpeed * Time.fixedDeltaTime;
        }
    }

    private enum tags
    {
        Paddle
    }
}
