using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class ExitGame : MonoBehaviour
{
    [SerializeField] private InputDeviceCharacteristics controllerCharacteristics;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Animator image;
    
    
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
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed);
        if (!pressed) return;
        if (pauseMenu.activeInHierarchy)
        {
            Time.timeScale = 1f;
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        StartCoroutine(Delay());
        image.Play("Fade In Image", -1, 0f);
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Start Menu");
    }
}
