using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SafeController : MonoBehaviour
{
    private Interactable interactable;
    private GameObject lockPlane;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        lockPlane = GetComponent<GameObject>();
    }

    private void OnAttachedToHand(Hand hand)
    {
        print("attached");
    }
}
