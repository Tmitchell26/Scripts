using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // base movement values 
    public float moveSpeed = 5f; // distance moved when user holds up or down arrow keys 
    public float turnSpeed = 60f; //roatating speed when user holds left or right arrow key 
    public float jumpHeight = 5f; // upward velocity when user presses spacebar

    // the movements with the level up buffs 
    public float currentMoveSpeed;
    public float currentTurnSpeed;
    public float currentJumpHeight;

    public float xp = 0; // amount of XP the player has 
    public float xpForNextLevel = 5; //xp needed to level up, the higher the level, the harder it gets
    public int level = 0; //level of the player

    // Start is called before the first frame update
    void Start()
    {
        SetXpForNextLevel();
        SetCurrentMoveSpeed();
        SetCurrentTurnSpeed();
        SetCurrentJumpHeight();
    }
    // To level up you need to collect an amount of xp;
    // This starts at 10 xp
    // Each level you gain the xp required gets higher exponentially
    // The exponential growth is slowed by scaling it by 10%

    void SetXpForNextLevel()
    {
        xpForNextLevel = (5f + (level * level * 0.1f));
        Debug.Log("xpForNextLevel " + xpForNextLevel);
    }

    // For each level, the player adds 10% to the move speed 
    void SetCurrentMoveSpeed()
    {
        currentMoveSpeed = this.moveSpeed + (this.moveSpeed * 0.1f * level);
        Debug.Log("currentMoveSpeed = " + currentMoveSpeed);
    }

    // For each level, the player adds 10% to the turn speed 
    void SetCurrentTurnSpeed()
    {
        currentTurnSpeed = this.turnSpeed + (this.turnSpeed * (level * 0.1f));
        Debug.Log("currentTurnSpeed = " + currentTurnSpeed);
    }

    // for each level, the player adds 1-% to the jump height 
    void SetCurrentJumpHeight()
    {
        currentJumpHeight = this.jumpHeight + (this.jumpHeight * (level * 0.1f));
        Debug.Log("currentJumpHeight = " + currentJumpHeight);
    }

    // level up method 
    void LevelUp()
    {
        xp = 0f;
        level++;
        Debug.Log("level" + level);
        SetXpForNextLevel();
        SetCurrentMoveSpeed();
        SetCurrentTurnSpeed();
        SetCurrentJumpHeight();

    }

    //a function to make the player gain the ammount of Xp the you tell it. 
    public void GainXP(int xpToGain)
    {
        xp += xpToGain;
        Debug.Log("Gained " + xpToGain + " XP, Current Xp = " + xp + ", XP needed to reach next Level = " + xpForNextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        //Test the GainXp function by pressing the x button. 
        if (Input.GetKeyDown(KeyCode.X) == true)
        {
            GainXP(1);
        }

        //LevelUp when the appropriate conditions are met.
        if (xp >= xpForNextLevel)
        {
            LevelUp();
        }

        // check up and down arrow keys to move forwards and backwards 
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            this.transform.position += this.transform.forward * currentMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            this.transform.position -= this.transform.forward * currentMoveSpeed * Time.deltaTime;
        }

        // check left and right arrow keys to rotate left and right 
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            this.transform.RotateAround(this.transform.position, Vector3.up, -currentTurnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            this.transform.RotateAround(this.transform.position, Vector3.up, currentTurnSpeed * Time.deltaTime);
        }

        // Check spacebar to trigger jumping. Checks if vertical velocity (eg velocity.y) is near to zero.
        if (Input.GetKey(KeyCode.Space) == true && Mathf.Abs(this.GetComponent<Rigidbody>().velocity.y) < 0.01f)
        {
            this.GetComponent<Rigidbody>().velocity += Vector3.up * this.currentJumpHeight;
        }
    }
}
