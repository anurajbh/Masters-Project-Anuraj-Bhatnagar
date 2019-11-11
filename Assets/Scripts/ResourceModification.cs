using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceModification : MonoBehaviour
{
    public List<GameResource> gameResources;

    public float EnergyUse = 2f;
    public float WealthUse = 2f;
    public Button button;
    //to-do: Add other ways for Resource values to change
    void Start()
    {
        button.onClick.AddListener(ResourceUsage);
    }

    private void ResourceUsage()
    {
        gameResources[0].value -= EnergyUse;
        gameResources[1].value -= WealthUse;
    }


    private void Update()
    {
        CheckIfResourceAvailable();
    }

    private void CheckIfResourceAvailable()
    {
        if((gameResources[0].value - EnergyUse) <0 && (gameResources[1].value - WealthUse) < 0)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
