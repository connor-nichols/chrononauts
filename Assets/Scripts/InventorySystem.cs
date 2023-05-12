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
            {"mugPiece3", new Vector3(20f, 20f, 20f)},
            {"coffeeMug90s", new Vector3(12f, 12f, 12f)},
            {"digitalWatch90s", new Vector3(575f, 575f, 575f)},
            {"deskLamp90s", new Vector3(0.15f, 0.15f, 0.15f)},
            {"trashBin90s", new Vector3(0.2f, 0.2f, 0.2f)},
            {"coffeeMug70s", new Vector3(12f, 12f, 12f)},
            {"tapeRecorder70s_PREFAB", new Vector3(1f, 1f, 1f)},
            {"deskPhone70s", new Vector3(3f, 3f, 3f)},
            {"industrialLamp70s", new Vector3(0.9f, 0.9f, 0.9f)},
            {"scienceBook", new Vector3(0.015f, 0.015f, 0.015f)},
            {"vintageWatch70s", new Vector3(12f, 12f, 12f)},
            {"deskLamp40s_PREFAB", new Vector3(300f, 300f, 300f)},
            {"coffeeMug40s", new Vector3(12f, 12f, 12f)},
            {"typewriter40s", new Vector3(0.3f, 0.3f, 0.3f)},
            {"phone40s", new Vector3(2f, 2f, 2f)},
            {"radio40s", new Vector3(1.3f, 1.3f, 1.3f)},
            {"trashBin40s", new Vector3(0.5f, 0.5f, 0.5f)}
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
