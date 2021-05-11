using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour
{ 
    
    bool PlaySound;

    void Start()
    {
        PlaySound = true;
    }

    void Update()
    {
        if (PlaySound == true)
        {
            GetComponent<AudioSource>().Play();
            PlaySound = false;
        }
        if (GetComponent<AudioSource>().isPlaying == false)
        {
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        PlaySound = true;
    }
}
