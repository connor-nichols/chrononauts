using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniRiftRotator : MonoBehaviour
{
    void Update()
    {
        // rotate object/container
        transform.Rotate(new Vector3(15, 45, 30) * Time.deltaTime);
    }
}
