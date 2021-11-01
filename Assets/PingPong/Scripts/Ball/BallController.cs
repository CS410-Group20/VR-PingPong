using System;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public bool bringBackBall;
    public GameObject pressA;

    [SerializeField] private int difficulty = 1;
    [SerializeField] private float[] gravity;
    [SerializeField] private float[] speed;
    [SerializeField] private float fakeBounce;
    [SerializeField] private Transform paddle;
    [SerializeField] private Animator pointsAnimator;
    [SerializeField] private PointsCounter pointsCounter;

    private Rigidbody rb;
    private Vector3 oldPosition;
    private float playerSpeed;
    private float aiSpeed;
    private bool isHitByPlayer;
    private Quaternion paddleRotation;
    private Vector3 positionAtHit;
    private Vector3 ballStartPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        ballStartPosition = transform.position;
        
        CalculateSpeed();
    }

    private void CalculateSpeed()
    {
        Vector3 gravity = new Vector3(0f, this.gravity[difficulty], 0f);
        Physics.gravity = gravity;
        playerSpeed = aiSpeed = speed[difficulty];
    }

    private void CalculatePoints()
    {
        //pointsAnimator.Play("PointsHide", -1, 0f);
        pointsCounter.StopIncreasing();
    }
    
    private void FakeBounce()
    {
        if (difficulty == 0)
        {
            Vector3 dir = (transform.position - positionAtHit).normalized;
            
            rb.velocity = transform.up + dir * fakeBounce * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Table"))
            FakeBounce();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Hit Area"))
        {
            //pointsAnimator.Play("Points", -1, 0f);

            positionAtHit = transform.position;
            
            rb.useGravity = true;
            var hitArea = other.transform;
            rb.velocity = -hitArea.up * playerSpeed * Time.fixedDeltaTime;
            pointsCounter.IncreasePoints();
        }
        else if (other.transform.CompareTag("Wall"))
        {
            rb.velocity = other.transform.up * aiSpeed * Time.fixedDeltaTime;
            CalculatePoints();
            
            positionAtHit = transform.position;
        }

        if (other.transform.CompareTag("Bounds"))
        {
            bringBackBall = true;
            pressA.SetActive(true);
            CalculatePoints();
        }

        if (other.transform.CompareTag("Indicator"))
        {
            if (other.transform.GetComponent<GameMode1>())
                other.transform.GetComponent<GameMode1>().ChangePosition();
            else
                other.transform.GetComponent<GameMode2>().ChangePosition();
            pointsCounter.points += 100;
            pointsCounter.plus100Animation.Play("plus100", -1, 0f);
        }
    }

    private enum tags
    {
        Paddle
    }
}
