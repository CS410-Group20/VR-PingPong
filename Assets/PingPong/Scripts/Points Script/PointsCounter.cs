using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{
    public int points;
    public Animator plus100Animation;

    [SerializeField] private Text pointsText;
    [SerializeField] private float countSpeed;

    private bool isIncreasing;
    private bool skip;
    
    public void IncreasePoints()
    {
        isIncreasing = true;
    }

    public void StopIncreasing()
    {
        isIncreasing = false;
    }
    
    private void Update()
    {
        if (isIncreasing && !skip)
        {
            StartCoroutine(Delay());
            skip = true;
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(countSpeed);
        points++;
        pointsText.text = points.ToString();
        skip = false;
    }
}
