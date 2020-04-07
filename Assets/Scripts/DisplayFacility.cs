using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFacility : MonoBehaviour
{
    Facility facility;
    Text text;
    void Start()
    {
        facility = gameObject.GetComponentInParent<Facility>();
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCount();
    }
    void DisplayCount()
    {
        text.text = facility.facilityNumber.ToString();
    }
}
