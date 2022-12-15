using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PauseMenuBehavior : MonoBehaviour
{
    private bool _pause;
    
    [SerializeField]
    private Canvas backgroundOpacityCanvas;
    
    [SerializeField]
    private Canvas menuWindowCanvas;

    public void ChangePauseState()
    {
        _pause = !_pause;
        Debug.Log(_pause);
        if (_pause)
        {
            backgroundOpacityCanvas.enabled = true;
            menuWindowCanvas.enabled = true;
        }
        else
        {
            backgroundOpacityCanvas.enabled = false;
            menuWindowCanvas.enabled = false;
        }
    }
    
    
    
}
