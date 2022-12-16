using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPuzzleBlock : MonoBehaviour
{
    private Vector3 _originalPos;

    [SerializeField] 
    private AudioSource _audio;
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _originalPos = transform.position;
    }

    public void ResetPos()
    {
        transform.position = _originalPos;
        gameObject.GetComponent<BlockPusher>()._moving = false;

        _audio.clip = null;
    }
}
