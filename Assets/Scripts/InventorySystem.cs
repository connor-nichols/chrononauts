using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class InventorySystem : MonoBehaviour
    {
        public GameObject inventory;

        public float targetSize = 0.48f;

        private Vector3 originalSize;

        private void OnTriggerEnter(Collider other)
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

            // Store object size
            originalSize = other.transform.localScale;

            rb.useGravity = false;

            // object becomes child of inventory container
            other.transform.SetParent(inventory.transform);

            // Shrink object 
            other.transform.localScale = new Vector3(0.48f, 0.48f, 0.48f);

            // set velocity to zero to stop it from floating out
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;

            // sets object position to the orgin of parent
            other.transform.localPosition = Vector3.zero;
        }

        private void OnTriggerExit(Collider other)
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            
            rb.useGravity = true;

            other.transform.SetParent(null);

            other.transform.localScale = originalSize;
        }

        void Update()
        {
            // rotate object/container
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }

        // Problems that need fixing
        // 1. If you hit the inventory container when it has an object the object will fly out.
        // Idea to fix: Give hands a tag and if something other than hands it touching negate the effects
        // 2. Don't have any tag checking yet.
        // 3. Resizing does not work well with nonuniform objects.


    }
}
