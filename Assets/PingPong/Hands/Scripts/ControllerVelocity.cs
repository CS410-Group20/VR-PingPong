using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerVelocity : MonoBehaviour
{
    public InputActionProperty velocityProperty;
    
    private Vector3 velocity { get; set; } = Vector3.zero;

    private void Update()
    {
        velocity = velocityProperty.action.ReadValue<Vector3>();
    }
}
