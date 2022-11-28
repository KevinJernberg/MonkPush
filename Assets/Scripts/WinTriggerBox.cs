using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTriggerBox : MonoBehaviour
{
    public LevelChanger levelChanger;
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        levelChanger.FadeToLevel();
    }
}
