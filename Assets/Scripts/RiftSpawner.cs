using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class RiftSpawner : MonoBehaviour
{
    private bool canSpawnRift = false;
    private bool riftActivated = false;

    public GameObject rift;

    private void riftSpawn()
    {
        rift.SetActive(true);
        rift.transform.parent = null;
    }

    void Update()
    {
        // check if file has been brought back to level, if so activate rift spawning
        if (SceneManager.GetActiveScene().name == "LevelScene-2020s" && GameObject.Find("File") && !canSpawnRift)
        {
            canSpawnRift = true;
        }

        // check if level has portal, if so activate it
        if (transform.childCount == 1 && canSpawnRift)
        {
            riftSpawn();
            // make portal not child of rift spawner
        }
    }
}
