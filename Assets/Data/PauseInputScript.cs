using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace Data
{
	public class PauseInputScript : MonoBehaviour
	{
		[Header("Character Input Values")]
		public bool pause;


#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		
		public void OnPause(InputValue value)
		{
			PauseInput(value.isPressed);
		}
		
		
		
#endif

		private void PauseInput(bool newPauseState)
		{
			pause = newPauseState;
		}
		
	}
	
}