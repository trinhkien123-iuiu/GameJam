// using UnityEngine;

// public class SoundProcess : MonoBehaviour
// {
//     public AudioManager audioProcess;

//     [Header("Tick Objects (đỏ)")]
//     public GameObject musicTick;
//     public GameObject sfxTick;

//     private static bool musicOn = true;
//     private static bool sfxOn = true;

//     void Start()
//     {
//         ApplyUI();

//         ApplyAudio();
//     }

//     public void ToggleMusic()
//     {
//         musicOn = !musicOn;
//         ApplyUI();
//         ApplyAudio();
//     }

//     public void ToggleSfx()
//     {
//         sfxOn = !sfxOn;
//         ApplyUI();
//         ApplyAudio();
//     }

//     private void ApplyUI()
//     {
//         if (musicTick != null) musicTick.SetActive(musicOn);
//         if (sfxTick != null) sfxTick.SetActive(sfxOn);
//     }

//     private void ApplyAudio()
//     {
//         if (audioProcess == null) return;

//         if (musicOn) audioProcess.playMusic();
//         else audioProcess.stopMusic();

//         if (audioProcess.sfxSource != null)
//         {
//             audioProcess.sfxSource.mute = !sfxOn;

//             if (!sfxOn) audioProcess.sfxSource.Stop();
//         }
//     }
// }
using UnityEngine;

public class SoundProcess : MonoBehaviour
{
    public AudioManager audioProcess;

    [Header("Tick Objects")]
    public GameObject musicTick;
    public GameObject sfxTick;

    void Start()
    {
        Refresh();
    }

    void OnEnable()
    {
        Refresh();
    }

    public void ToggleMusic()
    {
        SoundSettings.MusicOn = !SoundSettings.MusicOn;
        Refresh();
    }

    public void ToggleSfx()
    {
        SoundSettings.SfxOn = !SoundSettings.SfxOn;
        Refresh();
    }

    void Refresh()
    {
        // UI
        if (musicTick) musicTick.SetActive(SoundSettings.MusicOn);
        if (sfxTick) sfxTick.SetActive(SoundSettings.SfxOn);

        if (!audioProcess) return;

        // Music
        if (SoundSettings.MusicOn)
            audioProcess.playMusic();
        else
            audioProcess.stopMusic();

        // SFX
        if (audioProcess.sfxSource)
        {
            audioProcess.sfxSource.mute = !SoundSettings.SfxOn;
            if (!SoundSettings.SfxOn)
                audioProcess.sfxSource.Stop();
        }
    }
}
