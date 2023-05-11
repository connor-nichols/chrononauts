using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class RiftController : MonoBehaviour
    {
        public GameObject riftOne;
        public GameObject riftTwo;
        public GameObject riftThree;

        public string correctItemNameOne;
        public string correctItemNameTwo;
        public string correctItemNameThree;

        public RiftSpawner riftSpawner;

        private Vector3 originalSize;
        private Vector3 markerSize;
        private bool resize;

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

                if (riftOne != null && newObject.transform.name == correctItemNameOne)
                {
                    if (riftOne.transform.childCount == 1)
                    {
                        markerSize = riftOne.transform.GetChild(0).transform.localScale;
                        print(riftOne.transform.GetChild(0));
                        newObject.transform.SetParent(riftOne.transform);
                        resize = true;
                    }
                }
                else if (riftTwo != null && newObject.transform.name == correctItemNameTwo)
                {
                    if (riftTwo.transform.childCount == 1)
                    {
                        markerSize = riftTwo.transform.GetChild(0).transform.localScale;
                        print(riftOne.transform.GetChild(0));
                        newObject.transform.SetParent(riftTwo.transform);
                        resize = true;
                    }
                }
                else if (riftThree != null && newObject.transform.name == correctItemNameThree)
                {
                    if (riftThree.transform.childCount == 1)
                    {
                        markerSize = riftThree.transform.GetChild(0).transform.localScale;
                        print(riftOne.transform.GetChild(0));
                        newObject.transform.SetParent(riftThree.transform);
                        resize = true;
                    }
                }
                else {
                    // object comes out below the rift if its full
                    newObject.transform.localPosition = new Vector3(newObject.transform.position.x, 1f, newObject.transform.position.z);
                    return;
                }

                rb.useGravity = false;

                if (resize)
                {
                    print(markerSize);
                    /*Vector3 parentScale = newObject.transform.parent.transform.localScale;
                   
                    float biggestValue = Mathf.Max(originalSize.x, originalSize.y, originalSize.z);
                    //print(originalSize.x);
                    
                    float scale = (float)((0.8)/biggestValue);
                    print(scale);*/

                    newObject.transform.localScale = markerSize;
                    resize = false;
                }
               

                rb.angularVelocity = Vector3.zero;
                rb.velocity = Vector3.zero;

                newObject.transform.localPosition = Vector3.zero;
            }
        }

        void Update()
        {
            // transform.Rotate(new Vector3(0, 0, 15) * Time.deltaTime);
            if (transform.childCount == 0)
            {
                StartCoroutine(Delay());
            }
        }

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(2f);
            // Destroy(transform.parent.gameObject);
            
            if (transform.parent.gameObject.name == "TutorialRift")
            {
                transform.parent.gameObject.SetActive(false);
            }
            else
            {
                transform.parent.gameObject.SetActive(false);
                riftSpawner.riftData[SceneManager.GetActiveScene().name] = true;
                riftSpawner.portalsCompleted += 1;
            }
            
        }
    }
}