using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaistTracking : MonoBehaviour
{
    public Transform head;
    public float waistHeight = 0.3f;

    void FixedUpdate()
    {
        transform.localPosition = new Vector3(head.position.x, waistHeight, head.position.z);
        // 'Camera.main' is a convenience property in Unity that automatically finds the first camera tagged as "MainCamera" in the scene.
        Quaternion cameraRotation = Camera.main.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, cameraRotation.eulerAngles.y, 0);
        transform.rotation = targetRotation;
    }
}

