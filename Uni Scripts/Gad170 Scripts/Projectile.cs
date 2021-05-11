using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public float m_Speed = 5f;   // this is the projectile's speed
    public float m_Lifespan = 3f; // this is the projectile's lifespan (in seconds)
    public static int attack; // used for player damage

    public EnemyController enemy; // access the enemy controller script
   
    private Rigidbody m_Rigidbody;

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        m_Rigidbody.AddForce(m_Rigidbody.transform.forward * m_Speed);
        Destroy(gameObject, m_Lifespan);
        
    }

    public void OnCollisionEnter(Collision enemy)
    {
        if (enemy.gameObject.tag == "Enemy")
        {
            enemy.gameObject.GetComponent<EnemyController>().SetEnemyCurrentHealth(GameObject.FindGameObjectWithTag("Character").GetComponent<PlayerController>().currentAttack);
            Destroy(this.gameObject);
        }
    }

    


}