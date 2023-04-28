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
        // test making a waistInventory a child of VRCamera
        transform.rotation = Quaternion.Euler(0, head.rotation.y, 0 );
    }
}

