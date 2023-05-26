using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    private bool isPaused = false;

    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }




    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SoundManager.Instance.PlayMenuMusic();
    }

   public void Pause()
   {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        SoundManager.Instance.StopMusic();
   }

    public void MainMenu()
    {
        SceneController.Instance.LoadScene("Main Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }


    #region Button Sounds

    public void PlayButtonHover()
    {
        SoundManager.Instance.PlayButtonHover();
    }

    public void PlayButtonSelect()
    {
        SoundManager.Instance.PlayButtonSelect();
    }

    public void PlayButtonBack()
    {
        SoundManager.Instance.PlayButtonBack();
    }

    #endregion


}
