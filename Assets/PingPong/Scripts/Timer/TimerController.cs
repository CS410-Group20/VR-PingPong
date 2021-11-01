using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField] private Text timerUI;
    
    private int timer = 90;

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
        }
    }
}
