using UnityEngine;

namespace Code.EcsInit
{
    public class Initialize : MonoBehaviour
    {
        void Start()
        {
            DisableAutoRotation();
        }
        
        private void DisableAutoRotation() {
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
}
