using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
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
            if(this.tag == "Hp")
            {
                other.GetComponent<PlayerController>().GainHp(2);
            }
            
            Destroy(this.gameObject);   
        }  
    }

}
