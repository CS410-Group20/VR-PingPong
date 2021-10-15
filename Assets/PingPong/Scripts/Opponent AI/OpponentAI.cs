using System;
using UnityEngine;

public class OpponentAI : MonoBehaviour
{
    public Transform Ball;
    
    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Ball.position.x;
        pos.y = Ball.position.y;
        transform.position = pos;
    }
}
