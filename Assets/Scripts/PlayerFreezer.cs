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
        _playerController.isFrozen = true;
    }
    
    public void UnFreeze()
    {
        _playerController.isFrozen = false;
    }

    public void ToggleFrozen()
    {
        _playerController.isFrozen = !_playerController.isFrozen;
    }
}
