using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientMover : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player")
        {
            Debug.Log("player");
            transform.position = new Vector3(transform.position.x, -7, transform.position.z);
        }
    }
}
