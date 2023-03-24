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

    // Start is called before the first frame update
    public void OnButtonDown(Hand fromHand)
    {
        ColorSelf(Color.cyan);
        fromHand.TriggerHapticPulse(1000);
    }

    public void OnButtonUp(Hand fromHand)
    {
        print("Level Button coming up");
        print(Elevator.getDoorPosition());
        if (Elevator.getDoorPosition())
            ScreenLoad();
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
        print("Unloading Current Scene");
        SceneManager.UnloadSceneAsync(SceneOrigin);
        SceneManager.LoadScene(SceneDestination);        
    }
}
