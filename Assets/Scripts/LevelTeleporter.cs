using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class LevelTeleporter : MonoBehaviour
{
    public string SceneOrigin;
    public string SceneDestination;
    public ElevatorController Elevator;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    public void OnButtonDown(Hand fromHand)
    {
        ColorSelf(Color.cyan);
        fromHand.TriggerHapticPulse(1000);
        audioSource.Play();
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
    }
}
