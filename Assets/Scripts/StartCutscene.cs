using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.Serialization;

public class StartCutscene : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;

    [SerializeField] 
    private CinemachineVirtualCamera goatCamera;

    [SerializeField] 
    private CinemachineVirtualCamera situationCamera;

    private float _timer = 8;

    private CinemachineVirtualCamera _situationComponent;
    private CinemachineVirtualCamera _goatComponent;

    private ThirdPersonController _playerController;
    private StarterAssetsInputs _playerInput;

    private void Start()
    {
        _goatComponent = goatCamera.GetComponent<CinemachineVirtualCamera>();
        _situationComponent = situationCamera.GetComponent<CinemachineVirtualCamera>();
        _playerController = player.GetComponent<ThirdPersonController>();
        _playerInput = player.GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        _playerController.isFrozen = true;
        _playerInput.look = Vector2.zero;
        _playerInput.Pause = false;

        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _playerController.isFrozen = false;
            Destroy(this);
        }
        else if (_timer <= 2)
        {
            _situationComponent.Priority = 0;
        }
        else if ( _timer <= 6)
        {
            _goatComponent.Priority = 0;
        }
    }
}
