using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class RiftController : MonoBehaviour
    {
        public GameObject riftOne;
        public GameObject riftTwo;
        public GameObject riftThree;

        private Vector3 originalSize;

        private void OnTriggerEnter(Collider other)
        {
            AddInteractable(other.gameObject);
        }

        private void AddInteractable(GameObject newObject)
        {
            if (newObject.tag == "Storeable")
            {
                Rigidbody rb = newObject.GetComponent<Rigidbody>();

                originalSize = newObject.transform.localScale;

                if (riftOne.transform.childCount == 0)
                {
                    newObject.transform.SetParent(riftOne.transform);
                }
                else if (riftTwo.transform.childCount == 0)
                {
                    newObject.transform.SetParent(riftTwo.transform);
                }
                else if (riftThree.transform.childCount == 0)
                {
                    newObject.transform.SetParent(riftThree.transform);
                }
                else {
                    // object comes out below the rift if its full
                    newObject.transform.localPosition = new Vector3(newObject.transform.position.x, 1f, newObject.transform.position.z);
                    return;
                }

                rb.useGravity = false;

                newObject.transform.localScale = new Vector3(0.48f, 0.48f, 0.48f);

                rb.angularVelocity = Vector3.zero;
                rb.velocity = Vector3.zero;

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
            transform.Rotate(new Vector3(0, 0, 15) * Time.deltaTime);
        }
    }
}