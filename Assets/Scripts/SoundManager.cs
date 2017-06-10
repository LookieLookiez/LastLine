using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public bool gameEnding;

    public GameObject battleAudio;
    public GameObject russianMenu;
    public GameObject engineLoop;
    public AudioClip bombExplosion;
    public AudioClip shellExplosion;
    public AudioClip fireTank;
    public AudioClip reload;
    public AudioClip gameBegin;
    public AudioClip gameEnd;
    public AudioClip mouseOver;
    public AudioClip MouseClick;
    public AudioClip germanMarch;
    public bool needToFade = false;

    public float fadeTime;
    public float fadeTime2;



    void Start () {
        gameEnding = false;
    }

    void Update()
    {
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
    }

    void PlayBombExplosion()
    {

    }

    void PlayShellExplosion()
    {

    }

    void PlayFireTank()
    {

    }

    void PlayReload()
    {

    }

    void PlayGameBegin()
    {

    }

    void PlayGameEnd()
    {

    }

    void PlayMouseOver()
    {

    }

    void PlayMouseClick()
    {

    }

    void PlayGermanMarch()
    {

    }

    void PlayMenuMusic()
    {
        russianMenu.GetComponent<AudioSource>().Play();
    }

    void StopMenuMusic()
    {
        russianMenu.GetComponent<AudioSource>().Stop();
    }

    void PlayBattleBG()
    {
        battleAudio.GetComponent<AudioSource>().Play();
    }

    void FadeBattleBG()
    {
        battleAudio.GetComponent<AudioSource>().volume = Mathf.Lerp(battleAudio.GetComponent<AudioSource>().volume, 0,Time.deltaTime);
    }

    void StopBattleBG()
    {
        battleAudio.GetComponent<AudioSource>().Stop();
    }

    void StartEngineLoop()
    {
        engineLoop.GetComponent<AudioSource>().Play();
    }

    void StopEngineLoop()
    {
        engineLoop.GetComponent<AudioSource>().Play();
    }
}
