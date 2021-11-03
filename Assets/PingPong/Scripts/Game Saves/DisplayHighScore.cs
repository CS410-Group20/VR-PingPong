using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour
{
    [SerializeField] private string difficulty;
    [SerializeField] private int gameMode;
    
    private void Start()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt(difficulty + " High " + gameMode).ToString();
    }
}
