using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ElevatorButtonController : MonoBehaviour
{
    public ElevatorController elevatorController;

    public void OnButtonDown(Hand fromHand)
    {
        print("button down");
        ColorSelf(Color.cyan);
        fromHand.TriggerHapticPulse(1000);
    }

    public void OnButtonUp(Hand fromHand)
    {
        print("button up");
        CloseDoor();
    }

    private void CloseDoor()
    {
        elevatorController.DoorOperator();
    }

    private void ColorSelf(Color newColor)
    {
        Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
        for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
        {
            renderers[rendererIndex].material.color = newColor;
        }
    }
}
