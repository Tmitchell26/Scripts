using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeRock : MonoBehaviour
{
    public GameObject rock;

    void OnCollisionEnter(Collision other)
    {
        // if player grabs rock 
        if (other.gameObject.tag == "Player")
        {
            // add new rigidbody to rock to make it fall off the mountain
            Rigidbody gameObjectRigidbody = rock.AddComponent<Rigidbody>();
            gameObjectRigidbody.mass = 0.5f;
        }
    }
}
