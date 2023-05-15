using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using AK.Wwise;


[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(CircularDrive))]
public class SafeController : MonoBehaviour
{
    public Animation doorAnimation;
    // private AudioSource audioSource;
    private CircularDrive circularDrive;
    private bool clicked;
    private bool clicked2;
    public GameObject safe;

    // Start is called before the first frame update
    void Start()
    {
        circularDrive = GetComponent<CircularDrive>();
        // audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (circularDrive.outAngle > 100 && !clicked)
        {
            clicked = true;
            AkSoundEngine.PostEvent("SafeBox_DialClick", safe);
            // audioSource.Play();
        }

        if (circularDrive.outAngle < -100 && !clicked2 && clicked)
        {
            clicked2 = true;
            AkSoundEngine.PostEvent("SafeBox_DialClick", safe);
            doorAnimation.Play();
            AkSoundEngine.PostEvent("Safebox_DoorOpen", safe);
        }
    }
}
