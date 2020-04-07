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
    public bool available = false;
    public UnlockButton unlockButton;
    public bool unlocked = false;
    public Text text;
    //to-do: Add other ways for Resource values to change
    void Awake()
    {
        button.onClick.AddListener(ResourceUsage);//Method for reducing resource use for each resource that the policy/decision requires
        int i = 0;
        while(i<otherButtons.Count)
        {
            otherButtons[i].onClick.AddListener(PressedTheOtherButtons);//check if narratively conflicting buttons are pressed
            i++;
        }
        if(unlockButton)
        {
            text = gameObject.transform.Find("UnlockNeeded").gameObject.GetComponent<Text>();
            text.text = unlockButton.gameObject.name;
        }
        else if(!unlockButton)
        {
            text = null;
            unlocked = true;
        }
        gameResources[0] = GameObject.Find("Energy").GetComponent<GameResource>();
        gameResources[1] = GameObject.Find("Wealth").GetComponent<GameResource>();
        gameResources[2] = GameObject.Find("Renewables").GetComponent<GameResource>();

    }

    private void PressedTheOtherButtons()
    {
        pressedOther = true;
    }

    private void ResourceUsage()
    {
        pressed = true;
        int i = 0;
        while(i<gameResources.Count)//modifying each resource that the policy uses
        {
            gameResources[i].value -= ResourceUse[i];
            i++;
        }
    }


    private void Update()
    {
        CheckIfResourceAvailable();//method to check if resource values are high enough to spend a resource
        CheckIfUnlockNeeded();
        CheckIfCanBeExecuted();
    }

    private void CheckIfCanBeExecuted()
    {
        if(unlocked && available)
        {
            button.interactable = true;
        }
        else if(!unlocked && available)
        {
            button.interactable = false;
        }
        else if(unlocked && !available)
        {
            button.interactable = false;
        }
    }

    private void CheckIfUnlockNeeded()
    {
        if(unlockButton)
        {
            if(unlockButton.unlock)
            {
                unlocked = true;
            }
            else if(!unlockButton.unlock)
            {
                unlocked = false;
            }
        }
    }

    private void CheckIfResourceAvailable()
    {
        int i = 0;
        while(i<gameResources.Count)
        {
            if ((gameResources[i].value - ResourceUse[i])<0)
            {
                available = false;
            }
            else if ((gameResources[i].value - ResourceUse[i]) >= 0 && !pressed && !pressedOther)
            {
                available = true;
            }
            i++;
        }
        
    }

}
