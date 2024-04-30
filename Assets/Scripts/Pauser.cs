using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    private bool isPaused = false;
    private float previousTimeScale;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject audioSettings;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!isPaused);
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (audioSettings)
        {
            audioSettings.SetActive(false);
        }
    }
}
