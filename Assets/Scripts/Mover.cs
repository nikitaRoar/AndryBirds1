using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mover : MonoBehaviour
{
    [SerializeField]
    string levelName;
    public void MoveToSpecifiedLecvel()
    {
        SceneManager.LoadScene(levelName);
    }
}
