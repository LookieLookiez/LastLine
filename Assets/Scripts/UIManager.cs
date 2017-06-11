using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool gameEnding;
    public bool fadeOut;
    public bool pause;
    public GameObject gameCore;
    public GameObject soundManager;
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public Transform onScreen;
    public Transform offScreen;

    public GameObject shell;
    public GameObject shellBG;
    public GameObject soldier;
    public GameObject soldierBG;

    public Image fade;
    public bool alreadyRan = false;



    // Use this for initialization
    void Start()
    {
        gameCore.SetActive(false);
        shell.SetActive(false);
        shellBG.SetActive(false);
        soldier.SetActive(false);
        soldierBG.SetActive(false);
        soundManager.SendMessage("PlayMenuMusic");
        fadeOut = false;
        pause = false;
    }

    public void Play()
    {
        if(alreadyRan) // HACK for Bug in which this re-enters a number of times
        {
            return;
        }
        Debug.Log("Ran Play from UI");
        gameCore.SetActive(true);
        mainMenu.transform.position = offScreen.transform.position;
        shell.SetActive(true);
        shellBG.SetActive(true);
        soldier.SetActive(true);
        soldierBG.SetActive(true);
        soundManager.GetComponent<SoundManager>().needToFade = true;
        soundManager.SendMessage("PlayBattleBG");
        soundManager.SendMessage("StartEngineLoop");
        fade.enabled = true;
        StartCoroutine(FadeTo(0.0f, 5f));
        alreadyRan = true;
    }

    public void Options()
    {

    }

    public void Quit()
    {

    }

    public void Restart()
    {

    }

    public void Credits()
    {

    }

    public void Pause()
    {
        if(!pause)
        {
            pauseMenu.transform.position = onScreen.transform.position;
            pause = true;
            soundManager.GetComponent<SoundManager>().pause = true;
        }
        else
        {
            pauseMenu.transform.position = offScreen.transform.position;
            pause = false;
            soundManager.GetComponent<SoundManager>().pause = false;
        }

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
    }


    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = fade.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha, aValue, t));
            fade.color = newColor;
            yield return null;
        }
    }

    void Update()
    {
        if(gameEnding && !fadeOut)
        {
            StartCoroutine(FadeTo(1f, 10f));
            fadeOut = true;
        }
    }

    void OnMouseOver()
    {
        soundManager.SendMessage("PlayMouseOver");
    }


}



