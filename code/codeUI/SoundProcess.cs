using UnityEngine;

public class SoundProcess : MonoBehaviour
{
    public GameObject musicTick;
    public GameObject sfxTick;

    AudioManager am;

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

    public void Refresh()
    {
        if (musicTick) musicTick.SetActive(SoundSettings.MusicOn);
        if (sfxTick) sfxTick.SetActive(SoundSettings.SfxOn);

        am = FindFirstObjectByType<AudioManager>();
        if (!am) return;

        // Music
        if (SoundSettings.MusicOn) am.playMusic();
        else am.stopMusic();

        // SFX (mute trực tiếp)
        if (am.sfxSource)
        {
            am.sfxSource.mute = !SoundSettings.SfxOn;
            if (!SoundSettings.SfxOn) am.sfxSource.Stop();
        }
    }
}
