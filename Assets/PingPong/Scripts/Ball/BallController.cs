using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private int difficulty = 1;
    [SerializeField] private float[] gravity;
    [SerializeField] private float[] speed;
    [SerializeField] private float fakeBounce;
    [SerializeField] private Transform paddle;
    [SerializeField] private Animator points;
    
    private Rigidbody rb;
    private Vector3 oldPosition;
    private float playerSpeed;
    private float aiSpeed;
    private bool isHitByPlayer;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        CalculateSpeed();
    }

    private void CalculateSpeed()
    {
        Vector3 gravity = new Vector3(0f, this.gravity[difficulty], 0f);
        Physics.gravity = gravity;
        playerSpeed = aiSpeed = speed[difficulty];
    }

    private void FakeBounce()
    {
        // if (difficulty == 0)
        //     rb.AddForce(0f, fakeBounce, 0f);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Hit Area"))
        {
            points.Play("Points", -1, 0f);
                
            rb.useGravity = true;
            var hitArea = other.transform;
            rb.velocity = -hitArea.up * playerSpeed * Time.fixedDeltaTime;
        }
        else if (other.transform.CompareTag("Table"))
            FakeBounce();
        else if (other.transform.CompareTag("Wall"))
        {
            rb.velocity = other.transform.up * aiSpeed * Time.fixedDeltaTime;
            points.Play("PointsHide", -1, 0f);
        }

        if (other.transform.CompareTag("Indicator"))
            other.transform.GetComponent<GameMode1>().ChangePosition();
    }

    private enum tags
    {
        Paddle
    }
}
