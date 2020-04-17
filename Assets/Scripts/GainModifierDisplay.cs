using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GainModifierDisplay : MonoBehaviour
{
    public GainModifier gainModifier;
    public Text text;
    void Awake()
    {
        gainModifier = GetComponentInParent<GainModifier>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Energy")
        {
            text.text = gainModifier.modifyBy[0].ToString();
        }
        else if (gameObject.tag == "Wealth")
        {
            text.text = gainModifier.modifyBy[1].ToString();
        }
        else if (gameObject.tag == "Novel")
        {
            text.text = gainModifier.modifyBy[2].ToString();
        }
    }
}
