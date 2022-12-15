using UnityEngine;

namespace Menu_Buttons
{
    public class ContinueButton : MonoBehaviour
    {
        [SerializeField]
        private GameEvent resumeEvent;

        public void Continue()
        {
            resumeEvent.Raise();
        }
    }
}
