using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;
using AK.Wwise;

public class LevelTeleporter : MonoBehaviour
{
    public string SceneOrigin;
    public string SceneDestination;
    public ElevatorController Elevator;

    public GameObject elevatorButton;

    private GameObject playerObject;
    // private AudioSource audioSource;

    private void Start()
    {
        // audioSource = GetComponent<AudioSource>();
        playerObject = GameObject.Find("Player");
    }

    public void OnButtonDown(Hand fromHand)
    {
        AkSoundEngine.PostEvent("ElevatorButtonClick", elevatorButton);
        // audioSource.Play();
        ColorSelf(Color.cyan);
        fromHand.TriggerHapticPulse(1000);
        if (Elevator.getDoorPosition())
            ScreenLoad();
    }
    public void OnButtonUp(Hand fromHand)
    {
    }

    private void ColorSelf(Color newColor)
    {
        Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
        for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
        {
            renderers[rendererIndex].material.color = newColor;
        }
    }

    private void ScreenLoad()
    {
        SceneManager.UnloadSceneAsync(SceneOrigin);
        SceneManager.LoadScene(SceneDestination);
        // maybe change this to the complete elevator
        AkSoundEngine.PostEvent("ElevatorTravel", elevatorButton);

        // Room Ambience
        switch (SceneDestination)
        {
            case "Start":
                AkSoundEngine.PostEvent("Roomtone2020s", playerObject);
                break;

            case "LevelScene-2020s":
                AkSoundEngine.PostEvent("Roomtone2020s", playerObject);
                break;

            case "LevelScene-1990s":
                AkSoundEngine.PostEvent("Roomtone1990s", playerObject);
                break;

            case "LevelScene-1970s":
                AkSoundEngine.PostEvent("Roomtone1970s", playerObject);
                break;

            case "LevelScene-1940s":
                AkSoundEngine.PostEvent("Roomtone1940s", playerObject);
                break;

            case "LevelScene-30xx":
                AkSoundEngine.PostEvent("Roomtone30XX", playerObject);
                break;
        }
    }
}
