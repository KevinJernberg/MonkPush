using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class RaycastPlayerHit : MonoBehaviour
{
    private float pushTime;

    private StarterAssetsInputs _input;
    
    // Update is called once per frame

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        if (pushTime >= 0)
        {
            pushTime -= Time.deltaTime;
        }
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1f;
        var pushRay = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        
        Debug.DrawRay(pushRay, forward, Color.green);
        
        if (Physics.Raycast(pushRay, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 1f))
        {
            if (hitInfo.collider != null)
            {
                if (_input.push && pushTime <= 0)
                {
                    _input.push = false;
                    float characterDiagonalCheck = transform.rotation.eulerAngles.y;

                    if (characterDiagonalCheck is < 30 or > 330) //Pos Z
                    {
                        hitInfo.transform.position = Vector3.Lerp(hitInfo.transform.position,
                            hitInfo.transform.position + new Vector3(0, 0, 2), 1);
                    }
                    else if (characterDiagonalCheck is < 120 and > 60) //Neg X
                    {
                        hitInfo.transform.position = Vector3.Lerp(hitInfo.transform.position,
                            hitInfo.transform.position + new Vector3(2, 0, 0), 1);
                    }
                    else if (characterDiagonalCheck is < 210 and > 150) //Neg Z
                    {
                        hitInfo.transform.position = Vector3.Lerp(hitInfo.transform.position,
                            hitInfo.transform.position + new Vector3(0, 0, -2), 1);
                    }
                    else if (characterDiagonalCheck is < 300 and > 240) //Pos X
                    {
                        hitInfo.transform.position = Vector3.Lerp(hitInfo.transform.position,
                            hitInfo.transform.position + new Vector3(-2, 0, 0), 1);
                    }
                    pushTime = 1;
                }
            }
        }
        else
        {
            _input.push = false;
        }
    }
}
