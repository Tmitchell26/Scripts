using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkAsk : MonoBehaviour
{

    public AudioSource askingForMilk, justSomeMilk;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AskingForMilk());
        StartCoroutine(SomeMilk());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AskingForMilk()
    {
        yield return new WaitForSeconds(10f);
        askingForMilk.Play();
    }

    IEnumerator SomeMilk()
    {
        yield return new WaitForSeconds(16f);
        justSomeMilk.Play();
    }
}
