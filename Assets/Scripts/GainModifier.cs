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
    void Start()
    {
        button.onClick.AddListener(ModifyResourceGain);
    }

    private void ModifyResourceGain()
    {
        int i = 0;
        while(i<=gameResources.Count)
        {
            gameResources[i].modifier += modifyBy[i];
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
