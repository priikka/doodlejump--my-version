// this script serves as player movement script and also play control script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float movement = 0f;
    public float movementSpeed = 0f;

    public TMP_Text scoreText;
    public TMP_Text startText;
    
    private float topScore = 0.0f;
    private float highScore;
    
    public TMP_Text highScoreText;

    private bool isStarted;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.velocity= Vector3.zero;
        highScore = PlayerPrefs.GetFloat("HighScore", 0.0f);
        highScoreText.text = "High Score: "+Math.Round(highScore).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Starting the game by pressing space
        if (Input.GetKeyDown(KeyCode.Space) && isStarted == false)
        {
            isStarted = true;
            startText.gameObject.SetActive(false);
            rb.gravityScale=1.0f;
            
        }
        //Quitting the game by pressing Esc
        if (Input.GetKeyDown(KeyCode.Escape) && isStarted == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        if (isStarted == true)
        {
            movement = Input.GetAxis("Horizontal")*movementSpeed;
            // flipping the sprite to face right when moving to right and left when moving to left
            if (movement > 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }else
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }

            // score counter
            if(rb.velocity.y > 0 && transform.position.y > topScore)
            {
                topScore = transform.position.y;
                
                
            }
            scoreText.text = "Score: "+Math.Round(topScore).ToString();
            //change highscore, 0 by default

            if (PlayerPrefs.GetFloat("HighScore", 0.0f) < topScore )
            {
                highScore = topScore;
                PlayerPrefs.SetFloat("HighScore", highScore);
                highScoreText.text = "High Score: "+Math.Round(highScore).ToString();
            }
            
        }
    }

    //Actual player movement in FixedUpdate function
    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

   
}
