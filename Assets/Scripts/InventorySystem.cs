using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using AK.Wwise;

namespace Valve.VR.InteractionSystem.Sample
{
    public class InventorySystem : MonoBehaviour
    {
        private Vector3 originalSize;

        public GameObject inventory;

        private void OnTriggerEnter(Collider other)
        {
            AkSoundEngine.PostEvent("InventoryInput", inventory);
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

                // sets object position to the orgin of parent
                newObject.transform.localPosition = Vector3.zero;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            AkSoundEngine.PostEvent("InventoryOutput", inventory);
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
