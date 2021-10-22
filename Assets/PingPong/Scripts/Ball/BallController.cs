using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private int difficulty = 1;
    [SerializeField] private float[] gravity;
    [SerializeField] private float[] speed;
    
    private Rigidbody rb;
    private Vector3 oldPosition;
    private float playerSpeed;
    private float AiSpeed;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        CalculateSpeed();
    }

    private void CalculateSpeed()
    {
        Vector3 gravity = new Vector3(0f, this.gravity[difficulty], 0f);
        Physics.gravity = gravity;
        playerSpeed = AiSpeed = speed[difficulty];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Hit Area"))
        {
            rb.useGravity = true;
            rb.velocity = -other.transform.up * playerSpeed * Time.fixedDeltaTime;
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
