using UnityEngine;

public class SetDifficultyInScene : MonoBehaviour
{
    [SerializeField] private BallController ballController;
    private void Awake()
    {
        if (PlayerPrefs.GetString("Difficulty") == "Easy")
            ballController.difficulty = 0;
        else if (PlayerPrefs.GetString("Difficulty") == "Medium")
            ballController.difficulty = 1;
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
            ballController.difficulty = 2;
    }
}
