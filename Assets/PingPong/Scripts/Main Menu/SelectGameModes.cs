using UnityEngine;
using UnityEngine.UI;

public class SelectGameModes : MonoBehaviour
{
    [SerializeField] private float oldYPosition;
    [SerializeField] private float newYPosition;
    [SerializeField] private BoxCollider[] gameModeButtons;
    [SerializeField] private Image[] gameModesIcons;
    [SerializeField] private GameObject[] buttons;

    public void OpenGameModesMenu()
    {
        LeanTween.moveLocalY(gameObject, newYPosition, 20f * Time.deltaTime).setEaseInQuad();
        for (int i = 0; i < 2; i++)
        {
            gameModeButtons[i].enabled = true;
            gameModesIcons[i].GetComponent<Animator>().Play("Fade In Icons", -1, 0f);
            buttons[i].GetComponent<BoxCollider>().enabled = false;
            buttons[i + 1].GetComponent<BoxCollider>().enabled = false;
            buttons[i].GetComponent<Animator>().Play("Fade Text", -1, 0f);
            buttons[i + 1].GetComponent<Animator>().Play("Fade Text", -1, 0f);
        }
    }

    public void CloseGameModesMenu()
    {
        LeanTween.moveLocalY(gameObject, oldYPosition, 20f * Time.deltaTime).setEaseInQuad();
        for (int i = 0; i < 2; i++)
        {
            gameModeButtons[i].enabled = false;
            gameModesIcons[i].GetComponent<Animator>().Play("Fade Icons", -1, 0f);
            buttons[i].GetComponent<BoxCollider>().enabled = true;
            buttons[i + 1].GetComponent<BoxCollider>().enabled = true;
            buttons[i].GetComponent<Animator>().Play("Fade In Text", -1, 0f);
            buttons[i + 1].GetComponent<Animator>().Play("Fade In Text", -1, 0f);
        }
    }
}
