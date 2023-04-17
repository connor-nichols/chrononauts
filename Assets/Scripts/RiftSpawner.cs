using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class RiftSpawner : MonoBehaviour
{
    public bool riftCompleted = false;

    private bool riftSpawned = false;

    private string riftScene;

    public GameObject rift;

    /* 
     * Holds the data where the scene can spawn in a rift or not
     * When the player completes the rift, the value should turn into false
     * The 2020s is initially false until the tutorial section is complete
     */

    public Dictionary<string, bool> riftData = new Dictionary<string, bool>
    {
        {"LevelScene-2020s", false },
        {"LevelScene-1990s", true },
        {"LevelScene-1970s", true },
        {"LevelScene-1940s", true },
        {"LevelScene-30xx", true },
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
        string sceneName = SceneManager.GetActiveScene().name;

        // check if file has been brought back to level, if so activate rift spawning
        if (sceneName == "LevelScene-2020s" && GameObject.Find("File") && !riftData[sceneName])
        {
            riftData[sceneName] = true;
        }
        
        // check if level has portal, if so activate it
        if (riftData[sceneName] && !riftSpawned && riftData["LevelScene-2020s"])
        {
            riftSpawn();
            riftSpawned = true;
            // spawned a portal in active scene (prevents duplicating)
            riftScene = sceneName;  
        }

        // This if statement prevents portal duplication
        if (riftScene != sceneName)
        {
            riftSpawned = false;
        }

        riftCompleted = riftData[sceneName];

        print($"RiftSpawner: {riftData[sceneName]}");
    }
}
