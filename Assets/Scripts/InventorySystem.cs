using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class InventorySystem : MonoBehaviour
    {
        private Vector3 originalSize;

        public GameObject inventory;

        Dictionary<string, Vector3> resizeValues = new Dictionary<string, Vector3>
        {
            {"item1 placeholder", new Vector3(0f, 0f, 0f) },
        };

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
                // newObject.transform.localScale = new Vector3(0.48f, 0.48f, 0.48f);

                // set velocity to zero to stop it from floating out
                rb.angularVelocity = Vector3.zero;
                rb.velocity = Vector3.zero;

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
            }
        }

        void Update()
        {
            // rotate object/container
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }
    }
}
