using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class SetDifficulty : MonoBehaviour
{
    [SerializeField] private ToggleGroup group;
    [SerializeField] private InputDeviceCharacteristics controllerCharacteristics;
    
    private InputDevice targetDevice;

    public void ChangeValue()
    {
        PlayerPrefs.SetString("Difficulty", group.ActiveToggles().FirstOrDefault()?.gameObject.name);
        print(group.ActiveToggles().FirstOrDefault()?.gameObject.name);
    }
}
