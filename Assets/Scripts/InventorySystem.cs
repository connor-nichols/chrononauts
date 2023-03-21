using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class InventorySystem : MonoBehaviour
    {
        private Interactable interactable;

        public GameObject leftStorage;

        // private void Update()
        // {
        //     if (interactable.attachedToHand)
        //     {
        //         GameObject item = interactable.gameObject;
        //     }
        // }

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;

            // object becomes child of storage container
            other.transform.parent = leftStorage.transform;

            // figure out how to shrink object upon enter

            // sets object position to the orgin of parent
            other.transform.localPosition = Vector3.zero;

            // maybe set velocity to zero to stop it from floating out
            

        }
    }
}
