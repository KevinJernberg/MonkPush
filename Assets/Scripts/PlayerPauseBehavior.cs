using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PlayerPauseBehavior : MonoBehaviour
{
    private StarterAssetsInputs _input;
    
    [SerializeField]
    private GameEvent _onPauseEvent;
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.Pause)
        {
            _input.Pause = false;
            _onPauseEvent.Raise();
        }
    }
}
