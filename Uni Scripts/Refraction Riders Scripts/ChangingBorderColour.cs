using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangingBorderColour : MonoBehaviour
{

    public Material Yellow, Orange, Red, Blue, Green;

    public MeshRenderer mesh;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mesh.material = Yellow;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mesh.material = Orange;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            mesh.material = Red;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            mesh.material = Blue;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            mesh.material = Green;
        }
    }

}