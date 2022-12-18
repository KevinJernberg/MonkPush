using UnityEngine;
using UnityEngine.Serialization;

namespace Menu_Buttons
{
    public class ExitButton : MonoBehaviour
    {
        [SerializeField]
        private LevelChanger levelChanger;

        [SerializeField]
        private GameEvent exitEvent;
        
        // Start is called before the first frame update

        public void ExitToMainMenu()
        {
            levelChanger.FadeToLevel("StartScene");
            exitEvent.Raise();
        }
    }
}
