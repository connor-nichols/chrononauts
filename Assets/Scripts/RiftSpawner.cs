using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class RiftSpawner : MonoBehaviour
{
    private bool canSpawnRift = false;
    private bool portalSpawned = false;
    private bool portalCompleted = false;

    private string portalScene;

    public GameObject rift;
    public SceneDataController sceneData;

    private void riftSpawn()
    {
        if (!GameObject.Find("Portal(Clone)") && !portalSpawned)
        {
            Instantiate(rift, new Vector3(0f, 1.65f, 0f), Quaternion.identity);
        }

        // make portal not child of rift spawner
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
        if (transform.childCount == 0 && canSpawnRift && !portalSpawned && !portalCompleted)
        {
            riftSpawn();
            portalSpawned = true;
            portalScene = SceneManager.GetActiveScene().name;  
        }

        if (!GameObject.Find("Portal(Clone)") && !portalCompleted && portalSpawned)
        {
            portalCompleted = true;
        }

        if (portalScene != SceneManager.GetActiveScene().name)
        {
            portalSpawned = false;
            sceneData.save();
        }

    }
}
