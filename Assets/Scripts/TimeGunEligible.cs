using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGunEligible : MonoBehaviour
{
    public int activeItem = 0;
    public int maxItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>(true);
        foreach (Transform child in allChildren)
        {
            try
            {
                TimeGunItem childItem = child.gameObject.GetComponent<TimeGunItem>();
                int childIndex = childItem.getIndex();
                if (childIndex != activeItem && child.gameObject.tag != "TimeGunParent")
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    child.gameObject.SetActive(true);
                }
            }
            catch (System.NullReferenceException)
            {
                continue;
            }
            
        }
    }

    public void TimeGunForward()
    {
        if (activeItem + 1 < maxItem)
        {
            activeItem++;
        }
        else
        {
            activeItem = 0;
        }
    }
    public void TimeGunBack()
    {
        if (activeItem - 1 < 0)
        {
            activeItem = maxItem;
        }
        else
        {
            activeItem--;
        }
    }
}
