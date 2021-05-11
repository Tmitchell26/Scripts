using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float spinSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0f, 0f, Time.deltaTime * this.spinSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Character")
        {
            if(this.tag == "Coin")
            {
                other.GetComponent<PlayerController>().GainXP(1);
            }
         
            Destroy(this.gameObject);    
        }  
    }

}
