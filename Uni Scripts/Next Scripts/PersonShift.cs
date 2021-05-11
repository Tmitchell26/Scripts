using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PersonShift : MonoBehaviour
{
    Renderer renderer;

    public GameObject oldManModel, exModel, glassSmash;
    public AudioSource lightFlicker, imSorryAria, hummingSound;
    public InspectRaycast inspectRay;
    bool previousFrame, currentFrame;
    public PlayableDirector openDoor;
    private bool canPlay = true;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (renderer.isVisible && inspectRay.isOpen == true)
        {
            Debug.Log("Object is visible");
            currentFrame = true;
            if (canPlay)
            {
                openDoor.Play();
                canPlay = false;
            }    
        }
        else
        {
            Debug.Log("Object is no longer visible");
            currentFrame = false;
            OnBecameInvisible();
        }

        previousFrame = currentFrame;
    }

    void OnBecameInvisible()
    {
        if (currentFrame == false && previousFrame == true)
        {
            exModel.SetActive(false);
            oldManModel.SetActive(true);
            lightFlicker.Stop();
            imSorryAria.Stop();
            hummingSound.Stop();
            openDoor.time = 0;
            openDoor.Stop();
            openDoor.Evaluate();
            glassSmash.SetActive(false);
        }
        //enabled = false;
    }
}
