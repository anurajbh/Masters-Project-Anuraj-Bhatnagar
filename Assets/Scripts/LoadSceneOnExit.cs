using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnExit : MonoBehaviour
{
    public string sceneName;
    float timeElapsed;
    public int timer;
    [SerializeField] int seconds;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Cancel") != 0)
        {
            SceneManager.LoadScene(sceneName);
        }
        timeElapsed += Time.deltaTime;
        seconds = (int)timeElapsed % 60;
        //force a scene load of main menu on end credits
        if (seconds >= timer)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    private void Awake()
    {
        timeElapsed = 0;
        seconds = 0;
    }
}
