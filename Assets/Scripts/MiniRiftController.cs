using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniRiftController : MonoBehaviour
{
    private bool correctItem = false;
    public string correctItemName;

    void Update()
    {
        
        transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);

        if (transform.childCount == 2)
        {
            if (transform.GetChild(1).name == correctItemName)
            {
                correctItem = true;
            }
             
            transform.GetChild(0).gameObject.SetActive(false);
        }

        if (correctItem)
        {
            StartCoroutine(Delay());        
        }
    }

    IEnumerator Delay()
    {
        // Need to add audio/haptics when TutorialRift is being "destroyed"
        // Need to make it so TutorialRift doesn't get spawned once destoryed
        transform.Rotate(new Vector3(270, 270, 270) * Time.deltaTime);
        yield return new WaitForSeconds(2.5f);
        // Destroy(transform.gameObject);
        transform.gameObject.SetActive(false);
    }
}
