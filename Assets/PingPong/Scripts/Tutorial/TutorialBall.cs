using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class TutorialBall : MonoBehaviour
{
    public int tutorialLevel;
    
    [SerializeField] private GameObject goodJob;
    [SerializeField] private InputDeviceCharacteristics controllerCharacteristics;
    [SerializeField] private Text tutorialText;
    [SerializeField] private string[] text;
    [SerializeField] private Collider[] colliders;
    [SerializeField] private GameObject[] paddlePreviews;
    
    private InputDevice targetDevice;
    private bool outOfBounds;
    private bool hitObjective;

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
        if (!pressed || !outOfBounds) return;
        ProgressTutorial();
    }

    private void ProgressTutorial()
    {
        if (hitObjective)
        {
            if (tutorialLevel < 2)
            {
                tutorialLevel++;

                goodJob.SetActive(false);
                tutorialText.text = text[tutorialLevel];
                paddlePreviews[tutorialLevel].SetActive(true);
                colliders[tutorialLevel].gameObject.SetActive(true);
            }
            else
            {
                goodJob.transform.GetChild(0).GetComponent<Text>().text = "Press Right Thumbstick To Exit";
                PlayerPrefs.SetInt("Tutorial Done", 1);
            }

            hitObjective = false;
        }
        outOfBounds = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == colliders[tutorialLevel])
        {
            goodJob.SetActive(true);
            paddlePreviews[tutorialLevel].SetActive(false);
            other.gameObject.SetActive(false);
            hitObjective = true;
            
            if (tutorialLevel >= 2)
                tutorialText.gameObject.SetActive(false);
        }

        if (other.CompareTag("Bounds"))
            outOfBounds = true;
    }
}
