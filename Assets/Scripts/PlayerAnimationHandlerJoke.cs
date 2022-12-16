using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PlayerAnimationHandlerJoke : MonoBehaviour
{
    private StarterAssetsInputs _inputs;
    private Animator _animator;
    private bool _idle;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _inputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (_inputs.Joke)
        {
            _inputs.Joke = false;
            _idle = !_idle;
            _animator.SetBool("Idle", _idle);
        }
    }
}
