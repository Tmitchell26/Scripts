using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownMenuManager : MonoBehaviour
{
    public GameObject menuObject;

    void OnMouseOver()
    {
        menuObject.SetActive(true);
    }

    void OnMouseExit()
    {
        menuObject.SetActive(false);
    }
}
