using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public Text s1A, s1P, s2A, s2P, s3A, s3P;

    // Start is called before the first frame update
    void Start()
    {
        s1A.text = "Student 1 Audio Score: " + PlayerPrefs.GetInt("Student 1 Audio score");
        s1P.text = "Student 1 Playback Score: " + PlayerPrefs.GetInt("Student 3 Playback score");


        s2A.text = "Student 2 Audio Score: " + PlayerPrefs.GetInt("Student 2 Audio score");
        s2P.text = "Student 2 Playback Score: " + PlayerPrefs.GetInt("Student 2 Playback score");

        s3A.text = "Student 3 Audio Score: " + PlayerPrefs.GetInt("Student 3 Audio score");
        s3P.text = "Student 3 Playback Score: " + PlayerPrefs.GetInt("Student 3 Playback score");
    }

    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}