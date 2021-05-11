using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothV;

    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        Player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Player.transform.up);
    }
}