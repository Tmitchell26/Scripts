using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // base movement values 
    public float moveSpeed = 5f; // distance moved when user holds up or down arrow keys 
    public float turnSpeed = 60f; //roatating speed when user holds left or right arrow key 
    public float jumpHeight = 5f; // upward velocity when user presses spacebar
    public int maxHealth = 20; // health the player has at level 0
    public int hp = 0; // amount of hp the player has
    //public int attack = 2; // amount of attack damage player has at level 0

    //public int xp = 0; // amount of XP the player has 
    //public int currentXp; // player xp after gaining xp
    //public int xpForNextLevel = 5; //xp needed to level up, the higher the level, the harder it gets
    //public int level = 0; //level of the player
    //public Text LevelCounter;

    public int playerHealth; // player health taking levels into consideration
    public int currentHealth; // player health after taking damage
    //public int currentAttack; // player attack damage after taking levels into consideration

    //public HealthBar healthBar; // call health bar script to link player health to health bar
    //public XpBar xpBar; // call the xp bar script to link player xp to health bar
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        //SetXpForNextLevel();
        playerHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        //xpBar.SetMinXp(xp);
        //currentXp = xp;
        //currentAttack = attack;

        //LevelCounter.text = "Level: " + level;
    }

    // To level up you need to collect an amount of xp;
    // This starts at 5 xp
    // Each level you gain the xp required gets higher exponentially
    // The exponential growth is slowed by scaling it by 10%

    /*void SetXpForNextLevel()
    {
        xpForNextLevel = (5 + level);
        xpBar.SetMaxXp(xpForNextLevel);
        xpBar.SetXP(xp);
        currentXp = xp;
    }*/

    void SetPlayerHealth()
    {
        //playerHealth = maxHealth + (2 * level);
        currentHealth = playerHealth;
        //healthBar.SetHealth(currentHealth);
        //healthBar.SetMaxHealth(playerHealth);
    }

    void SetPlayerAtack()
    {
        //currentAttack = attack + (2 * level);
    }

    // level up method 
    public void LevelUp()
    {
        //xp = 0;
        //level++;
        //LevelCounter.text = "Level: " + level;
        //SetXpForNextLevel();
        SetPlayerHealth();
        SetPlayerAtack();
    }

    //a function to make the player gain the ammount of Xp the you tell it. 
    public void GainXP(int xpToGain)
    {
        //xp += xpToGain;
        //currentXp = xp;
        //xpBar.SetXP(currentXp);
    }

    public void GainHp(int hpToGain)
    {
        hp += hpToGain;
        if(currentHealth < playerHealth)
        {
            currentHealth += hp;
            //healthBar.SetHealth(currentHealth);
        }
        // reset hp to 0 after every call
        hp = 0;
    }

    // function to simulate the player taking damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0 )
        {
            //PlayerManager.instance.KillPlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Test the GainXp function by pressing the x button. 
        //if (Input.GetKeyDown(KeyCode.X) == true)
        //{
            //GainXP(1);
            //currentXp = xp;
            //xpBar.SetXP(currentXp);
       // }

        //if(Input.GetKeyDown(KeyCode.Z) == true)
        //{
            //GainHp(2);
            //currentHealth = currentHealth + hp;
            //healthBar.SetHealth(currentHealth);
            // reset hp back to 0 
           // hp = 0;
        //}

        //LevelUp when the appropriate conditions are met.
       // if (xp >= xpForNextLevel)
        //{
            //LevelUp();
        //}

        // test health bar by taking damage
        //if (Input.GetKeyDown(KeyCode.T))
        //{
            //TakeDamage(2);
        //}

       
        // Check spacebar to trigger jumping. Checks if vertical velocity (eg velocity.y) is near to zero.
        if (Input.GetKey(KeyCode.Space) == true && Mathf.Abs(this.GetComponent<Rigidbody>().velocity.y) < 0.01f)
        {
            this.GetComponent<Rigidbody>().velocity += Vector3.up * this.jumpHeight;
        }

        float translation = Input.GetAxis("Vertical") * moveSpeed;
        float straffe = Input.GetAxis("Horizontal") * moveSpeed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);
    }
}
