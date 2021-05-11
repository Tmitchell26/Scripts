using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(startPump());
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(startBreath());
        }
    }

    IEnumerator startPump()
    {
        animator.SetBool("Pump", true);
        yield return new WaitForSeconds(.8f);
        animator.SetBool("Pump", false);
    }

    IEnumerator startBreath()
    {
        animator.SetBool("Breath", true);
        yield return new WaitForSeconds(.8f);
        animator.SetBool("Breath", false);
    }
}
