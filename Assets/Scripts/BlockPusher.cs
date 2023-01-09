using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BlockPusher : MonoBehaviour
{
    private BoxCollider _colliderBox;
    
    private Vector3 _PushDirection;
    private float _pushForce;

    public bool _moving;
    private bool _falling;

    private Vector3 _fallingPointOffset;

    private float _collisionEdgeDistance;

    private float _pushAccelerateFactor = 1f;

    private float _fallAccelerateFactor = 1f;

    [SerializeField]
    
    private AudioSource audioSource;

    [FormerlySerializedAs("BlockWallHitSound")] [SerializeField, Tooltip("The Sound made when a block hits a wall and stops")]
    private AudioClip blockWallHitSound;
    
    [FormerlySerializedAs("BlockWallHitSound")] [SerializeField, Tooltip("The Sound made when a block hits a wall and stops")]
    private AudioClip blockDragSound;

    private int _soundOffset;
    private void Start()
    {
        _colliderBox = gameObject.GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (isFalling())
        {
            FallAccelerate();
            Fall();
        }
        else if (_moving)
        {
            PushSound();
            PushAccelerate();
            Push();
        }
    }

    public void StartPush(Vector3 direction, float force)
    {
        if (_moving)
            return; 
        
        _PushDirection = direction * -1f;
        _pushAccelerateFactor = 0.1f;
        _pushForce = force;

        _fallAccelerateFactor = 1;
            
        _moving = true;
        
        audioSource.clip = blockDragSound;
        audioSource.volume = 0.4f;
        audioSource.loop = true;
        _soundOffset = 0;
        
        _fallingPointOffset = new Vector3();
        
        if (_PushDirection.x == 0) // Moving in Z axis
        {
            _collisionEdgeDistance = (_colliderBox.size.z * transform.localScale.x) / 2f;
            _fallingPointOffset.z = _PushDirection.z * -_collisionEdgeDistance;
        }
        else // Moving in X axis
        {
            _collisionEdgeDistance = (_colliderBox.size.x * transform.localScale.x) / 2f;
            _fallingPointOffset.x = _PushDirection.x * -_collisionEdgeDistance;
        }
    }

    private void Push()
    {
        transform.position += _PushDirection * _pushForce * Time.deltaTime * _pushAccelerateFactor;
        Vector3 collisionCheckOriginPoint = new Vector3(transform.position.x,
            transform.position.y - transform.localScale.y * 0.5f + 0.05f, transform.position.z);
        
        Debug.DrawRay(collisionCheckOriginPoint, _PushDirection, Color.green);
        if (_soundOffset != 2)
        {
            _soundOffset++;
        }
        if (Physics.Raycast(collisionCheckOriginPoint, _PushDirection, _collisionEdgeDistance, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            _moving = false;
            audioSource.loop = false;
            audioSource.Stop();
            
            RestrictPosition();
            if (_soundOffset == 2)
            {
                audioSource.clip = blockWallHitSound;
                audioSource.volume = 0.2f;
                audioSource.Play();
            }
        }
    }

    private void PushAccelerate()
    {
        if (_pushAccelerateFactor < 1)
        {
            _pushAccelerateFactor += Time.deltaTime;
        }
        else
        {
            _pushAccelerateFactor = 1;
        }
    }
    private void FallAccelerate()
        {
            if (_fallAccelerateFactor < 2)
            {
                _fallAccelerateFactor += Time.deltaTime;
            }
            else
            {
                _fallAccelerateFactor = 2;
            }
        }

    private bool isFalling()
    {
        Vector3 fallingPoint;
        if (_falling)
        {
            fallingPoint = transform.position + new Vector3(0f, 0.40f, 0f);
        }
        else
        {
            fallingPoint = transform.position + new Vector3(0f, 0.40f, 0f) + _fallingPointOffset;
        }
        Debug.DrawRay(fallingPoint, Vector3.down, Color.magenta);
        if (Physics.Raycast(fallingPoint, Vector3.down,out RaycastHit hit, 0.5f, 64+1+128, QueryTriggerInteraction.Ignore))
        {
            if (_falling)
            {
                _falling = false;
                audioSource.clip = blockWallHitSound;
                audioSource.volume = 0.2f;
                audioSource.loop = false;
                audioSource.Play();
                RestrictPosition();
            }
            return false;
        }
        audioSource.Stop();
        _moving = false;
        return true;
    }

    private void Fall()
    {
        _falling = true;
        transform.position += Vector3.down * (5f * Time.deltaTime) * _fallAccelerateFactor;
    }

    private void RestrictPosition()
    {
        transform.position = new Vector3(MathF.Round(transform.position.x * 4) / 4,
            MathF.Round(transform.position.y * 4) / 4, MathF.Round(transform.position.z * 4) / 4);
    }
    
    private void PushSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}