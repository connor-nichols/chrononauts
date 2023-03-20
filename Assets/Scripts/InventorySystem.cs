using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class InventorySystem : MonoBehaviour
    {
        private Interactable interactable;

        private void Update()
        {
            if (interactable.attachedToHand)
            {
                GameObject item = interactable.gameObject;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.transform.position = new Vector3(0, 0, 0);
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            // when object collides with trigger, it will become a child of the trigger
        }
    }
}
