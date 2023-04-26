using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using Valve.VR;

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

    public Dictionary<string, bool> riftData = new Dictionary<string, bool>
    {
        {"Start", false },  
        {"LevelScene-2020s", false },
        {"LevelScene-1990s", false },
        {"LevelScene-1970s", false },
        {"LevelScene-1940s", false },
        {"LevelScene-30xx", false },
    };

    public SteamVR_Action_Boolean toggleInventoryOn = SteamVR_Input.GetBooleanAction("ToggleInventoryOn");
    public SteamVR_Action_Boolean toggleInventoryOff = SteamVR_Input.GetBooleanAction("ToggleInventoryOff");

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

                case "LevelScene-30XXs":
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

                case "LevelScene-30XXs":
                    PortalXXs.SetActive(true);
                    break;
            }
        }

        
    }

    void Update()
    {
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


        //checking if the player swipes up on the touchpad to toggle the inventory on
        if (toggleInventoryOn != null && toggleInventoryOn.activeBinding)
        {
            GameObject.Find("WaitInventory").SetActive(true);
        }

        //checking if the player swipes down on the touchpad to toggle the inventory off
        if (toggleInventoryOff != null && toggleInventoryOff.activeBinding)
        {
            GameObject.Find("WaitInventory").SetActive(false);
        }
    }
}
