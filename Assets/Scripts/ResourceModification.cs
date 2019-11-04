using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceModification : MonoBehaviour
{
    public GameResource res;
    public float use = 2f;
    public Button button;
    //to-do: Add other ways for Resource values to change
    void Start()
    {
        button.onClick.AddListener(ResourceUsage);
    }

    private void ResourceUsage()
    {
        res.value /= use;
    }

    // Update is called once per frame
    /*private void Update()
    {
        
    }*/
}
