using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    int selectedCharacterIndex;
    void Start()
    {
        selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter");
    }
    // Update is called once per frame
    void Update()
    {
        switch (selectedCharacterIndex)
        {
            case 0:
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 1:
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                break;
        }
    }
}