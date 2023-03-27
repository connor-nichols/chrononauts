using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class InventorySystem : MonoBehaviour
    {
        public GameObject inventory;

        private Vector3 originalSize;

        private void OnTriggerEnter(Collider other)
        {
            AddInteractable(other.gameObject);
        }

        private void AddInteractable(GameObject newObject)
        {
            if (newObject.tag == "Storeable" && inventory.transform.childCount == 0)
            {
                Rigidbody rb = newObject.GetComponent<Rigidbody>();

                // Store object size
                originalSize = newObject.transform.localScale;

                rb.useGravity = false;

                // object becomes child of inventory container
                newObject.transform.SetParent(inventory.transform);

                // Shrink object 
                newObject.transform.localScale = new Vector3(0.48f, 0.48f, 0.48f);

                // set velocity to zero to stop it from floating out
                rb.angularVelocity = Vector3.zero;
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;

                // sets object position to the orgin of parent
                newObject.transform.localPosition = Vector3.zero;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            RemoveInteractable(other.gameObject);
        }

        private void RemoveInteractable(GameObject newObject)
        {
            if (newObject.tag == "Storeable")
            {
                Rigidbody rb = newObject.GetComponent<Rigidbody>();

                rb.useGravity = true;

                newObject.transform.SetParent(null);

                newObject.transform.localScale = originalSize;
                
                StartCoroutine(TriggerExitWithDelay(rb));
            }
        }

        IEnumerator TriggerExitWithDelay(Rigidbody rb)
        {
            yield return new WaitForSeconds(1f);
            rb.isKinematic = false;
        }

        void Update()
        {
            // rotate object/container
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }


        // Problems that need fixing
        // 1. If you hit the inventory container when it has an object the object will fly out.
        // Idea to fix: Give hands a tag and if something other than hands it touching negate the effects
        // 2. Resizing does not work well with nonuniform objects.
        // 3. Delay is 3 seconds when set to one.


    }
}
