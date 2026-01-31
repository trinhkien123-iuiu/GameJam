using UnityEngine;

public class SoundProcess : MonoBehaviour
{
    public AudioManager audioProcess;

    [Header("Tick Objects")]
    public GameObject musicTick;
    public GameObject sfxTick;
    public GameObject checkBoxMusic;
    public GameObject checkBoxSfx;

    bool musicOn = true;

    void Start()
    {
        audioProcess.playMusic();
        audioProcess.playSFX();
    }

    void OnMouseDown()
    {

        musicOn = !musicOn;

        if (musicOn==true)
        {
            musicTick.SetActive(true);
            audioProcess.playMusic();
            
        }
        else
        {
            musicTick.SetActive(false);
            audioProcess.stopMusic();
        }
    }
}
