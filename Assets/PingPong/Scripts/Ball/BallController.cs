using UnityEngine;

public class BallController : MonoBehaviour
{
    public int difficulty = 1;

    private Rigidbody rb;

    private Vector3 oldPosition;
    private float speed;
    private float AiSpeed;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (difficulty == 1)
        {
            Time.timeScale = .7f;
            speed = AiSpeed = 420f;
        }
        else if (difficulty == 0)
        {
            Time.timeScale = .4f;
            speed = AiSpeed = 800f;
        }
        else
        {
            Time.timeScale = 1f;
            speed = AiSpeed = 300f;
        }
        if (difficulty != 2)
            Time.fixedDeltaTime = 0.02f * Time.timeScale;

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
