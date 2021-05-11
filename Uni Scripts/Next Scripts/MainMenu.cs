using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject title, options, credits, control, controlMenuBeforePlay, canvas, playText, optionsText, creditsText, quitText;
    public AnimationClip fadeIn, spin;
    public Animation[] textFadeIn, bitch;
    public Image playRing, optionsRing, creditsRing, quitRing;

    // makes cursor useable after being in game
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        foreach (Animation FadeIn in textFadeIn)
        {
            FadeIn.Play();
        }

        bitch = canvas.GetComponentsInChildren<Animation>();
        foreach (Animation child in bitch)
        {
            if (child.CompareTag("Ring"))
            {
                child.clip = fadeIn;
                child.Play();
            }
        }

        /*foreach (Animation FadeIn in spinningCircle)
        {
            FadeIn.Play();
        }*/
    }
    // Play the game 
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // open the options menu
    public void OptionsMenu()
    {
        title.SetActive(false);
        options.SetActive(true);
    }

    // close options menu
    public void CloseOptions()
    {
        title.SetActive(true);
        options.SetActive(false);
        
        foreach (Animation child in bitch)
        {
            if (child.CompareTag("Ring"))
            {
                child.clip = spin;
                child.Play();
            }
        }

        playText.GetComponent<TMP_Text>().alpha = 255;
        optionsText.GetComponent<TMP_Text>().alpha = 255;
        quitText.GetComponent<TMP_Text>().alpha = 255;
        creditsText.GetComponent<TMP_Text>().alpha = 255;
        playRing.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        optionsRing.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        quitRing.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        creditsRing.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    // open controls menu
    public void ControlMenu()
    {
        control.SetActive(true);
        options.SetActive(false);
    }

    // close controls menu
    public void CloseControl()
    {
        options.SetActive(true);
        control.SetActive(false);
    }

    // close credits menu
    public void CloseCredits()
    {
        title.SetActive(true);
        credits.SetActive(false);

        foreach (Animation child in bitch)
        {
            if (child.CompareTag("Ring"))
            {
                child.clip = spin;
                child.Play();
            }
        }

        playText.GetComponent<TMP_Text>().alpha = 255;
        optionsText.GetComponent<TMP_Text>().alpha = 255;
        quitText.GetComponent<TMP_Text>().alpha = 255;
        creditsText.GetComponent<TMP_Text>().alpha = 255;
        playRing.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        optionsRing.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        quitRing.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        creditsRing.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    // open credits menu
    public void CreditsMenu()
    {
        title.SetActive(false);
        credits.SetActive(true);
    }

    public void ControlMenuBeforePlay()
    {
        title.SetActive(false);
        controlMenuBeforePlay.SetActive(true);
    }

    // quit the game
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
