using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    
    public float speed;
    public float attackTime;
    public float nextAttackTime;

    public Rigidbody2D rb;
    public GameObject bullet;

    public Vector2 move;

    private void Start()
    {
        move = this.transform.position;

    }
    private void Update()
    {

        move.x += speed * Time.deltaTime; // 0 += -2
        this.transform.position = move;

        if (Time.time >= nextAttackTime)
        {
          
            float randomX = Random.Range(-76,-56);
            Vector2 whereToSpawn = new Vector2(randomX, transform.position.y) ;
            Instantiate(bullet, whereToSpawn, Quaternion.identity);
            nextAttackTime = Time.time + 1f / attackTime;
       
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("ground"))
        {
            speed *= -1; // 2*=-1 = -2
        }
    }
}
