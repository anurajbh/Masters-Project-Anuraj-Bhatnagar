using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResourceDisplay : MonoBehaviour
{
    Text text;
    GameResource gameResource;
    void Awake()
    {
        text = gameObject.GetComponent<Text>();
        gameResource = gameObject.GetComponentInParent<GameResource>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateResource();
    }

    private void UpdateResource()
    {
        text.text = gameResource.value.ToString();
    }
}
