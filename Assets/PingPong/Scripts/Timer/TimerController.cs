using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class TimerController : MonoBehaviour
{
    [SerializeField] private InputDeviceCharacteristics controllerCharacteristics;
    [SerializeField] private Text timerUI;
    [SerializeField] private OpponentAI opponentAI;
    [SerializeField] private PointsCounter pointsCounter;
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private GameObject ball;
    [SerializeField] private int timer = 90;
    [SerializeField] private GameObject continueText;
    [SerializeField] private Animator image;
    [SerializeField] private SetHighScore setHighScore;
    
    private InputDevice targetDevice;
    
    private void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        
        if (devices.Count > 0)
            targetDevice = devices[0];
        InvokeRepeating("ReduceTime", 1f, 1f);
    }

    private void ReduceTime()
    {
        if (timer > 0)
        {
            timer--;
            timerUI.text = timer + "s";
            if (timer <= 10)
            {
                timerUI.fontSize = 206;
                timerUI.transform.parent.GetComponent<Animator>().Play("Timer Red", -1, 0f);
            }
        }
        else
            EndGame();
    }

    private void EndGame()
    {
        opponentAI.enabled = false;
        pointsCounter.enabled = false;
        endGameUI.SetActive(true);
        ball.SetActive(false);
        StartCoroutine(Delay());
        setHighScore.CheckScore(pointsCounter.points);
    }

    private void Update()
    {
        if (!continueText.activeInHierarchy) return;
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed);
        if (!pressed) return;
        ChangeScene();
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        continueText.SetActive(true);
    }
    
    private void ChangeScene()
    {
        image.Play("Fade In Image", -1, 0f);
        StartCoroutine(LoadScene());
    }
    
    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Start Menu");
    }
    

}
