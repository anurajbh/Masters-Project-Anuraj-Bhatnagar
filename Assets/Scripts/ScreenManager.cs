using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject TreeState;
    public GameObject ReportState;
    public GameObject CityState;
    private void Awake()
    {
        DisplayScreen(TreeState);
    }

    private void DisplayScreen(GameObject ScreenState)
    {
        ScreenState.SetActive(true);
    }
    private void Update()
    {
        CheckForUserInput();
    }

    private void CheckForUserInput()
    {
        throw new NotImplementedException();
    }
}
