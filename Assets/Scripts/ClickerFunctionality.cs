using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerFunctionality : MonoBehaviour
{
    Button butt;
    public GameObject newButt;//what happens when button is pressed
    private void Awake()
    {
        butt = GetComponent<Button>();
    }
    private void Update()
    {
        ClickButton(butt);
    }

    private void ClickButton(Button butt)
    {
        butt.onClick.AddListener(CreateNewNode);
    }

    private void CreateNewNode()
    {
        GameObject butto = (GameObject)Instantiate(newButt);
        butto.SetActive(true);
        butto.transform.SetParent(gameObject.transform);//Setting button parent
        butto.GetComponent<Button>().onClick.AddListener(CreateNewPolicy);//Setting what button does when clicked
                                                                   //Next line assumes button has child with text as first gameobject like button created from GameObject->UI->Button
        butto.transform.GetChild(0).GetComponent<Text>().text = "I am a Policy";//Changing text

    }

    private void CreateNewPolicy()
    {
        GameObject butto = (GameObject)Instantiate(newButt);
        butto.SetActive(true);
        butto.transform.SetParent(gameObject.transform);//Setting button parent
        butto.GetComponent<Button>().onClick.AddListener(CreateNewPolicy);//Setting what button does when clicked
                                                                          //Next line assumes button has child with text as first gameobject like button created from GameObject->UI->Button
        butto.transform.GetChild(0).GetComponent<Text>().text = "I am a Policy";//Changing text
    }
}
