using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
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
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), forward, Color.green);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 1f))
        {
            if (_input.push && pushTime <= 0)
            {
                Debug.Log("Hit");
                var mesh = hitInfo.transform.GetComponent<MeshFilter>().mesh;
                _input.push = false;
                pushTime = 1;
            }
        }
        else
        {
        }
    }
}
