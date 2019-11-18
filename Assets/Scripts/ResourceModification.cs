using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceModification : MonoBehaviour
{
    public List<GameResource> gameResources;

    public List<float> ResourceUse;
    public Button button;
    Boolean pressed = false;
    public List<Button> otherButtons;
    Boolean pressedOther = false;
    //to-do: Add other ways for Resource values to change
    void Start()
    {
        button.onClick.AddListener(ResourceUsage);//Method for reducing resource use for each resource that the policy/decision requires
        int i = 0;
        while(i<otherButtons.Count)
        {
            otherButtons[i].onClick.AddListener(PressedTheOtherButtons);//check if narratively conflicting buttons are pressed
            i++;
        }
    }

    private void PressedTheOtherButtons()
    {
        pressedOther = true;
    }

    private void ResourceUsage()
    {
        pressed = true;
        int i = 0;
        while(i<=gameResources.Count)//modifying each resource that the policy uses
        {
            gameResources[i].value -= ResourceUse[i];
            i++;
        }
    }


    private void Update()
    {
        CheckIfResourceAvailable();//method to check if resource values are high enough to spend a resource
    }

    private void CheckIfResourceAvailable()
    {
        int i = 0;
        while(i<gameResources.Count)
        {
            if ((gameResources[i].value - ResourceUse[i])<0)
            {
                button.interactable = false;
            }
            else if ((gameResources[i].value - ResourceUse[i]) >= 0 && !pressed && !pressedOther)
            {
                button.interactable = true;
            }
            i++;
        }
        
    }

}
