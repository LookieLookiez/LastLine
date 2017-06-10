using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool gameEnding;
    public bool fadeOut;

    public GameObject gameCore;
    public GameObject soundManager;
    public GameObject mainMenu;
    public Transform onScreen;
    public Transform offScreen;

    public GameObject shell;
    public GameObject shellBG;
    public GameObject soldier;
    public GameObject soldierBG;

    public Image fade;



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

    }

    public void Play()
    {
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
        mainMenu.transform.position = onScreen.transform.position;
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
            StartCoroutine(FadeTo(1f, 5f));
            fadeOut = true;
        }
    }


}



