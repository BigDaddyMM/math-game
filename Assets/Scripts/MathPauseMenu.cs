using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MathPauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ClassroomScene");
    }
    
    public void Levels()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameModeSelect");
    }
}
