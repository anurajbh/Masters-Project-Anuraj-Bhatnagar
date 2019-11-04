using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResource : MonoBehaviour
{
    public string name;//to-do: Make use of Resource names
    public float value;
    public float gain;
    public float modifier;
    public float timePeriod;
    public float timer;
    void Start()
    {
        value = 0f;
        gain = 1f;
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
            value += (gain * modifier);
            timer = 0f;
        }
        print(value);
    }
}
