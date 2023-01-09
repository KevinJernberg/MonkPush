using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class CutsceneBehavior : MonoBehaviour
{
    [SerializeField]
    private LevelChanger levelChanger;
    
    [Header("Images")]
    [SerializeField] private GameObject firstImage;
    [SerializeField] private GameObject secondImage;
    [SerializeField] private GameObject thirdImage;
    [SerializeField] private GameObject fourthImage;
    [SerializeField] private GameObject fifthImage;
    
    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer < 10)
        {
            switch (_timer)
            {
                case < 2:
                    firstImage.SetActive(true);
                    break;
                case < 4:
                    firstImage.SetActive(false);
                    secondImage.SetActive(true);
                    break;
                case < 6:
                    secondImage.SetActive(false);
                    thirdImage.SetActive(true);
                    break;
                case < 8:
                    thirdImage.SetActive(false);
                    fourthImage.SetActive(true);
                    break;
                case < 10:
                    fourthImage.SetActive(false);
                    fifthImage.SetActive(true);
                    break;
            }
        }
        else
        {
            levelChanger.FadeToLevel("Level 1");
        }
    }
}
