using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class PauseMenuBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    private PauseInputScript _pauseScript;
    void Start()
    {
        _pauseScript = GetComponent<PauseInputScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_pauseScript.pause)
        {
            _pauseScript.pause = false;
            Debug.Log("Menu");
        }
    }
}
