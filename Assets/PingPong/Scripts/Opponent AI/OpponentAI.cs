using System;
using UnityEngine;

public class OpponentAI : MonoBehaviour
{
    public float speed;
    public float distance;
    public Transform Ball;
    
    private void Update()
    {
        bool isCloseToBall = transform.position.z - Ball.position.z < 1f;

        if (isCloseToBall)
        {
            Vector3 pos = transform.position;
            pos.x = Ball.position.x;
            pos.y = Ball.position.y;
            transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
        }
    }
}
