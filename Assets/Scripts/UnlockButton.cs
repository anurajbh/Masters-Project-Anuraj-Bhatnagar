using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockButton : MonoBehaviour
{
    public bool unlock = false;
    Button button;
    void Awake()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(UnlockTheButton);
    }

    private void UnlockTheButton()
    {
        unlock = true;
  
    }
}
