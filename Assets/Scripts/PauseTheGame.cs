using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseTheGame : MonoBehaviour
{
    public GameObject panel;

    public Button pauseButton;

    public Button playButton;

    public Button restartButton;

    public Button exitButton;

    public Button mainMenuButton;
    private bool paused = false;

    void Awake()
    {
        pauseButton.onClick.AddListener(PauseGame);
        playButton.onClick.AddListener(Unpause);
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);
        mainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    private void LoadMainMenu()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetSceneAt(0);
        SceneManager.LoadScene(0);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void RestartGame()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
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
        Time.timeScale = 1;
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
