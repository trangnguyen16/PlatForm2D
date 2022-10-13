using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumEnemy : MonoBehaviour
{
  
       public Rigidbody2D rb;

  
    public void OnCollisionEnter2D(Collision2D other)
    {
        //new
        if (other.gameObject.CompareTag("Player"))
        {
               rb.velocity = new Vector2(-13, rb.velocity.y);
        }
        else
                {
                    rb.velocity = new Vector2(13, rb.velocity.y);
                }

          


        }
    }
