using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] abilities;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, abilities.Length);
        Instantiate(abilities[rand], transform.position, Quaternion.identity);
    }

    
}
