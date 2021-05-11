using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 20f;

    public int maxHealth = 10; // enemy max health 
    public int currentHealth; // enemy health after taking damage from player
    public float hitTime = 1f; // time in seconds between each hit
    public float currentTime = 0f; // time in seconds since last hit 
    public int enemyDamage; // enemy attack damage
    public float spawnHeight; //loot drop height 

    public GameObject coin; // coin prefab
    public GameObject health; // health prefab 

    public UnityEvent OnEnemyDeath;

    Transform target;
    NavMeshAgent agent;

    public void SetEnemyCurrentHealth(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            OnDeath();
            OnEnemyDeath.Invoke();
            Destroy(this.gameObject);
        }
    }

    private void OnDeath()
    {
        int change = 1;
        for (int i = 1; i <= maxHealth / 2; i++)
        {
            // drops coin on enemy death 
            var coinPos = new Vector3(transform.position.x - change, spawnHeight, transform.position.z);
            Instantiate(coin, coinPos, Quaternion.identity);

            // drops health on enemy death
            var healthPos = new Vector3(transform.position.x + change, spawnHeight, transform.position.z);
            Instantiate(health, healthPos, Quaternion.identity);

            change++;
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                currentTime += Time.deltaTime; // add time

                if (currentTime >= hitTime) // if the set amount of time has passed
                {
                    attack();
                }
                FaceTarget(); 
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void attack()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "Character")
            {
                hit.collider.gameObject.GetComponent<PlayerController>().TakeDamage(enemyDamage);
                Debug.Log("Player hit for 5 damage");
                currentTime = 0; // reset the time 
            }
        }
    }

    
}
