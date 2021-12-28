using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdsController : MonoBehaviour
{
    private Bird[] birds;
    [SerializeField]
    string levelName;
    private void OnEnable()
    {
        birds = FindObjectsOfType<Bird>();
        foreach(Bird bird in birds)
        {
            bird.gameObject.SetActive(true);
        }
    }
    void Update()
    {
        if (BirdsAreAllDead())
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(levelName);
    }

    private bool BirdsAreAllDead()
    {
        foreach (Bird  bird in birds )
        {
            if (bird.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
}
