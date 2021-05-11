using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MilkShake;

public class ButtonManager : MonoBehaviour
{
    public GameObject deskButton, interfaceButton, computerButton, speakerButton;
    private bool deskButtonBool = false, interfaceButtonBool = false, computerButtonBool = false, speakerButtonBool = false;

    public Toggle deskToggle, interfaceToggle, computerToggle, speakerToggle;

    public Sprite onSwitch, offSwitch;

    private int lastButtonOn;
    public int correctButton = 0;

    public int score = 0;
    public bool updateScore;
    public TextMeshProUGUI scoreText;

    public ShakePreset shakePreset;

    #region buttons
    //Desk
    public void DeskOn()
    {
        Debug.Log("Desk was turned on");
        deskButton.GetComponent<Image>().sprite = onSwitch;
        if (!deskButtonBool)
        {
            lastButtonOn = 0;
            CheckButtonOrder();
            deskButtonBool = true;
            deskToggle.isOn = deskButtonBool;
        }
        
    }
    public void DeskOff()
    {
        Debug.Log("Desk was turned off");
        deskButton.GetComponent<Image>().sprite = offSwitch;
        deskButtonBool = false;
        deskToggle.isOn = deskButtonBool;
    }

    //Interface
    public void InterfaceOn()
    {
        Debug.Log("Interface was turned on");
        interfaceButton.GetComponent<Image>().sprite = onSwitch;
        if (!interfaceButtonBool)
        {
            lastButtonOn = 1;
            CheckButtonOrder();
            interfaceButtonBool = true;
            interfaceToggle.isOn = deskButtonBool;
        }
    }
    public void InterfaceOff()
    {
        Debug.Log("Interface was turned off");
        interfaceButton.GetComponent<Image>().sprite = offSwitch;
        interfaceButtonBool = false;
        interfaceToggle.isOn = deskButtonBool;

    }

    //Computer
    public void ComputerOn()
    {
        Debug.Log("Computer was turned on");
        computerButton.GetComponent<Image>().sprite = onSwitch;
        if (!computerButtonBool)
        {
            lastButtonOn = 2;
            CheckButtonOrder();
            computerButtonBool = true;
            computerToggle.isOn = deskButtonBool;

        }
    }
    public void ComputerOff()
    {
        Debug.Log("Computer was turned off");
        computerButton.GetComponent<Image>().sprite = offSwitch;
        computerButtonBool = false;
        computerToggle.isOn = deskButtonBool;

    }

    //SpeakerL
    public void SpeakerOn()
    {
        Debug.Log("SpeakerL was turned on");
        speakerButton.GetComponent<Image>().sprite = onSwitch;
        if (!speakerButtonBool)
        {
            lastButtonOn = 3;
            CheckButtonOrder();
            speakerButtonBool = true;
            speakerToggle.isOn = deskButtonBool;

        }
    }
    public void SpeakerOff()
    {
        Debug.Log("SpeakerL was turned off");
        speakerButton.GetComponent<Image>().sprite = offSwitch;
        speakerButtonBool = false;
        speakerToggle.isOn = deskButtonBool;

    }
    #endregion

    public void CheckButtonOrder()
    {
        if(lastButtonOn == correctButton)
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

    public void ResetButtons()
    {
        DeskOff();
        InterfaceOff();
        ComputerOff();
        SpeakerOff();

        correctButton = 0;
        score = 0;
    }
}
