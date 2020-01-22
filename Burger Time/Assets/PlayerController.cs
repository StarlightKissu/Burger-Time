using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed;
    private float inputHorizontal;
    private float inputVertical;
    public float distance;
    public LayerMask whatIsLadder;
    private bool isClimbing;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        rd2d.velocity = new Vector2(inputHorizontal * speed, rd2d.velocity.y);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if(hitInfo.collider != null)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                isClimbing = true;
            }
            else {
                isClimbing = false;
            }
        }

        if(isClimbing == true)
        {
            Debug.Log("Climbing");
            inputVertical = Input.GetAxisRaw("Vertical");
            rd2d.velocity = new Vector2(rd2d.position.x, inputVertical * speed);
            rd2d.gravityScale = 0;
        }
        else {
            rd2d.gravityScale = 1;
        }
    }
}