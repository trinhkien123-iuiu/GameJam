using UnityEngine;

public static class AudioResetHelper
{
    public static void RestartBgmFromBeginning()
    {
        var am = Object.FindFirstObjectByType<AudioManager>();
        if (am == null || am.musicSource == null) return;

        am.musicSource.Stop();
        am.musicSource.time = 0f;   
        am.musicSource.Play();       
    }
}
