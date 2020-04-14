using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResource : MonoBehaviour
{
    public float value;

    public float modifier;
    public float timePeriod;
    public float timer;
    void Start()
    {
        value = 0f;
        modifier = 1f;
        timePeriod = 2f;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timePeriod)
        {
            value += modifier;
            timer = 0f;
        }

    }
}
