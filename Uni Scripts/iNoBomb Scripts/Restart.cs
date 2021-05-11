using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    public GameObject scoreBegin;
    public GameObject gameOver;
    public GameObject thePlayer;
    public GameObject Spawner;

    public void restartGame()
    {
        gameOver.SetActive(false);
        scoreBegin.SetActive(true);
        thePlayer.SetActive(true);
        Spawner.SetActive(true);

        ScoreManager.instance.ResetScore();
        Player.instance.ResetHealth();
        PlayerStartingPosition.instance.StartingPosition();
    }

    public void quitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}