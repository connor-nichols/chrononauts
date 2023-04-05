using System.Collections;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public bool doorClosed = true;

    public Animation door_animation;


    public void DoorOperator()
    {
        if (doorClosed)
        {
            door_animation.Play("OpenElevator");
            doorClosed = false;

        }
        else
        {
            door_animation.Play("CloseElevator");
            doorClosed = true;

        }
    }

    public bool getDoorPosition()
    {
        return doorClosed;
    }
}