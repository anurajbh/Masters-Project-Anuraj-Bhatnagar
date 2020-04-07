using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GainModifier : MonoBehaviour
{
    public Button button;
    public List<GameResource> gameResources;
    public List<float> modifyBy;
    ResearchTimer researchTimer;
    public bool pressedButton = false;
    void Awake()
    {
        researchTimer = gameObject.GetComponent<ResearchTimer>();
        gameResources[0] = GameObject.Find("Energy").GetComponent<GameResource>();
        gameResources[1] = GameObject.Find("Wealth").GetComponent<GameResource>();
        gameResources[2] = GameObject.Find("Renewables").GetComponent<GameResource>();
        button.onClick.AddListener(ButtonPress);
    }
    void ButtonPress()
    {
        pressedButton = true;
    }
    private void ImplementPolicy()
    {
        researchTimer.timer += Time.deltaTime;
        if(researchTimer.timer>=researchTimer.timeToResearch)
        {
            ModifyResourceGain();
            pressedButton = false;
        }
    }

    private void ModifyResourceGain()
    {
        int i = 0;
        while(i<gameResources.Count)
        {
            gameResources[i].modifier += modifyBy[i];
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(pressedButton)
        {
            ImplementPolicy();
        }
    }
}
