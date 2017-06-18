using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public bool gameEnding;
    public bool fadeOut;
    public bool pause;
    public GameObject gameCore;
    public GameObject soundManager;
    public Text credits;
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public Transform onScreen;
    public Transform offScreen;
    public GameObject shell;
    public GameObject shellBG;
    public GameObject soldier;
    public GameObject soldierBG;
    public float creditSpeed;
    public Image fade; //An image that covers the screen
    public bool alreadyRan = false;
    public bool playing = false;

    //Initialization
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
        //Make sure menus are controllable when needed
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void Play()
    {
        if(alreadyRan) // HACK for Bug in which this re-enters a number of times
        {
            return;
        }
        //Set initial state after menus
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
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    //Control of the options overlay
    public void Options()
    {
        optionsMenu.transform.position = onScreen.transform.position;
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }
    //Go back
    public void Back()
    {
        optionsMenu.transform.position = offScreen.transform.position;
        optionsMenu.SetActive(false);
        mainMenu.transform.position = onScreen.transform.position;
        mainMenu.SetActive(true);
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    //Pause menu
    public void Pause()
    {
        //Pingpong the menus
        if(!pause)
        {
            pauseMenu.transform.position = onScreen.transform.position;
            pause = true;
            soundManager.GetComponent<SoundManager>().pause = true;
            mainMenu.SetActive(false);
            optionsMenu.SetActive(false);
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.transform.position = offScreen.transform.position;
            pause = false;
            soundManager.GetComponent<SoundManager>().pause = false;
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(false);
            mainMenu.SetActive(false);
        }
        //Make sure game doesnt continue while in menus
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }        
    }
    //Fade for the fade image, on begin and on end
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
        //Start the credits if the game is over
        if (gameEnding)
        {
            credits.transform.Translate(Vector3.up * creditSpeed * Time.deltaTime);
            playing = true;
            shell.SetActive(false);
            shellBG.SetActive(false);
            soldier.SetActive(false);
            soldierBG.SetActive(false);
}
        //Initiate fade, dont repeat
        if (gameEnding && !fadeOut)
        {
            StartCoroutine(FadeTo(1f, 10f));
            fadeOut = true;
            Invoke("Restart", 140);
        }
    }

    void OnMouseOver()
    {
        soundManager.SendMessage("PlayMouseOver");
    }



}



