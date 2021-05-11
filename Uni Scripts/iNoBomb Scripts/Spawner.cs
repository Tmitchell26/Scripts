using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;

    private float timeBtwSpawn;
    public float StartTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = StartTimeBtwSpawn;
            if (StartTimeBtwSpawn > minTime)
            {
                StartTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
