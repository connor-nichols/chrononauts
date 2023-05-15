using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using Valve.VR;
using AK.Wwise;

public class RiftSpawner : MonoBehaviour
{
    public bool canSpawnRift = false;

    private bool riftCompleted;
    private string sceneName;
    private string previousScene;
    private GameObject futureScene;

    public GameObject PortalXXs;
    public GameObject Portal20s;
    public GameObject Portal90s;
    public GameObject Portal70s;
    public GameObject Portal40s;

    public GameObject LeftInventory;
    public GameObject RightInventory;

    public GameObject TutorialRift;
    public GameObject riftSpawner;

    public Dictionary<string, bool> riftData = new Dictionary<string, bool>
    {
        {"Start", false },  
        {"LevelScene-2020s", false },
        {"LevelScene-1990s", false },
        {"LevelScene-1970s", false },
        {"LevelScene-1940s", false },
        {"LevelScene-30xx", false },
    };

    public SteamVR_Action_Boolean ToggleInventory = SteamVR_Input.GetBooleanAction("ToggleInventory");

    public int portalsCompleted = 0;

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
                    //PortalXXs.SetActive(false);
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
                    //PortalXXs.SetActive(true);
                    break;
            }
        }

        
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "LevelScene-30xx" && portalsCompleted == 4)
        {
            futureScene = GameObject.Find("RoomEnvironment");
            futureScene.transform.GetChild(0).gameObject.SetActive(true);
            print("You win!");
        }
        else if (SceneManager.GetActiveScene().name == "LevelScene-30xx")
        {
            futureScene = GameObject.Find("RoomEnvironment");
            futureScene.transform.GetChild(1).gameObject.SetActive(true);
            print("WHATRE YOU DOING GO CLEANUP THE PORTALS!");
        }

        // Room Ambience
        switch (sceneName)
        {
            case "LevelScene-2020s":
                AkSoundEngine.PostEvent("Roomtone2020s", riftSpawner);
                break;

            case "LevelScene-1990s":
                AkSoundEngine.PostEvent("Roomtone1990s", riftSpawner);
                break;

            case "LevelScene-1970s":
                AkSoundEngine.PostEvent("Roomtone1970s", riftSpawner);
                break;

            case "LevelScene-1940s":
                AkSoundEngine.PostEvent("Roomtone1940s", riftSpawner);
                break;

            case "LevelScene-30xx":
                AkSoundEngine.PostEvent("Roomtone30XX", riftSpawner);
                break;
        }
    }

    void Update()
    {
        if ( (SceneManager.GetActiveScene().name == "LevelScene-2020s" || SceneManager.GetActiveScene().name == "Start") && TutorialRift.transform.GetChild(0).GetChild(0).gameObject.activeSelf)
        {
            TutorialRift.SetActive(true);
        }
        else
        {
            TutorialRift.SetActive(false);
        }

        // check if file has been brought back to level and put in tutorialRift, if so activate rift spawning
        if (SceneManager.GetActiveScene().name == "LevelScene-2020s" && !TutorialRift.activeSelf && !canSpawnRift)
        {
            canSpawnRift = true;
        }
        
        if (canSpawnRift)
        {
            riftSpawn();
            previousScene = sceneName;
        }


        if (ToggleInventory != null && ToggleInventory.activeBinding)
        {
            //checking if the player swipes down on the touchpad to toggle the inventory set
            if (ToggleInventory.GetStateDown(SteamVR_Input_Sources.LeftHand) || ToggleInventory.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                if (RightInventory.transform.GetChild(0).gameObject.activeSelf)
                {
                    RightInventory.transform.GetChild(1).gameObject.SetActive(true);
                    RightInventory.transform.GetChild(0).gameObject.SetActive(false);
                }
                else if (RightInventory.transform.GetChild(1).gameObject.activeSelf)
                {
                    RightInventory.transform.GetChild(0).gameObject.SetActive(true);
                    RightInventory.transform.GetChild(1).gameObject.SetActive(false);
                }

                if (LeftInventory.transform.GetChild(0).gameObject.activeSelf)
                {
                    LeftInventory.transform.GetChild(1).gameObject.SetActive(true);
                    LeftInventory.transform.GetChild(0).gameObject.SetActive(false);
                }
                else if (LeftInventory.transform.GetChild(1).gameObject.activeSelf)
                {
                    LeftInventory.transform.GetChild(0).gameObject.SetActive(true);
                    LeftInventory.transform.GetChild(1).gameObject.SetActive(false);
                }
            }
        }
    }
}
