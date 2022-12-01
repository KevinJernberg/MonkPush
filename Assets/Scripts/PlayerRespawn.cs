using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEditor.Compilation;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 _respawnPos;
    // Start is called before the first frame update
    void Start()
    {
        _respawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        GetComponent<CharacterController>().enabled = false;
        transform.position = _respawnPos;
        GetComponent<CharacterController>().enabled = true;
    }
    
    public void SetRespawnPoint(Vector3 newRespawnPos)
    {
        Debug.Log("set");
        _respawnPos = newRespawnPos;
        
    }
}
