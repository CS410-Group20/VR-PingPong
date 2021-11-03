using UnityEngine;

public class SetHighScore : MonoBehaviour
{
    [SerializeField] private int gameMode;
    
    public void CheckScore(int score)
    {
        if (score > PlayerPrefs.GetInt(PlayerPrefs.GetString("Difficulty") + " High " + gameMode))
            PlayerPrefs.SetInt(PlayerPrefs.GetString("Difficulty") + " High " + gameMode, score);
    }
}
