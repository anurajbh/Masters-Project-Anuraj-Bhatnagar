using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GainModifierDisplay : MonoBehaviour
{
    public GainModifier gainModifier;
    public Text text;
    public Text sign;
    void Awake()
    {
        gainModifier = GetComponentInParent<GainModifier>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayValueOfModifier();
    }

    private void DisplayValueOfModifier()
    {
        if (gameObject.tag == "Energy")
        {
            text.text = gainModifier.modifyBy[0].ToString();
            DisplaySign(gainModifier.modifyBy[0]);
        }
        else if (gameObject.tag == "Wealth")
        {
            text.text = gainModifier.modifyBy[1].ToString();
            DisplaySign(gainModifier.modifyBy[1]);
        }
        else if (gameObject.tag == "Novel")
        {
            text.text = gainModifier.modifyBy[2].ToString();
            DisplaySign(gainModifier.modifyBy[2]);
        }
    }
    private void DisplaySign(float value)
    {
        if(value>0)
        {
            sign.text = "+";
        }
    }
}
