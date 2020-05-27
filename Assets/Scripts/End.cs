using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class End : MonoBehaviour
{
    void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(EndTheGame);
    }

    private void EndTheGame()
    {
        Application.Quit();
    }

}
