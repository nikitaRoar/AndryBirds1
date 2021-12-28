using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePanel : MonoBehaviour
{
    public void EnableFirstChildPanel()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void EnableSecondChildPanel()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }
    private void Update()
    {
    }
}
