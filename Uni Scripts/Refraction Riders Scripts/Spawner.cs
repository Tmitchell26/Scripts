using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public Transform[] spawnLocations;
    private GameObject spawnedAbility;
    public float spawnTimer;
    public float activeTimer;

    private void Start()
    {
        spawnedAbility = Instantiate(spawnObjects[Random.Range(0,spawnObjects.Length)], spawnLocations[Random.Range(0,spawnLocations.Length)]);
        StartCoroutine(spawnAbilities());
        StartCoroutine(deactivateAbilities(spawnedAbility));
    }

    private void Update()
    {
        if (spawnTimer <= 0)
        {
            StartCoroutine(spawnAbilities());
        }
    }

    IEnumerator spawnAbilities()
    {
        spawnTimer = 5f;

        while (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            yield return null;
        }

        if (spawnTimer <= 0)
        {
            spawnedAbility =  Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], spawnLocations[Random.Range(0, spawnLocations.Length)]);
            StartCoroutine(deactivateAbilities(spawnedAbility));
        }
    }

    IEnumerator deactivateAbilities(GameObject spawnedAbility)
    {
        activeTimer = 5f;

        while (activeTimer > 0)
        {
            activeTimer -= Time.deltaTime;
            yield return null;
        }

        if (activeTimer <= 0)
        {
            Destroy(spawnedAbility);
        }
    }
}
