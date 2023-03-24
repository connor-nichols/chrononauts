using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ElevatorButtonController : MonoBehaviour
{

    public void OnButtonDown(Hand fromHand)
    {
        ColorSelf(Color.cyan);
        fromHand.TriggerHapticPulse(1000);
    }

    public void OnButtonUp(Hand fromHand)
    {
        CloseDoor();
    }

    private void CloseDoor()
    {

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
