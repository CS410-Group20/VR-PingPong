using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void HoverOverPlay(RectTransform ui)
    {
        LeanTween.moveLocalZ(ui.gameObject, 1f, 10f * Time.deltaTime).setEaseInOutBack();
    }

    public void HoverExitPlay(RectTransform ui)
    {
        LeanTween.moveLocalZ(ui.gameObject, 2.9f, 10f * Time.deltaTime).setEaseInOutBack();
    }
    
    
    public void HoverOverQuit(RectTransform ui)
    {
        LeanTween.moveLocalZ(ui.gameObject, 21f, 10f * Time.deltaTime).setEaseInOutBack();
    }

    public void HoverExitQuit(RectTransform ui)
    {
        LeanTween.moveLocalZ(ui.gameObject, 23f, 10f * Time.deltaTime).setEaseInOutBack();
    }
    
    
    public void HoverOverTutorial(RectTransform ui)
    {
        LeanTween.moveLocalZ(ui.gameObject, 13f, 10f * Time.deltaTime).setEaseInOutBack();
    }

    public void HoverExitTutorial(RectTransform ui)
    {
        LeanTween.moveLocalZ(ui.gameObject, 15.7f, 10f * Time.deltaTime).setEaseInOutBack();
    }
    
    
    public void HoverOverLoop(RectTransform ui)
    {
        LeanTween.moveLocalZ(ui.gameObject, 33f, 10f * Time.deltaTime).setEaseInOutBack();
    }

    public void HoverExitLoop(RectTransform ui)
    {
        LeanTween.moveLocalZ(ui.gameObject, 34.4f, 10f * Time.deltaTime).setEaseInOutBack();
    }
    //
    //
    //
    //

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
