using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private bool goRight = true;

    private float speed = 4.0f;
 
     void FixedUpdate () 
    {
         if (goRight)
            {
            transform.Translate (Vector2.right * speed * Time.deltaTime);
            }
         else
            {
            transform.Translate (-Vector2.right * speed * Time.deltaTime);
            }
         
         if(transform.position.x >= 12.47f) 
            {
            goRight = false;
            }
         
         if(transform.position.x <= -12.38f) 
            {
            goRight = true;
            }
    }

}