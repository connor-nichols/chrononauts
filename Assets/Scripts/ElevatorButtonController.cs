using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ElevatorButtonController : MonoBehaviour
{
    public ElevatorController elevatorController;
    public GameObject elevatorButton;
    public void OnButtonDown(Hand fromHand)
    {
        ColorSelf(Color.cyan);
        if (elevatorController.getDoorPosition())
            ColorSelf(Color.cyan);
        else
            ColorSelf(Color.red);
        fromHand.TriggerHapticPulse(1000);
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
