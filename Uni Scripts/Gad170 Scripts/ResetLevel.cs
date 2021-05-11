using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) == true)
        {
            SceneManager.LoadScene(0);
        }
    }
}
