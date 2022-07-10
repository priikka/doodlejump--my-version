using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;
    public AudioClip jumpClip;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
   {
    
    if (collision.relativeVelocity.y <= 0f) 
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        
        if (rb != null)
        {
            Vector2 velocity = rb.velocity;
            //making the player to jump to a fixed height every time
            velocity.y = jumpForce;
            rb.velocity = velocity;
             // jump sound
            audioSource.PlayOneShot(jumpClip);
            
        }
   }
    }
}
