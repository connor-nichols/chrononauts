using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class RiftSpawner : MonoBehaviour
{
    private bool canSpawnRift = false;

    private bool riftCompleted;
    private string sceneName;
    private string previousScene;

    public GameObject PortalXXs;
    public GameObject Portal20s;
    public GameObject Portal90s;
    public GameObject Portal70s;
    public GameObject Portal40s;

    public GameObject TutorialRift;

    public Dictionary<string, bool> riftData = new Dictionary<string, bool>
    {
        {"Start", false },  
        {"LevelScene-2020s", false },
        {"LevelScene-1990s", false },
        {"LevelScene-1970s", false },
        {"LevelScene-1940s", false },
        {"LevelScene-30xx", false },
    };

    private void riftSpawn()
    {
        if (previousScene != SceneManager.GetActiveScene().name && previousScene != null)
        {
            switch (previousScene)
            {
                case "LevelScene-2020s":
                    Portal20s.SetActive(false);
                    break;

                case "LevelScene-1990s":
                    Portal90s.SetActive(false);
                    break;

                case "LevelScene-1970s":
                    Portal70s.SetActive(false);
                    break;

                case "LevelScene-1940s":
                    Portal40s.SetActive(false);
                    break;

                case "LevelScene-30xx":
                    PortalXXs.SetActive(false);
                    break;
            }
        }
        
        // figure out how to setactive to false when changing scenes
        sceneName = SceneManager.GetActiveScene().name;

        riftCompleted = riftData[sceneName];

        if (!riftCompleted)
        {
            switch (sceneName)
            {
                case "LevelScene-2020s":
                    Portal20s.SetActive(true);
                    break;

                case "LevelScene-1990s":
                    Portal90s.SetActive(true);
                    break;

                case "LevelScene-1970s":
                    Portal70s.SetActive(true);
                    break;

                case "LevelScene-1940s":
                    Portal40s.SetActive(true);
                    break;

                case "LevelScene-30xx":
                    PortalXXs.SetActive(true);
                    break;
            }
        }

        
    }

    void Update()
    {
        if ( (SceneManager.GetActiveScene().name == "LevelScene-2020s" || SceneManager.GetActiveScene().name == "Start") && TutorialRift.transform.GetChild(0).childCount != 0)
        {
            TutorialRift.SetActive(true);
        }
        else
        {
            TutorialRift.SetActive(false);
        }

        // check if file has been brought back to level and put in tutorialRift, if so activate rift spawning
        if (SceneManager.GetActiveScene().name == "LevelScene-2020s" && !GameObject.Find("TutorialRift") && !canSpawnRift)
        {
            canSpawnRift = true;
        }
        
        if (canSpawnRift)
        {
            riftSpawn();
            previousScene = sceneName;
        }
    }
}
