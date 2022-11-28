using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    private void OnFadeComplete()
    {
        SceneManager.LoadScene("Main");
    }
}
