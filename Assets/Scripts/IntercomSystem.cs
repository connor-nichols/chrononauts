using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class IntercomSystem : MonoBehaviour
{
    public GameObject intercom;

    private bool introPlayed = false;

    void Start()
    {
        if (!introPlayed) 
        {
            StartCoroutine(Introduction()); 
        }
    }

    void Update()
    {
        
    }

    IEnumerator Introduction()
    {
        yield return new WaitForSeconds(8f);
        AkSoundEngine.PostEvent("IntroVoiceover", intercom);
        introPlayed = true;
    }
}
