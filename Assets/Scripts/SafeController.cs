using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(CircularDrive))]
public class SafeController : MonoBehaviour
{
    public Animation doorAnimation;
    private AudioSource audioSource;
    private CircularDrive circularDrive;
    private bool clicked;
    private bool clicked2;

    // Start is called before the first frame update
    void Start()
    {
        circularDrive = GetComponent<CircularDrive>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (circularDrive.outAngle > 100 && !clicked)
        {
            clicked = true;
            audioSource.Play();
        }

        if (circularDrive.outAngle < -100 && !clicked2 && clicked)
        {
            clicked2 = true;
            audioSource.Play();
            doorAnimation.Play();
        }
    }
}
