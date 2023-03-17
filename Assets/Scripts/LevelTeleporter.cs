using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{
    public class LevelTeleporter : MonoBehaviour
    {

        public string SceneName;

        // Start is called before the first frame update
        public void OnButtonDown(Hand fromHand)
        {
            ColorSelf(Color.cyan);
            fromHand.TriggerHapticPulse(1000);
            print("Button Down");
        }

        public void OnButtonUp(Hand fromHand)
        {
            SceneManager.LoadScene(SceneName);
            print("Changing Scene");
        }

        private void ColorSelf(Color newColor)
        {
            Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
            {
                renderers[rendererIndex].material.color = newColor;
            }
        }
    }

}
