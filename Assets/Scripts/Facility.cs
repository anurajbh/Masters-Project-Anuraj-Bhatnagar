using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Facility : MonoBehaviour
{
    Button button;
    public int facilityNumber = 0;
    void Awake()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(IncrementFacilityNumber);
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void IncrementFacilityNumber()
    {
        facilityNumber++;
    }
}
