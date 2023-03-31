using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RiftSpawner : MonoBehaviour
{
    public GameObject riftPrefab;

    public bool riftsSpawned = false;

    private void riftSpawn()
    {
        // Need to put rifts in each scene then enable when you enter the scene - might break
        PrefabUtility.InstantiatePrefab(riftPrefab);
        riftsSpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("File") && !riftsSpawned)
            {
               riftSpawn();
            }
    }
}
