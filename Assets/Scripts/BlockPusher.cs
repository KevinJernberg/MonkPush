using System;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Serialization;

public class BlockPusher : MonoBehaviour
{
    private Vector3 _PushDirection;
    private float _pushForce;

    public bool _moving;
    private bool _falling;

    private Vector3 _fallingPointOffset;

    private float _collisionEdgeDistance;

    private float _pushAccelerateFactor = 1f;

    [SerializeField]
    
    private AudioSource AudioSource;

    [FormerlySerializedAs("BlockWallHitSound")] [SerializeField, Tooltip("The Sound made when a block hits a wall and stops")]
    private AudioClip blockWallHitSound;
    
    [FormerlySerializedAs("BlockWallHitSound")] [SerializeField, Tooltip("The Sound made when a block hits a wall and stops")]
    private AudioClip blockDragSound;

    void Update()
    {
        if (isFalling())
        {
            Fall();
        }
        else if (_moving)
        {
            PushAccelerate();
            Push();
        }
    }

    public void StartPush(Vector3 direction, float force)
    {
        _PushDirection = direction * -1f;
        _pushAccelerateFactor = 0.1f;
        _pushForce = force;
        _moving = true;
        AudioSource.clip = blockDragSound;
        _fallingPointOffset = new Vector3();
        //_fallingPointOffset.y = -(transform.localScale.y / 2) + 0.1f;
        if (_PushDirection.x == 0) // Moving in Z axis
        {
            _collisionEdgeDistance = transform.localScale.z / 2f;
            _fallingPointOffset.z = _PushDirection.z * -_collisionEdgeDistance;
        }
        else // Moving in X axis
        {
            _collisionEdgeDistance = transform.localScale.x / 2f;
            _fallingPointOffset.x = _PushDirection.x * -_collisionEdgeDistance;
        }
    }

    private void Push()
    {
        transform.position += _PushDirection * _pushForce * Time.deltaTime * _pushAccelerateFactor;
        Vector3 collisionCheckOriginPoint = new Vector3(transform.position.x,
            transform.position.y - transform.localScale.y * 0.5f + 0.05f, transform.position.z);
        AudioSource.clip = blockDragSound;
        AudioSource.loop = true;
        AudioSource.PlayClipAtPoint(blockDragSound, transform.position);
        if (Physics.Raycast(collisionCheckOriginPoint, _PushDirection, _collisionEdgeDistance))
        {
            _moving = false;
            AudioSource.loop = false;
            AudioSource.PlayClipAtPoint(blockWallHitSound, transform.position);
            RestrictPosition();
            if (blockWallHitSound != null)
            {
                AudioSource.PlayClipAtPoint(blockWallHitSound, transform.position);
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

    private bool isFalling()
    {
        Vector3 fallingPoint = transform.position + _fallingPointOffset;
        Debug.DrawRay(fallingPoint, Vector3.down, Color.magenta);
        if (Physics.Raycast(fallingPoint, Vector3.down,  transform.localScale.y/2 + 0.1f))
        {
            if (_falling)
            {
                _falling = false;
                RestrictPosition();
            }
            return false;
        }
        _moving = false;
        return true;
    }

    private void Fall()
    {
        _falling = true;
        Vector3 fallingPoint = transform.position;
        Debug.DrawRay(fallingPoint, Vector3.down, Color.magenta);
        if (!Physics.Raycast(fallingPoint, Vector3.down, + transform.localScale.y/2 + 0.1f))
        {
            transform.position += Vector3.down * (5f * Time.deltaTime);
        }
    }

    private void RestrictPosition()
    {
        transform.position = new Vector3(MathF.Round(transform.position.x * 2) / 2,
            MathF.Round(transform.position.y * 2) / 2, MathF.Round(transform.position.z * 2) / 2);
    }
}