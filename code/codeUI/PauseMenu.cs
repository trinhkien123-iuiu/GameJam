using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        var am = FindFirstObjectByType<AudioManager>();
        if (am != null && am.musicSource != null) am.musicSource.Pause();  
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        var am = FindFirstObjectByType<AudioManager>();
        if (am != null && am.musicSource != null) am.musicSource.UnPause(); 
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
