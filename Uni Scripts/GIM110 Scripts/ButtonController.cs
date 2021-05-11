using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public string requiredCode;
    public string inputCode;
    public int codeCount;

    public Color succesColor;
    public Color failColor;
    public Color buttonColor;

    public List<Image> buttons;

    public void Update()
    {
        if (codeCount == requiredCode.Length)
        {
            // compare code
            if (requiredCode.Equals(inputCode))
            {
                // Success
                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].color = succesColor;
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                inputCode = "";
                codeCount = 0;
    
                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].color = failColor;
                }
            }
        }
        
    }
    public void pressImage(int imageIndex)
    {
        inputCode += "" + imageIndex;
        codeCount++;
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].color = buttonColor;
        }
    }
}
