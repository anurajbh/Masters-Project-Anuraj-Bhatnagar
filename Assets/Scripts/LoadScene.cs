using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public int sceneIndex;
    Scene scene;
    Button button;
    void Awake()
    {
        scene = SceneManager.GetActiveScene();
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadTheScene);
    }
    void LoadTheScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
