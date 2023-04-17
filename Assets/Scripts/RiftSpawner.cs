using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class RiftSpawner : MonoBehaviour
{
    private bool canSpawnRift = false;
    private bool riftSpawned = false;
    private bool riftCompleted = false;

    private string riftScene;

    public GameObject rift;

    public Dictionary<string, bool> riftData = new Dictionary<string, bool>
    {
        {"LevelScene-2020s", false },
        {"LevelScene-1990s", false },
        {"LevelScene-1970s", false },
        {"LevelScene-1940s", false },
        {"LevelScene-30xx", false },
    };

    private void riftSpawn()
    {
        if (!GameObject.Find("Portal(Clone)"))
        {
            Instantiate(rift, new Vector3(0f, 1.65f, 0f), Quaternion.identity);
        }

        // make portal not child of rift spawner
        rift.transform.parent = null;
    }

    void Update()
    {
        riftCompleted = riftData[SceneManager.GetActiveScene().name];
        // check if file has been brought back to level, if so activate rift spawning
        if (SceneManager.GetActiveScene().name == "LevelScene-2020s" && GameObject.Find("File") && !canSpawnRift)
        {
            canSpawnRift = true;
        }
        
        // check if level has portal, if so activate it
        if (canSpawnRift && !riftSpawned && !riftCompleted)
        {
            riftSpawn();
            riftSpawned = true;
            // spawned a portal in active scene (prevents duplicating)
            riftScene = SceneManager.GetActiveScene().name;  
        }

        if (riftScene != SceneManager.GetActiveScene().name)
        {
            riftSpawned = false;
        }

    }
}
