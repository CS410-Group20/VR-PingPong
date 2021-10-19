using UnityEngine;

public class OpponentAI : MonoBehaviour
{
    public float speed;
    public float distance;
    public Transform Ball;

    public float leftSideMin;
    public float leftSideMax;
    public float rightSideMin;
    public float rightSideMax;
    
    private void Update()
    {
        bool isCloseToBall = transform.position.z - Ball.position.z < 1f;
        bool isBallOutOfBounds = Ball.position.y < .7f;

        if (isCloseToBall && !isBallOutOfBounds)
        {
            Vector3 pos = transform.position;
            pos.x = Ball.position.x;
            pos.y = Ball.position.y;
            transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);

            bool isLeft = Ball.position.x < -.1f;
            if (isLeft)
                transform.rotation = Quaternion.Euler(12.782f, Random.Range(leftSideMin, leftSideMax), -50.415f);
            else
                transform.rotation = Quaternion.Euler(12.782f, Random.Range(rightSideMin, rightSideMax), -50.415f);
        }
    }
}
