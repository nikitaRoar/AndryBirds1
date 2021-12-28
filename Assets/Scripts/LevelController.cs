using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Monster[] monsters;
    [SerializeField]
    string levelName;
    private void OnEnable()
    {
       monsters = FindObjectsOfType<Monster>();
    }
    void Update()
    {
        if (MonstersAreAllDead())
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(levelName);
    }

    private bool MonstersAreAllDead()
    {
       foreach (Monster monster in monsters)
        {
            if (monster.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
}
