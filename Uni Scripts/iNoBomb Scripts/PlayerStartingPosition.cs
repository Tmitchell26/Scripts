using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartingPosition : MonoBehaviour
{

    public static PlayerStartingPosition instance;

    public Player thePlayer;
    private Vector3 playerStartPoint;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerStartPoint = thePlayer.transform.position;
    }


    public void StartingPosition()
    {
        thePlayer.transform.position = playerStartPoint;
    }

}
