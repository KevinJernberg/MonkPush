using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class CursorChangeScript : MonoBehaviour
{
    private StarterAssetsInputs _input;
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }
    public void WinCursorState()
    {
        Debug.Log("win");
        _input.cursorLocked = false;
        _input.cursorInputForLook = false;
    }

    public void ToggleCursorState()
    {
        _input.cursorLocked = !_input.cursorLocked;
        _input.cursorInputForLook = !_input.cursorInputForLook;
    }

}
