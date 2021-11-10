using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private InputDeviceCharacteristics controllerCharacteristics;
    [SerializeField] private GameObject pauseMenu;

    private bool acceptInput = true;
    private InputDevice targetDevice;
    
    private void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if (devices.Count > 0)
            targetDevice = devices[0];
    }
    
    private void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool pressed);
        if (!pressed) return;
        if (acceptInput)
        {
            if (!pauseMenu.activeInHierarchy)
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
            }

            acceptInput = false;
            StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(1f);
        acceptInput = true;
    }
}
