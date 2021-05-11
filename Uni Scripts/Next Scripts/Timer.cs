using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer;
    public GameObject trigger;
    public AudioSource knock;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(StartTimer());
        }
    }

    IEnumerator StartTimer()
    {
        timer = 30f;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        if (timer <= 0)
        {
            knock.Play();
            trigger.GetComponent<Collider>().enabled = false;
        }
    }
}
