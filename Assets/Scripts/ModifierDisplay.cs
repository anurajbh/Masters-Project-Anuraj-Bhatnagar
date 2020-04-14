using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifierDisplay : MonoBehaviour
{
    public GameResource gameResource;
    public Text text;
    void Awake()
    {
        gameResource = GetComponentInParent<GameResource>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = gameResource.modifier.ToString();
    }
}
