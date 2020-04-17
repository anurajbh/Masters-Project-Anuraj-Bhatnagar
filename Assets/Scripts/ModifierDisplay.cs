using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifierDisplay : MonoBehaviour
{
    public GameResource gameResource;
    public Text text;
    public Text sign;
    void Awake()
    {
        gameResource = GetComponentInParent<GameResource>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = gameResource.modifier.ToString();
        DisplaySign(gameResource.modifier);
    }
    private void DisplaySign(float value)
    {
        if (value > 0)
        {
            sign.text = "+";
        }
    }
}
