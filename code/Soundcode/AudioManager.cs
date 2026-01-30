using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip backgroundMusic;
    public AudioClip fire, water, earth, air, lava, wood;
    public AudioClip eFire, eWater, eEarth, explode;
    public AudioClip move;
    public AudioClip buttonClick, gameOver, win;
    public AudioClip maskCollect, enemyDeath;
    public AudioClip enemyDamage, playerDamage;
    void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void stopMusic()
    {
        musicSource.Stop();
    }

    public void playMusic()
    {
        musicSource.Play();
    }

    public void stopSFX()
    {
        sfxSource.Stop();
    }

    public void playSFX()
    {
        sfxSource.Play();
    }

    public void moveAudio()
    {
        sfxSource.clip = move;
        sfxSource.Play();
    }

    public void fireAudio()
    {
        sfxSource.clip = fire;
        sfxSource.Play();
    }

    public void waterAudio()
    {
        sfxSource.clip = water;
        sfxSource.Play();
    }

    public void earthAudio()
    {
        sfxSource.clip = earth;
        sfxSource.Play();
    }

    public void airAudio()
    {
        sfxSource.clip = air;
        sfxSource.Play();
    }

    public void lavaAudio()
    {
        sfxSource.clip = lava;
        sfxSource.Play();
    }

    public void woodAudio()
    {
        sfxSource.clip = wood;
        sfxSource.Play();
    }

    public void eFireAudio()
    {
        sfxSource.clip = eFire;
        sfxSource.Play();
    }

    public void eWaterAudio()
    {
        sfxSource.clip = eWater;
        sfxSource.Play();
    }

    public void eEarthAudio()
    {
        sfxSource.clip = eEarth;
        sfxSource.Play();
    }

    public void explodeAudio()
    {
        sfxSource.clip = explode;
        sfxSource.Play();
    }

    public void buttonClickAudio()
    {
        sfxSource.clip = buttonClick;
        sfxSource.Play();
    }

    public void gameOverAudio()
    {
        sfxSource.clip = gameOver;
        sfxSource.Play();
    }

    public void winAudio()
    {
        sfxSource.clip = win;
        sfxSource.Play();
    }

    public void maskCollectAudio()
    {
        sfxSource.clip = maskCollect;
        sfxSource.Play();
    }

    public void enemyDeathAudio()
    {
        sfxSource.clip = enemyDeath;
        sfxSource.Play();
    }

    public void enemyDamageAudio()
    {
        sfxSource.clip = enemyDamage;
        sfxSource.Play();
    }

    public void playerDamageAudio()
    {
        sfxSource.clip = playerDamage;
        sfxSource.Play();
    }

}
