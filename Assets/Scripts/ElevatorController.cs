using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    private bool doorClosed = false;
    private Quaternion startRotation;
    private Quaternion endRotation;
    private float timeElapsed = 0.0f;

    public GameObject door;

    public float duration = 1.0f;

    public void DoorOperator()
    {
        print("operation accessed");
        if (doorClosed)
        {
            rotateDoor();
            doorClosed = false;

        }
        else
        {
            rotateDoor();
            doorClosed = true;

        }
    }

    public bool getDoorPosition()
    {
        return doorClosed;
    }

    private void rotateDoor()
    {
        timeElapsed += Time.deltaTime;

        // Calculate the interpolation factor
        float t = Mathf.Clamp01(timeElapsed / duration);

        if (doorClosed)
        {
            // Interpolate between the start and end rotation
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, -90, 0), Quaternion.Euler(0, 0, 0), t);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, -90, 0), t);
        }
    }
}