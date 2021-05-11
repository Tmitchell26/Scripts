using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FingerShift : MonoBehaviour
{
    Renderer renderer;

    public GameObject milkModel, fingerModel;
    public AudioSource lightFlicker, hummingSound;
    public InspectRaycast inspectRay;
    bool previousFrame, currentFrame;
    public PlayableDirector openFridge;
    private bool canPlay = true;


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (renderer.isVisible && inspectRay.fridgeOpen == true)
        {
            Debug.Log("Object is visible");
            currentFrame = true;
            if (canPlay)
            {
                openFridge.Play();
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
            fingerModel.SetActive(false);
            milkModel.SetActive(true);
            lightFlicker.Stop();
            hummingSound.Stop();
            openFridge.time = 0;
            openFridge.Stop();
            openFridge.Evaluate();
        }
        //enabled = false;
    }
}
