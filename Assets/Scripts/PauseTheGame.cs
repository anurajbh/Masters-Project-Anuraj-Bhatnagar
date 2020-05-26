using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseTheGame : MonoBehaviour
{
    public GameObject panel;

    public Button pauseButton;

    public Button playButton;
    private bool paused = false;
    float timeCurrent;

    void Awake()
    {
        timeCurrent = Time.timeScale;
        pauseButton.onClick.AddListener(PauseGame);
        playButton.onClick.AddListener(Unpause);
    }
    void PauseGame()
    {
        paused = true;
        
    }

    private void StopPlay()
    {
        //timeCurrent = Time.timeScale;
        Time.timeScale = 0;
        panel.SetActive(true);
        pauseButton.interactable = false;
    }

    void Unpause()
    {
        paused = false;
    }

    private void ResumePlay()
    {
        Time.timeScale = timeCurrent;
        panel.SetActive(false);
        pauseButton.interactable = true;
    }

    private void Update()
    {
        if(paused)
        {
            StopPlay();
        }
        else if(!paused)
        {
            ResumePlay();
        }
    }
}
