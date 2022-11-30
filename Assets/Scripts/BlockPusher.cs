using System;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BlockPusher : MonoBehaviour
{
    private Vector3 _PushDirection;
    private float _pushForce;

    private bool _moving;
    private bool _falling;

    private Vector3 _fallingPointOffset;

    private float _collisionEdgeDistance;

    // Update is called once per frame

    private void Start()
    {
        _fallingPointOffset.y = -(transform.localScale.y / 2);
    }

    void Update()
    {
        if (isFalling())
        {
            Fall();
        }
        else if (_moving)
        {
            Push();
        }

    }

    public void StartPush(Vector3 direction, float force)
    {
        _PushDirection = direction * -1f;
        _pushForce = force;
        _moving = true;
        if (_PushDirection.x == 0) // Moving in Z axis
        {
            _collisionEdgeDistance = transform.localScale.z / 2f;
            _fallingPointOffset.z = -_collisionEdgeDistance;
        }
        else // Moving in X axis
        {
            _collisionEdgeDistance = transform.localScale.x / 2f;
            _fallingPointOffset.z = -_collisionEdgeDistance;
        }
    }

    private void Push()
    {
        transform.position += _PushDirection * _pushForce * Time.deltaTime;
        Vector3 collisionCheckOriginPoint = new Vector3(transform.position.x,
            transform.position.y - transform.lossyScale.y * 0.5f + 0.05f, transform.position.z);

        if (Physics.Raycast(collisionCheckOriginPoint, _PushDirection, _collisionEdgeDistance))
        {
            _moving = false;
            RestrictPosition();
        }
    }

    private bool isFalling()
    {
        Vector3 fallingPoint = transform.position + _fallingPointOffset;
        if (Physics.Raycast(fallingPoint, Vector3.down, 0.10f))
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
        if (!Physics.Raycast(fallingPoint, Vector3.down, transform.localScale.y / 2 + 0.10f))
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