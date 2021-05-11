using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class SpeedBoost : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player") 
            { 
                if (other.GetComponentInParent<SAE.PlayerMovement>() != null)
                {
                    other.GetComponentInParent<SAE.PlayerMovement>().speedBooster();
                    Destroy(this.gameObject);
                }
            }
        }
    }



