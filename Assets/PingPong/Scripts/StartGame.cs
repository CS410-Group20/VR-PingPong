using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
