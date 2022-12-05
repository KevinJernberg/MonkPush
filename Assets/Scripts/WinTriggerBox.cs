using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTriggerBox : MonoBehaviour
{
    public LevelChanger levelChanger;
    public enum ValidScenes
    {
        Main,
        Test,
        Level_1,
        Level_2,
        Level_3,
        Hub,
        WinScene
    }
    public ValidScenes nextScene;

    public GameEvent onWin;
    
    private string _selectedScene;
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        switch (nextScene)
        {
            case ValidScenes.Main:
                _selectedScene = "Main";
                break;
            case ValidScenes.Test:
                _selectedScene = "Test";
                break;
            case ValidScenes.Level_1:
                _selectedScene = "Level 1";
                break;
            case ValidScenes.Level_2:
                _selectedScene = "Level 2";
                break;
            case ValidScenes.Level_3:
                _selectedScene = "Level 3";
                break;
            case ValidScenes.Hub:
                _selectedScene = "Hub";
                break;
            case ValidScenes.WinScene:
                _selectedScene = "WinScene";
                break;
        }

        onWin.Raise();
        levelChanger.FadeToLevel(_selectedScene);
    }
}
