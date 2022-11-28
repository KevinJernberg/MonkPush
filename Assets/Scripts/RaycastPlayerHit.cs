using System;
using StarterAssets;
using UnityEngine;

public class RaycastPlayerHit : MonoBehaviour
{
    
    private float _pushTime = 1;
    
    [SerializeField, Tooltip("How fast the pushed block will move")]
    private float _pushSpeed = 2f;

    private StarterAssetsInputs _input;

    private RaycastHit _foundHitBlock;
    private RaycastHit _hitBlock;

    private Vector3 _oldPos;
    private Vector3 _newMovedPos;

    private Vector3 _boxForwardDirection;


    private enum PushDir
    {
        West,
        North,
        East,
        South
    }

    private PushDir _pushedDirection;

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        // Character push check ray
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1f;
        Vector3 pushRay = transform.position + new Vector3(0, 1, 0);
        Debug.DrawRay(pushRay, forward, Color.green);

        if (Physics.Raycast(pushRay, transform.TransformDirection(Vector3.forward), out _hitBlock, 1f, 64))
        {
            _foundHitBlock = _hitBlock;
            if (_hitBlock.collider != null)
            {
                if (_input.push && _pushTime == 1f)
                {
                    _input.push = false;
                    _oldPos = _foundHitBlock.transform.position;
                    
                    float characterDiagonalCheck = transform.rotation.eulerAngles.y; // Use Angle instead of radians
                    
                    
                    //TODO: Make this a switch case, to increase readability 
                    if (characterDiagonalCheck is < 30 or > 330) //Pos Z 
                    {
                        _pushedDirection = PushDir.North;
                        _newMovedPos = _foundHitBlock.transform.position + new Vector3(0, 0, 2);
                        _boxForwardDirection = new Vector3(0, 0, 1);

                    }
                    else if (characterDiagonalCheck is < 120 and > 60) //Neg X
                    {
                        _pushedDirection = PushDir.West;
                        _newMovedPos = _foundHitBlock.transform.position + new Vector3(2, 0, 0);
                        _boxForwardDirection = new Vector3(1, 0, 0);
                    }
                    else if (characterDiagonalCheck is < 210 and > 150) //Neg Z
                    {
                        _pushedDirection = PushDir.South;
                        _newMovedPos = _foundHitBlock.transform.position + new Vector3(0, 0, -2);
                        _boxForwardDirection = new Vector3(0, 0, -1);
                    }
                    else if (characterDiagonalCheck is < 300 and > 240) //Pos X
                    {
                        _pushedDirection = PushDir.East;
                        _newMovedPos = _foundHitBlock.transform.position + new Vector3(-2, 0, 0);
                        _boxForwardDirection = new Vector3(-1, 0, 0);
                    }
                    
                    // Sets a new position for the collision check. Right above the lowest point of the block.
                    Vector3 collisionCheckOriginPoint = _oldPos - new Vector3(0, _foundHitBlock.transform.localScale.y * 0.5f - 0.1f, 0); 
                    
                    if (!Physics.Raycast(collisionCheckOriginPoint, _boxForwardDirection, 2f, 192))
                    {
                        _pushTime = 0; // Starts the push mechanism
                    }
                }
            }
        }
        else
        {
            _input.push = false;
        }
        
        if (_pushTime < 1)
        {
            _pushTime += _pushSpeed * Time.deltaTime;
            _input.push = false;
            if (_pushTime > 1)
            {
                _pushTime = 1;
            }
            switch (_pushedDirection)
            {
                // Move the block to specific coordinate with relation to time 
                case PushDir.North:
                    _foundHitBlock.transform.position = Vector3.Lerp(_oldPos, _newMovedPos, _pushTime);
                    break;
                case PushDir.East:
                    _foundHitBlock.transform.position = Vector3.Lerp(_oldPos, _newMovedPos, _pushTime);
                    break;
                case PushDir.West:
                    _foundHitBlock.transform.position = Vector3.Lerp(_oldPos, _newMovedPos, _pushTime);
                    break;
                case PushDir.South:
                    _foundHitBlock.transform.position = Vector3.Lerp(_oldPos, _newMovedPos, _pushTime);
                    break;
            }
        }
    }
}
