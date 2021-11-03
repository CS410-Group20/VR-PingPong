using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public int HAND;
   
    private InputDevice targetDevice;
    private Animator hand;
    private Transform ball;
    private int LEFT = 0;
    private int RIGHT = 1;

    private Vector3 enemyPos;
    
    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").transform;

        enemyPos = GameObject.FindGameObjectWithTag("Wall").transform.position;
        
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if (devices.Count > 0)
            targetDevice = devices[0];

        hand = GetComponent<Animator>();
    }

    private void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.grip, out float trigger);
        if (trigger > .1f)
            hand.SetFloat("Hold", -trigger);
        else
            hand.SetFloat("Hold", 0f);
        
        ResetBallPosition();
    }

    private void ResetBallPosition()
    {
        if (ball.GetComponent<BallController>().bringBackBall)
        {
            targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed);
            if (!pressed) return;
            ball.position = enemyPos;
            ball.GetComponent<Rigidbody>().useGravity = true;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<BallController>().bringBackBall = false;
            ball.GetComponent<BallController>().pressA.SetActive(false);
        }
    }
    
}
