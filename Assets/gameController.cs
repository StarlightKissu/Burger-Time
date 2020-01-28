using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{

private bool gameOver;

private AudioSource audioSource;

    void Start() {
        
        gameOver = false;

        audioSource = GetComponent<AudioSource>();

    }

    void Update() {

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        //if(lives <= 0)


        if(gameOver) {
            SceneManager.LoadScene("Game Over");
        }

    }
}
