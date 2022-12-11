using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 _respawnPos;

    [Tooltip("The Game Event that is called when player presses R")]
    public GameEvent onPuzzleReset;

    private StarterAssetsInputs _input;

    void Start()
    {
        _respawnPos = transform.position;
        _input = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (_input.reset)
        {
            _input.reset = false;
            onPuzzleReset.Raise();
        }
    }

    public void Respawn()
    {
        GetComponent<CharacterController>().enabled = false;
        transform.position = _respawnPos;
        GetComponent<CharacterController>().enabled = true;
    }
    
    public void SetRespawnPoint(Vector3 newRespawnPos)
    {
        _respawnPos = newRespawnPos;
    }
}
