using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private InputDeviceCharacteristics controllerCharacteristics;
    [SerializeField] private float[] locations;
    [SerializeField] private SelectGameModes selectGameModes;
    [SerializeField] private Animator fadingImage;
    
    private bool menuOpen;

    private void Start()
    {
        PlayerPrefs.SetString("Difficulty", "Easy");
    }

    public void HoverOver(RectTransform ui)
    {
        int num;
        int.TryParse(ui.name, out num);
        LeanTween.moveLocalZ(ui.gameObject, locations[num], 10f * Time.deltaTime).setEaseInOutBack();
    }

    public void HoverExit(RectTransform ui)
    {
        int num;
        int.TryParse(ui.name, out num);
        LeanTween.moveLocalZ(ui.gameObject, locations[num + 1], 10f * Time.deltaTime).setEaseInOutBack();
    }

    public void ChangeScene(string sceneName)
    {
        if (PlayerPrefs.GetInt("Tutorial Done") == 1)
        {
            if (sceneName == "Play")
            {
                if (!menuOpen)
                {
                    selectGameModes.OpenGameModesMenu();
                    menuOpen = true;
                }
                else
                {
                    selectGameModes.CloseGameModesMenu();
                    menuOpen = false;
                }
            }
        }
        else
            OpenScene();
    }

    private void OpenScene()
    {
        fadingImage.Play("Fade In Image", -1, 0f);
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("Tutorial");
    }

    public void OpenItchPage()
    {
        Application.OpenURL("https://loopinteractive.itch.io/");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        OpenScene();
    }
}
