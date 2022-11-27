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

    private enum PushDir
    {
        West,
        North,
        East,
        South
    }

    private PushDir _pushedDirection;
    
    // Update is called once per frame

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1f;
        var pushRay = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        
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
                    
                    float characterDiagonalCheck = transform.rotation.eulerAngles.y;

                    if (characterDiagonalCheck is < 30 or > 330) //Pos Z
                    {
                        _pushedDirection = PushDir.North;
                        _newMovedPos = _foundHitBlock.transform.position + new Vector3(0, 0, 2);
                    }
                    else if (characterDiagonalCheck is < 120 and > 60) //Neg X
                    {
                        _pushedDirection = PushDir.West;
                        
                        _newMovedPos = _foundHitBlock.transform.position + new Vector3(2, 0, 0);
                        //_hitBlock.transform.position = Vector3.Lerp(_hitBlock.transform.position,
                            //_hitBlock.transform.position + new Vector3(2, 0, 0), 1);
                    }
                    else if (characterDiagonalCheck is < 210 and > 150) //Neg Z
                    {
                        _pushedDirection = PushDir.South;
                        _newMovedPos = _foundHitBlock.transform.position + new Vector3(0, 0, -2);
                        //_hitBlock.transform.position = Vector3.Lerp(_hitBlock.transform.position,
                            //_hitBlock.transform.position + new Vector3(0, 0, -2), 1);
                    }
                    else if (characterDiagonalCheck is < 300 and > 240) //Pos X
                    {
                        _pushedDirection = PushDir.East;
                        _newMovedPos = _foundHitBlock.transform.position + new Vector3(-2, 0, 0);
                        //_hitBlock.transform.position = Vector3.Lerp(_hitBlock.transform.position,
                            //_hitBlock.transform.position + new Vector3(-2, 0, 0), 1);
                    }
                    _pushTime = 0;
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
