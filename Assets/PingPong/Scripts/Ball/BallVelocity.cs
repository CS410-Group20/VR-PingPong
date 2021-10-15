using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallVelocity : XRGrabInteractable
{
    private ControllerVelocity _controllerVelocity;
    private BallController _ballController;  

    protected override void Awake()
    {
        base.Awake();
        _ballController = GetComponent<BallController>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        _controllerVelocity = args.interactable.GetComponent<ControllerVelocity>();
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        _controllerVelocity = null;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if (isSelected)
        {
            if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
                UpdateSpeed();
        }
    }

    private void UpdateSpeed()
    {
        Vector3 velocity = _controllerVelocity ? _controllerVelocity.velocity : Vector3.zero;
        _ballController.speed = velocity.z;
    }
}
