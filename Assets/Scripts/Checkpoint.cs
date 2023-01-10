using System;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;
    
    [SerializeField]
    private CinemachineVirtualCamera situationCamera;

    [SerializeField] private bool cameraPan;
    
    private CinemachineVirtualCamera _cameraComponent;
    private ThirdPersonController _playerController;
    private StarterAssetsInputs _playerInput;
    
    private Vector3 respawnPoint;
    

    private bool _frozen;
    private float _frozenTime;

    [SerializeField] private AudioSource goatYell;
    [SerializeField] private AudioClip checkpointAudio;

    private void Start()
    {
        _cameraComponent = situationCamera.GetComponent<CinemachineVirtualCamera>();
        _playerController = player.GetComponent<ThirdPersonController>();
        _playerInput = player.GetComponent<StarterAssetsInputs>();
        
        respawnPoint = transform.GetChild(0).transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerRespawn>().SetRespawnPoint(respawnPoint);
            if (!cameraPan)
                return;
            goatYell.clip = checkpointAudio;
            goatYell.Play(); 
            _frozen = true;
            _cameraComponent.Priority = 10;
        }
    }

    private void Update()
    {
        if (cameraPan && !_frozen) 
            return;
        
        _playerController.isFrozen = true;
        _playerInput.look = Vector2.zero;
        _playerInput.Pause = false;
            
        _frozenTime += Time.deltaTime;
        switch (_frozenTime)
        {
            case > 6:
                _playerController.isFrozen = false;
                _frozen = false;
                gameObject.SetActive(false);
                Debug.Log("dam");
                break;
            case > 4:
                _cameraComponent.Priority = 0;
                break;
        }
    }
}
