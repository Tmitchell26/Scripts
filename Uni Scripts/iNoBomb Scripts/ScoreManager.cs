using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public float scoreAmount;
    public float highScore;
    public int savedScore;
    public float pointPerSec;
    public Text scoreDisplay, highScoreDisplay, gameOverScoreDisplay;

    private void Awake()
    {
        instance = this;

        /*if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetFloat("HighScore");

            highScoreDisplay.text = "High Score: " + savedScore + "m";
        }*/
    }
    private void Update()
    {
        scoreDisplay.text = (int)scoreAmount + "m";
        scoreAmount += pointPerSec * Time.deltaTime;

        gameOverScoreDisplay.text = "Your Score: " + (int)scoreAmount + "m";
        savedScore = (int)scoreAmount;

        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
       if(scoreAmount > highScore)
        {
            highScore = savedScore;
            highScoreDisplay.text = "High Score: " + savedScore + "m";

            /*PlayerPrefs.SetFloat("HighScore", highScore);*/
        }
    }

    public void ResetScore()
    {
        scoreAmount = 0f;
    }
}
