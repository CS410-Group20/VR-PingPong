using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class SetDifficulty : MonoBehaviour
{
    [SerializeField] private ToggleGroup group;
    [SerializeField] private InputDeviceCharacteristics controllerCharacteristics;
    [SerializeField] private BallController ballController;
    
    private InputDevice targetDevice;

    public void ChangeValue()
    {
        PlayerPrefs.SetString("Difficulty", group.ActiveToggles().FirstOrDefault()?.gameObject.name);
        print(group.ActiveToggles().FirstOrDefault()?.gameObject.name);
    }

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
