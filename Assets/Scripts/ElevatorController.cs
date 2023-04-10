using System.Collections;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public bool doorClosed = true;

    public Animation door_animation;

    private AudioSource doorSource;

    private void Start()
    {
        doorSource = GetComponent<AudioSource>();
    }


    public void DoorOperator()
    {
        if (doorClosed)
        {
            door_animation.Play("OpenElevator");
            doorClosed = false;
            doorSource.Play();

        }
        else
        {
            door_animation.Play("CloseElevator");
            doorClosed = true;
            doorSource.Play();

        }
    }

    public bool getDoorPosition()
    {
        return doorClosed;
    }
}