using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class InventorySystem : MonoBehaviour
    {
        public GameObject inventory;

        void Update()
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

            rb.useGravity = false;

            // object becomes child of storage container
            other.transform.parent = inventory.transform;

            // figure out how to shrink object upon enter

            // set velocity to zero to stop it from floating out
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            // rb.Sleep();

            // sets object position to the orgin of parent
            other.transform.localPosition = Vector3.zero;
        }
    }
}
