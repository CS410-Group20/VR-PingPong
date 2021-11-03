using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField] private Text timerUI;
    [SerializeField] private OpponentAI opponentAI;
    [SerializeField] private PointsCounter pointsCounter;
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private int timer = 90;

    private void Start()
    {
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
    }
}
