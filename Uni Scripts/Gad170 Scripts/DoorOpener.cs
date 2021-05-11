using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    // uncomment right door if you wish to use a double door 
    // if only one door use the left door code 

    //public Transform rightDoor;
    public Transform leftDoor;
    //public Vector3 rightClosedPosition = new Vector3(.51f, 3.63f, 0);
    //public Vector3 rightOpenedPosition = new Vector3(.51f, 7f, 0);
    public Vector3 leftClosedPosition = new Vector3(.51f, 3.63f, 0);
    public Vector3 leftOpenedPosition = new Vector3(.51f, 7f, 0);
    public float openSpeed = 5f;
    private bool open = false;

    // Update is called once per frame
    void Update()
    {
        if(open)
        {
            //rightDoor.position = Vector3.Lerp(rightDoor.position, rightOpenedPosition, Time.deltaTime * openSpeed);
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftOpenedPosition, Time.deltaTime * openSpeed);
        }
        else
        {
            //rightDoor.position = Vector3.Lerp(rightDoor.position, rightClosedPosition, Time.deltaTime * openSpeed);
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftClosedPosition, Time.deltaTime * openSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Character")
        {
            OpenDoor();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Character")
        {
            CloseDoor();
        }
    }

    public void CloseDoor()
    {
        open = false;

    }
    public void OpenDoor()
    {
        open = true;
        
    }
}
