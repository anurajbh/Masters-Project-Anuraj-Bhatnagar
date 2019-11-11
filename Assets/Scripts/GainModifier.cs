using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GainModifier : MonoBehaviour
{
    public Button button;
    public List<GameResource> gameResources;
    public float WealthModifyBy = 2f;
    public float EnergyModifyBy = 2f;
    void Start()
    {
        button.onClick.AddListener(ModifyResourceGain);
    }

    private void ModifyResourceGain()
    {
        gameResources[0].modifier *= WealthModifyBy;
        gameResources[1].modifier *= EnergyModifyBy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
