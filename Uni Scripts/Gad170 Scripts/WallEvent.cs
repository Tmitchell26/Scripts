using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEvent : MonoBehaviour
{
    public void killWall()
    {
        Destroy(this.gameObject);
    }
}
