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
            {"typewriter_70s", new Vector3(2.5f, 2.5f, 2.5f)},
            {"PocketWatch40s", new Vector3(45f, 45f, 45f)},
            {"newtons_cradle", new Vector3(8f, 8f, 8f)},
            {"deskLamp2020s", new Vector3(0.8f, 0.8f, 0.8f)},
            {"whoopeeCushion", new Vector3(0.2f, 0.2f, 0.2f)},
            {"benBassPlaque_v01", new Vector3(18f, 18f, 18f)},
            {"officeButton90s", new Vector3(25f, 25f, 25f)},
            {"TrashB", new Vector3(0.15f, 0.15f, 0.15f)},
            {"computer90s", new Vector3(0.015f, 0.015f, 0.015f)},
            {"trashBin70s_v03", new Vector3(25f, 25f, 25f)},
            {"handWatch2020s", new Vector3(0.65f, 0.65f, 0.65f)},
            {"mugPiece3", new Vector3(20f, 20f, 20f)}
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
                if (resizeValues.ContainsKey(newObject.transform.name))
                {
                    Vector3 scale = resizeValues[newObject.transform.name];
                    newObject.transform.localScale = scale;
                }
                else
                {
                    newObject.transform.localScale = new Vector3(0.48f, 0.48f, 0.48f);
                }

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
