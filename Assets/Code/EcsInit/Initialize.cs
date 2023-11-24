using UnityEngine;

namespace Code.EcsInit
{
    public class Initialize : MonoBehaviour
    {
        void Start()
        {
            DisableAutoRotation();
            Application.targetFrameRate = 60;
        }
        
        private void DisableAutoRotation() {
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
}
