﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundManager : MonoBehaviour
{
    public bool pause;
    public bool gameEnding;
    public float volume;
    public AudioSource aud;
    public GameObject battleAudio;
    public GameObject russianMenu;
    public GameObject engineLoop;
    public AudioClip airRaid;
    public AudioClip bombExplosion;
    public AudioClip fireTank;
    public AudioClip reload;
    public AudioClip mouseOver;
    public AudioClip mouseClick;
    public AudioClip germanMarch;
    public bool needToFade = false;
    public float fadeTime;
    public float fadeTime2;
    public bool playing = false;

    //Initialization
    void Start () {
        gameEnding = false;
        aud = GetComponent<AudioSource>();
        pause = false;
    }

    void Update()
    {
        //Start credits music
        if(gameEnding && !playing)
        {
            Invoke("PlayGermanMarch", 8);
            playing = true;
        }
        //Fade the audio
        if(needToFade)
        {
            fadeTime -= Time.deltaTime;
            russianMenu.GetComponent<AudioSource>().volume = fadeTime;
            if(fadeTime2 <1)
            {
                fadeTime2 += Time.deltaTime;
                engineLoop.GetComponent<AudioSource>().volume = fadeTime2;
            }
        }

        //What happens to audio if paused
        if(pause)
        {
            engineLoop.GetComponent<AudioSource>().Pause();
            battleAudio.GetComponent<AudioSource>().Pause();
            battleAudio.GetComponent<AudioSource>().Pause();
            aud.Pause();
        }
        else
        {
            engineLoop.GetComponent<AudioSource>().UnPause();
            battleAudio.GetComponent<AudioSource>().UnPause();
            battleAudio.GetComponent<AudioSource>().UnPause();
            aud.UnPause();
        }
    }

    public void PlayBombExplosion()
    {
        aud.PlayOneShot(bombExplosion, 1f);
    }

    public void PlayFireTank()
    {

    }

    public void PlayReload()
    {
        aud.PlayOneShot(reload, 1f);
    }

    public void PlayMouseOver()
    {
        aud.PlayOneShot(mouseOver, 5f);
    }

    public void PlayMouseClick()
    {
        aud.PlayOneShot(mouseClick, 5f);
    }

    public void PlayGermanMarch()
    {
        aud.PlayOneShot(germanMarch, 1);
    }

    public void PlayMenuMusic()
    {
        russianMenu.GetComponent<AudioSource>().Play();
    }

    public void StopMenuMusic()
    {
        russianMenu.GetComponent<AudioSource>().Stop();
    }

    public void PlayBattleBG()
    {
        battleAudio.GetComponent<AudioSource>().Play();
    }

    public void FadeBattleBG()
    {
        battleAudio.GetComponent<AudioSource>().volume = Mathf.Lerp(battleAudio.GetComponent<AudioSource>().volume, 0,Time.deltaTime);
    }

    public void StopBattleBG()
    {
        battleAudio.GetComponent<AudioSource>().Stop();
    }

    public void StartEngineLoop()
    {
        engineLoop.GetComponent<AudioSource>().Play();
    }

    public void StopEngineLoop()
    {
        engineLoop.GetComponent<AudioSource>().Stop();
    }

    public void StartAirRaid()
    {
        aud.PlayOneShot(airRaid, 1);
    }
}
