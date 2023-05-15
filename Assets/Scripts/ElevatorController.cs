using System.Collections;
using UnityEngine;
using AK.Wwise;

public class ElevatorController : MonoBehaviour
{
    public bool doorClosed = true;

    public Animation door_animation;
    public GameObject elevatorDoor;

    // private AudioSource doorSource;

    private void Start()
    {
        // doorSource = GetComponent<AudioSource>();
    }


    public void DoorOperator()
    {
        if (doorClosed)
        {
            if (!door_animation.isPlaying)
            {
                door_animation.Play("OpenElevator");
                AkSoundEngine.PostEvent("ElevatorDoorSlide", elevatorDoor);
                // doorSource.Play();
                doorClosed = false;
            }

        }
        else
        {
            if (!door_animation.isPlaying)
            {
                door_animation.Play("CloseElevator");
                AkSoundEngine.PostEvent("ElevatorDoorSlide", elevatorDoor);
                // doorSource.Play();
                doorClosed = true;
            }

        }
    }

    public bool getDoorPosition()
    {
        return doorClosed;
    }
}