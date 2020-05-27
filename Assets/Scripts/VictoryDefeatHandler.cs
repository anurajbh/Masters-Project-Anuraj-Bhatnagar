using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryDefeatHandler : MonoBehaviour
{

    public Button restartButton;

    public Button exitButton;

    public Button mainMenuButton;

    private void Awake()
    {
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
}
