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
    public float discontentFactor = 100f;
    public float satisfactionFactor = -30f;
    public float satisfactionNeeded = 500f;

    public List<VictoryDefeatHandler> defeatHandlers = new List<VictoryDefeatHandler>();

    public VictoryDefeatHandler victoryHandler;
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
                    defeatHandlers[0].gameObject.SetActive(true);//You have exhausted the Earth's natural resources!
                    Time.timeScale = 0;
                    haveLost = true;
                    //return true;
                }
                if (gameResources[1].modifier <= 0 && hidden.wealth <= 0f)//bankrupt
                {
                    defeatHandlers[1].gameObject.SetActive(true);//Your Government has fallen to bankruptcy!
                    Time.timeScale = 0;
                    haveLost = true;
                   // return true;
                }
                if (gameResources[0].modifier <= 0 && gameResources[0].value <= 0 && gameResources[2].modifier <= 0 && gameResources[2].value <= 0)//no energy left and no way to make more
                {
                    defeatHandlers[2].gameObject.SetActive(true);//You have exhausted all your energy reserves!
                    Time.timeScale = 0;
                    haveLost = true;
                    //return true;
                }
                if (timeElapsed >= timer)//time has run out
                {
                    defeatHandlers[3].gameObject.SetActive(true);//Climate Change has doomed your civilization!
                    Time.timeScale = 0;
                    haveLost = true;
                   // return true;
                }
                if(hidden.satisfaction <=satisfactionFactor)
                {
                    defeatHandlers[4].gameObject.SetActive(true);//The people, unhappy with your policies, have voted you out!
                    Time.timeScale = 0;
                    haveLost = true;
                    //return true;
                }
                if(hidden.discontent >= discontentFactor)
                {
                    defeatHandlers[5].gameObject.SetActive(true);//The people, unhappy with your policies, have forced you out!
                    Time.timeScale = 0;
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
                                if (hiddenPlayer.satisfaction >= satisfactionNeeded)
                                {
                                    victoryHandler.gameObject.SetActive(true);
                                    Time.timeScale = 0;
                                    haveWon = true;
                                    return true;
                                }
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
