using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniRiftRotator : MonoBehaviour
{
    private bool correctItem = false;
    public string correctItemName;
    void Update()
    {
        // rotate object/container
        transform.Rotate(new Vector3(15, 45, 30) * Time.deltaTime);

        if (transform.childCount == 1)
        {
            if (transform.GetChild(0).name == correctItemName)
            {
                correctItem = true;
            }
        }

        if (correctItem)
        {
            StartCoroutine(Delay());
            
        }
    }

    IEnumerator Delay()
    {
        transform.Rotate(new Vector3(270, 270, 270) * Time.deltaTime);
        yield return new WaitForSeconds(2f);
        Destroy(transform.gameObject);
    }
}
