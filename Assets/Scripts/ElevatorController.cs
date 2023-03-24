using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    private bool doorClosed = false;

    public void DoorOperator()
    {
        print("operation accessed");
        if(doorClosed)
            doorClosed = false;
        else
            doorClosed = true;
    }
}
