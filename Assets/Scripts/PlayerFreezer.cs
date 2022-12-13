using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PlayerFreezer : MonoBehaviour
{
    private ThirdPersonController _playerController;
    void Start()
    {
        _playerController = GetComponent<ThirdPersonController>();
    }


    public void Freeze()
    {
        _playerController.enabled = false;
    }
    
    public void UnFreeze()
    {
        _playerController.enabled = true;
    }

    public void ToggleFrozen()
    {
        _playerController.enabled = !_playerController.enabled;
    }
}
