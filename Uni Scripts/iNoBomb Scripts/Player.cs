using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Globalization;

public class Player : MonoBehaviour
{

    public static Player instance;

    public float health;
    public Rigidbody2D rb;
    public float jumpHeight;

    public Text healthDisplay;
    public GameObject gameOver;
    public GameObject scoreOver;
    public GameObject thePlayer;
    public GameObject Spawner;
    public GameObject grenade1, grenade2, grenade3;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public Animator animator;

    private void Awake()
    {
        instance = this;
    }

    void start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }
    // Update is called once per frame
    void Update()
    {
        if (health > 3)
        {
            health = 3;
        }

        switch (health)
        {
            case 3:
                grenade1.gameObject.SetActive(true);
                grenade2.gameObject.SetActive(true);
                grenade3.gameObject.SetActive(true);
                break;

            case 2:
                grenade1.gameObject.SetActive(true);
                grenade2.gameObject.SetActive(true);
                grenade3.gameObject.SetActive(false);
                break;

            case 1:
                grenade1.gameObject.SetActive(true);
                grenade2.gameObject.SetActive(false);
                grenade3.gameObject.SetActive(false);
                break;

            case 0:
                grenade1.gameObject.SetActive(false);
                grenade2.gameObject.SetActive(true);
                grenade3.gameObject.SetActive(false);
                gameOver.SetActive(true);
                scoreOver.SetActive(false);
                thePlayer.SetActive(false);
                Spawner.SetActive(false);
                break;

        }

        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }

        if (Input.touchCount > 0 && isGrounded == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpHeight, 0);
            isGrounded = false;
            Debug.Log("i am not grounded");
            animator.SetBool("isJumping", true);
        }

        /*if (Input.GetKey(KeyCode.UpArrow) && isGrounded == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpHeight, 0);
            isGrounded = false;
            animator.SetBool("isJumping", true); 
        }*/
    }

    public void ResetHealth()
    {
        health = 3f;
    }

}
