using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPuzzleBlock : MonoBehaviour
{
    private Vector3 _originalPos;
    private void Start()
    {
        _originalPos = transform.position;
    }

    public void ResetPos()
    {
        transform.position = _originalPos;
        gameObject.GetComponent<BlockPusher>()._moving = false;
    }
}
