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
            if (!door_animation.isPlaying)
            {
                door_animation.Play("OpenElevator");
                doorSource.Play();
                doorClosed = false;
            }

        }
        else
        {
            if (!door_animation.isPlaying)
            {
                door_animation.Play("CloseElevator");
                doorSource.Play();
                doorClosed = true;
            }

        }
    }

    public bool getDoorPosition()
    {
        return doorClosed;
    }
}