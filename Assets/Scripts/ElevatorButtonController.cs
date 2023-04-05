using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ElevatorButtonController : MonoBehaviour
{
    public ElevatorController elevatorController;

    public void OnButtonDown(Hand fromHand)
    {
        print("Elevator Button Pressed");

        ColorSelf(Color.cyan);
        if (elevatorController.getDoorPosition())
            ColorSelf(Color.cyan);
        else
            ColorSelf(Color.red);
        fromHand.TriggerHapticPulse(1000);
    }

    public void OnButtonUp(Hand fromHand)
    {
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
