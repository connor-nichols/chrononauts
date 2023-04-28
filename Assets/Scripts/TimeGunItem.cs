using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGunItem : MonoBehaviour
{
    // Start is called before the first frame update
    public int itemIndex;
    public int getIndex()
    {
        return itemIndex;
    }

    private void Update()
    {
        
    }
    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
