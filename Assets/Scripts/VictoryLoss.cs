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
        gameResources[0] = GameObject.Find("Energy").GetComponent<GameResource>();
        gameResources[1] = GameObject.Find("Wealth").GetComponent<GameResource>();
        gameResources[2] = GameObject.Find("Renewables").GetComponent<GameResource>();
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
                if (hidden.nonRenew <= 0f && gameResources[0].modifier >0f)//depleted hidden player
                {
                    print("You have exhausted your natural resources");
                    haveLost = true;
                    //return true;
                }
                if (gameResources[1].modifier <= 0 && hidden.wealth <= 0f)//bankrupt
                {
                    print("Bankrupt");
                    haveLost = true;
                   // return true;
                }
                if (gameResources[0].modifier <= 0 && gameResources[0].value <= 0 && gameResources[2].modifier <= 0 && gameResources[2].value <= 0)//no energy left and no way to make more
                {
                    print("Societal Collapse");
                    haveLost = true;
                    //return true;
                }
                if (timeElapsed >= timer)//time has run out
                {
                    print("Climate Apocalypse");
                    haveLost = true;
                   // return true;
                }
                if(hidden.satisfaction <=0f)
                {
                    print("Voted Out!");
                    haveLost = true;
                    //return true;
                }
                if(hidden.discontent >= 1000f)
                {
                    print("Rebellion!");
                    haveLost = true;
                   // return true;
                }
            }
            if (haveLost)
            {
                return true;
            }
        }
        return false;
        
    }

    private bool CheckForVictory(HiddenPlayer hidden)
    {
        if(!haveLost)
        {
            if (timeElapsed <= timer)//time has not run out
            {
                if (!haveWon)
                {
                    if (hidden.nonRenew > 0f && hidden.wealth > 0f)//hidden player should not be depleted
                    {
                        if (gameResources[2].modifier >= 10 && gameResources[2].value >= 1000)// renewable and sustainable
                        {
                            if (gameResources[0].modifier <= 0)//no non-renewables being mined
                            {
                                print("Victory!");
                                haveWon = true;
                                return true;
                                //TO-DO- Execute Victory Consequence
                            }
                        }
                    }
                }
                if (haveWon)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
