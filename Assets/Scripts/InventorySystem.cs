using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class InventorySystem : MonoBehaviour
    {
        public GameObject inventory;

        private Vector3 originalSize;

        private bool inBall = false;

        public float delay = 1f;
        private float timer = 0;
        private bool trigger = false;

        private void OnTriggerEnter(Collider other)
        {
            
            if (!inBall && other.tag == "Storeable")
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

                inBall = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (inBall && other.tag == "Storeable")
            {
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

                rb.useGravity = true;

                other.transform.SetParent(null);

                other.transform.localScale = originalSize;

                inBall = false;
            }

            inventory.GetComponent<SphereCollider>().isTrigger = false;
            trigger = true;
            // StartCoroutine(delay());
            
        }

        private void triggerOn()
        {
            inventory.GetComponent<SphereCollider>().isTrigger = true;
            trigger = false;
            timer = 0;
        }
        //IEnumerator delay()
        //{
          //  print(Time.time);
            //yield return new WaitForSeconds(100f);
            //print(Time.time);
        //}

        void Update()
        {
            // rotate object/container
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

            if (trigger)
            {
                timer += Time.deltaTime;
                if (timer > delay)
                {
                    print(Time.time);
                    triggerOn();
                }
            }
        }


        // Problems that need fixing
        // 1. If you hit the inventory container when it has an object the object will fly out.
        // Idea to fix: Give hands a tag and if something other than hands it touching negate the effects
        // 2. Resizing does not work well with nonuniform objects.
        // 3. Delay is 3 seconds when set to one.


    }
}
