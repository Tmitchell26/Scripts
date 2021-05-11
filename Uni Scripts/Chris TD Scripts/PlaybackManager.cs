using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MilkShake;
using Fungus;


public class PlaybackManager : MonoBehaviour
{
    public Dropdown fireFaceDropdown;
    private bool dropdownBool = false;

    public Toggle protoolsApp;
    private bool appOpened = false;

    public Button setupButton, playbackEngineButton, okButton;
    private bool setupButtonBool = false, playbackEngineButtonBool = false, okButtonBool = false;

    public Toggle ptToggle, setupToggle, PbEToggle, fireFaceToggle, okToggle;

    private int lastButtonOn;
    public int correctButton = 0;

    public int score;
    public bool updateScore;
    public TextMeshProUGUI scoreText;

    public ShakePreset shakePreset;

    public GameObject[] menus;

    public Flowchart proT;

    #region Buttons

    public void AppOpen(bool open)
    {
        if(open && !appOpened)
        {
            Debug.Log("protools app was opened");
            appOpened = true;
            ptToggle.isOn = appOpened;
            lastButtonOn = 0;
            CheckButtonOrder();
        }
    }

    public void SetupButton()
    {
        Debug.Log("Setup dropdown was opened");
        if (!setupButtonBool)
        {
            lastButtonOn = 1;
            CheckButtonOrder();
            setupButtonBool = true;
            setupToggle.isOn = true;
        }
    }

    public void PlaybackEngineButton()
    {
        Debug.Log("PbE settings was opened");
        if (!playbackEngineButtonBool)
        {
            lastButtonOn = 2;
            CheckButtonOrder();
            playbackEngineButtonBool = true;
            PbEToggle.isOn = true;
        }
    }

    public void DropdownButton()
    {
        if(fireFaceDropdown.value == 1)
        {
            Debug.Log("dropdown was changed to fireface");
            if (!dropdownBool)
            {
                lastButtonOn = 3;
                CheckButtonOrder();
                dropdownBool = true;
                fireFaceToggle.isOn = true;
                if(proT != null) proT.ExecuteBlock("ok button");
                
            }
        }
    }

    public void OKButton()
    {
        Debug.Log("ok button was clicked");
        if (!okButtonBool)
        {
            lastButtonOn = 4;
            CheckButtonOrder();
            okButtonBool = true;
            okToggle.isOn = true;
        }
    }

    #endregion

    public void CheckButtonOrder()
    {
        if (lastButtonOn == correctButton)
        {
            Debug.Log("Correct" + ", last button: " + lastButtonOn + ", correct button: " + correctButton);
            score++;
        }
        else
        {
            Debug.Log("Incorrect" + ", last button: " + lastButtonOn + ", correct button: " + correctButton);
            Shaker.ShakeAll(shakePreset);
        }
        correctButton++;
    }

    public void ResetProtools()
    {
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
            protoolsApp.isOn = false;

            correctButton = 0;
            score = 0;
        }
    }
}
