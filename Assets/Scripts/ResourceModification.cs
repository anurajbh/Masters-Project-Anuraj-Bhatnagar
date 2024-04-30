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
    public float satModifier;
    public float disModifier;
    public HiddenPlayer hiddenPlayer;
    public GainModifier gainModifier;
    //to-do: Add other ways for Resource values to change
    void Awake()
    {
        button = gameObject.GetComponent<Button>();
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
            text.text = unlockButton.gameObject.name + " Needed";
        }
        else if(!unlockButton)
        {
            text = null;
            unlocked = true;
        }
        gameResources[0] = GameObject.Find("Energy").GetComponent<GameResource>();
        gameResources[1] = GameObject.Find("Wealth").GetComponent<GameResource>();
        gameResources[2] = GameObject.Find("Renewables").GetComponent<GameResource>();
        hiddenPlayer = GameObject.Find("HiddenPlayer").GetComponent<HiddenPlayer>();
        gainModifier = GetComponent<GainModifier>();
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
        hiddenPlayer.modifySatisfaction(satModifier);
        hiddenPlayer.modifyDiscontent(disModifier);
        hiddenPlayer.modifyNonRenew(-ResourceUse[0]);
        hiddenPlayer.modifyWealth(-ResourceUse[1]);
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
        int ctr = 0;
        while(i<gameResources.Count)
        {
            if(gameResources[i] == null)
            {
                return;
            }
            if ((gameResources[i].value - ResourceUse[i])<0 ||  pressed &&  gameObject.tag == "Research" || pressedOther || gameObject.tag == "Facility" && gainModifier.pressedButton)
            {
                available = false;
            }
            else if ((gameResources[i].value - ResourceUse[i]) >= 0 && !pressedOther)
            {
                ctr++;
            }
            i++;
        }
        if(ctr >= 3)
        {
            available = true;
        }
        
    }

}
