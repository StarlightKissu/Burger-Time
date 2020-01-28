using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static float lives = 3;
    public Text score;
    private int scoreValue = 0;
    public Text livesText;

    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool onGround;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public AudioClip enemyTouch;
    public AudioClip walkOver;
    public AudioSource musicSource;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        livesText.text = ("LIVES: " + lives.ToString());
    }

    void FixedUpdate() {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update() {

        onGround = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(moveInput > 0){
            transform.eulerAngles = new Vector3(0, 180, 0);
        } else if(moveInput < 0){
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if(onGround == true && Input.GetKeyDown(KeyCode.UpArrow)){
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.UpArrow) && isJumping == true){
            if(jumpTimeCounter > 0){
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }  else {
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.UpArrow)){
            isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Debug.Log("Enemy");
            lives = lives - 1;
            livesText.text = ("LIVES: " + lives.ToString());
            musicSource.clip = enemyTouch;
            musicSource.Play();
        }
    }
    void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Ingredient")
        {
            Debug.Log("Ingredient");
            musicSource.clip = walkOver;
            musicSource.Play();
        }

    }

}