using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiftController : MonoBehaviour
{
    public GameObject riftOne;
    public GameObject riftTwo;
    public GameObject riftThree;

    private Vector3 originalSize;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Storeable")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

            rb.useGravity = false;

            other.transform.SetParent(riftOne.transform);

            other.transform.localScale = new Vector3(0.48f, 0.48f, 0.48f);

            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;

            other.transform.localPosition = Vector3.zero;
        }
    }

    void Update()
    {
        transform.Rotate(new Vector3(15, 15, 15) * Time.deltaTime);
    }
}

// make a dictonary of rifts then from there make a loop/if statement check if the selected rift has a child, if it does move on to the next if not insert the gameobject
