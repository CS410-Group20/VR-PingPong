using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private InputDeviceCharacteristics controllerCharacteristics;
    [SerializeField] private float[] locations;
    
    private InputDevice targetDevice;
    private RectTransform activeRectTransform;

    private void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        
        if (devices.Count > 0)
            targetDevice = devices[0];
    }

    public void HoverOver(RectTransform ui)
    {
        int num;
        int.TryParse(ui.name, out num);
        LeanTween.moveLocalZ(ui.gameObject, locations[num], 10f * Time.deltaTime).setEaseInOutBack();
        activeRectTransform = ui;
    }

    public void HoverExit(RectTransform ui)
    {
        int num;
        int.TryParse(ui.name, out num);
        LeanTween.moveLocalZ(ui.gameObject, locations[num + 1], 10f * Time.deltaTime).setEaseInOutBack();
        activeRectTransform = null;
    }

    private void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed);
        if (!pressed) return;
        if (activeRectTransform)
        {
            if (activeRectTransform.name == "0")
                ChangeScene("Play");
            else if (activeRectTransform.name == "2")
                Application.Quit();
            else if (activeRectTransform.name == "4")
                ChangeScene("Tutorial");
        }
    }

    private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
