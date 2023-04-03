using System.Collections;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    private bool doorClosed = false;

    public GameObject door;

    public float rotation_speed = 10f;

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
        StartCoroutine(Rotatedoor());
    }

    IEnumerator Rotatedoor()
    {
        float time = 0f;
        float startRotation = door.transform.eulerAngles.y;
        float endRotation;
        if (doorClosed)
            endRotation = 0f;
        else
            endRotation = -90f;

        while (time < 1f)
        {
            time += Time.deltaTime * rotation_speed;
            float rotation = Mathf.Lerp(startRotation, endRotation, time);
            door.transform.eulerAngles = new Vector3(0f, rotation, 0f);
        }

        yield return null;

    }
}