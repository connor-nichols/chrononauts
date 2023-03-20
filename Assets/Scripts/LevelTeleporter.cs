using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{
    public class LevelTeleporter : MonoBehaviour
    {
        private Scene SceneOrigin = SceneManager.GetActiveScene();
        public string SceneDestination;

        // Start is called before the first frame update
        public void OnButtonDown(Hand fromHand)
        {
            ColorSelf(Color.cyan);
            fromHand.TriggerHapticPulse(1000);
            print("Button Down");
        }

        public void OnButtonUp(Hand fromHand)
        {
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

}
