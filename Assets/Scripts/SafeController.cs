using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


[RequireComponent(typeof(Interactable))]
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


    public void playMinClick()
    {
        print("min click");
    }

    public void playClickNoise()
    {
        print("click");
    }
}
