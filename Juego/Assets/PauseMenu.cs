using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;
    public GameObject pauseMenu;

    void Start()
    {
        pauseMenu.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    public void pauseGame()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
