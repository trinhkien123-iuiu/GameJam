using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public SoundProcess soundPro;

    [SerializeField] GameObject pauseMenu;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    //public void Home()
    //{
    //    Time.timeScale = 1;
    //    pauseMenu.SetActive(false);
    //    SceneManager.LoadScene("MainMenu");
    //}
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Home()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

        AudioResetHelper.RestartBgmFromBeginning();
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

        AudioResetHelper.RestartBgmFromBeginning();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
