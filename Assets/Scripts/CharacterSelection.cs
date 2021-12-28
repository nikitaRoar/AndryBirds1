using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;
    private readonly string selectedCharacter = "SelectedCharacter";
    private void Start()
    {
        characterList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject gameObject in characterList)
        {
            gameObject.SetActive(false);
        }
        if (characterList[0])
        {
            characterList[0].SetActive(true);
        }
    }
    public void Toggleleft()
    {
        characterList[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }
        characterList[index].SetActive(true);
        PlayerPrefs.SetInt(selectedCharacter, index);
    }
    public void ToggleRight()
    {
        characterList[index].SetActive(false);
        index++;
        if (index >= characterList.Length)
        {
            index = 0;
        }
        characterList[index].SetActive(true);
        PlayerPrefs.SetInt(selectedCharacter, index);
    }
}
