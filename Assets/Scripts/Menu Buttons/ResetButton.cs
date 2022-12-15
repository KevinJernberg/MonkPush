using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    
    [SerializeField]
    private GameEvent resetEvent;

    public void Reset()
    {
        resetEvent.Raise();
    }
}
