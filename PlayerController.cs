using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.velocity = (new Vector2(hozMovement * speed, vertMovement * speed));
    }
}