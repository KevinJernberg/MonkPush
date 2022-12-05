using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private string _sceneName;

    public void FadeToLevel(string sceneName)
    {
        _sceneName = sceneName;
        animator.SetTrigger("FadeOut");
    }

    private void OnFadeComplete()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
