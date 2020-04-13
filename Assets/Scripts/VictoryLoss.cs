using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryLoss : MonoBehaviour 
{
    public HiddenPlayer hiddenPlayer;
    public GameResource[] gameResources;
    //TO-DO- GameTime from Timer Script
    public float timer;
    public float timeElapsed =0;
    public bool haveLost = false;
    public bool haveWon = false;
    void Awake()
    {
        hiddenPlayer = gameObject.GetComponent<HiddenPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        haveLost = CheckForVictory(hiddenPlayer);
        haveWon = CheckForLoss(hiddenPlayer);
    }

    private bool CheckForLoss(HiddenPlayer hidden)//TO-DO- Execute Loss Consequence
    {
        if(!haveWon)
        {
            if(!haveLost)
            {
                if (hidden.nonRenew <= 0f || hidden.wealth <= 0f)//depleted hidden player
                {
                    print("Resources have run out");
                    return true;
                }
                if (gameResources[1].modifier <= 0 && gameResources[1].value <= 0)//bankrupt
                {
                    print("Bankrupt");
                    return true;
                }
                if (gameResources[0].modifier <= 0 && gameResources[0].value <= 0 && gameResources[2].modifier <= 0 && gameResources[2].value <= 0)//no energy left and no way to make more
                {
                    print("Societal Collapse");
                    return true;
                }
                if (timeElapsed >= timer)//time has run out
                {
                    print("Hurricane");
                    return true;
                }
                if(hidden.satisfaction <=0f)
                {
                    print("Voted Out!");
                    return true;
                }
                if(hidden.discontent >= 1000f)
                {
                    print("Rebellion!");
                    return true;
                }
            }
            
        }

        return false;
    }

    private bool CheckForVictory(HiddenPlayer hidden)
    {
        if(!haveLost)
        {
            if (timeElapsed < timer)//time has not run out
            {
                if (!haveWon)
                {
                    if (hidden.nonRenew > 0f && hidden.wealth > 0f)//hidden player should not be depleted
                    {
                        if (gameResources[2].modifier > 10 && gameResources[2].value > 1000)// renewable and sustainable
                        {
                            if (gameResources[0].modifier < 0)//no non-renewables being mined
                            {
                                print("Victory!");
                                return true;
                                //TO-DO- Execute Victory Consequence
                            }
                        }
                    }
                }
            }
        }
        return false;
    }
}
