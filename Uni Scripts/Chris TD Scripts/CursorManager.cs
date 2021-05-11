using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D defaultTextureMouse;
    public Texture2D exitTextureMouse;
    public CursorMode curModeMouse = CursorMode.Auto;
    // Use this for initialization
    void Start()
    {
        Cursor.SetCursor(defaultTextureMouse, new Vector2(defaultTextureMouse.width/3, defaultTextureMouse.height / 8), curModeMouse);
    }
    public void OnMouseEnter()
    {
        Cursor.SetCursor(exitTextureMouse, new Vector2(exitTextureMouse.width / 2.3f, exitTextureMouse.height / 6), curModeMouse);
    }
    public void OnMouseExit()
    {
        Cursor.SetCursor(defaultTextureMouse, new Vector2(defaultTextureMouse.width / 3, defaultTextureMouse.height / 8), curModeMouse);
    }
}
