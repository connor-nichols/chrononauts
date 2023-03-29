using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class InventorySystem : MonoBehaviour
    {
        public GameObject inventory;
        public GameObject riftPrefab;

        private Vector3 originalSize;

        public bool riftsSpawned = false;
        public bool fileInteracted = false;

        private void OnTriggerEnter(Collider other)
        {
            AddInteractable(other.gameObject);
        }

        private void AddInteractable(GameObject newObject)
        {
            if (newObject.tag == "Storeable" && inventory.transform.childCount == 0)
            {

                if (newObject.name == "File")
                {
                    fileInteracted = true;
                }

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

        private void riftSpawn()
        {
            Instantiate(riftPrefab, new Vector3(0, 1.65f, 0), Quaternion.identity);
            riftsSpawned = true;
        }

        void Update()
        {
            // rotate object/container
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

            if (SceneManager.GetActiveScene().name == "LevelFour" && fileInteracted && !riftsSpawned)
            {
               riftSpawn();
            }
        }

        // Problems that need fixing
        // 1. If you hit the inventory container when it has an object the object will fly out.
        // Idea to fix: Give hands a tag and if something other than hands it touching negate the effects
        // 2. Resizing does not work well with nonuniform objects.

        // TODO for starting condition:
        // want to check if we have grabbed the file by checking if its a child of player (inventory)
        // check scene manager for specific scene (SceneManage.ActiveScene)
    }
}
