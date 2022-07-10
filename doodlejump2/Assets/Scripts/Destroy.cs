using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    //viel fixattavaa että löytyy aina platform mihin laskeutua muuten ok
    public GameObject player;
    public GameObject platform;
    public GameObject BigBounce;
    private GameObject newPlatform;
   
   // destroy platforms that hit the destroyer and instantiate new platforms ahead to make game continue infinitely
    private void OnTriggerEnter2D (Collider2D collision)
    {
      if(collision.gameObject.name.StartsWith("platform"))
      {
        if(Random.Range(1,7)==1)
        {
            Destroy(collision.gameObject);
            Instantiate(BigBounce, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y+(4+Random.Range(0.0f,0.7f))), Quaternion.identity);
        }else
        {
            collision.gameObject.transform.position = new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y+(7+Random.Range(0.2f,0.7f)));
        }

      }else if (collision.gameObject.name.StartsWith("BigBounce"))
      {
        if(Random.Range(1,7)==1)
        {
            collision.gameObject.transform.position = new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y+(25+Random.Range(0.2f,0.7f)));
        
        }else
        {
            Destroy(collision.gameObject);
            Instantiate(platform, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y+(4+Random.Range(0.2f,0.7f))), Quaternion.identity);
        }
      }
      

        
    }
}
