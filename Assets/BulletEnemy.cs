using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private void Update()
    {
        rb.velocity = transform.right * speed;
    }
}
