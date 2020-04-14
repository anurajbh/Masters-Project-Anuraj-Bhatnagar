using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float nonRenew = 1000f;
    public float wealth = 1000f;
    public float satisfaction = 1000f;
    public float discontent = 0f;
    public GameResource CityWealth;
    public GameResource extractNonRenew;
    public float timePeriod;
    public float timer;
    public float naturalGain =3f;
    public void modifyNonRenew(float stat)
    {
        nonRenew += stat;
    }
    public void modifyWealth(float stat)
    {
        wealth += stat;
    }
    public void modifySatisfaction(float stat)
    {
        satisfaction += stat;
    }
    public void modifyDiscontent(float stat)
    {
        discontent += stat;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timePeriod)
        {
            modifyWealth(CityWealth.modifier);
            modifyNonRenew(naturalGain - extractNonRenew.modifier);
            timer = 0f;
        }
    }
}
