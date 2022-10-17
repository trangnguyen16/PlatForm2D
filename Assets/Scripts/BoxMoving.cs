using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMoving : MonoBehaviour
{
    public float speed;
    public Vector2 move;

    private void Start()
    {
        move = this.transform.position;

    }
    private void Update()
    {
        move.x += speed * Time.deltaTime; // 0 += -2
        this.transform.position = move;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("ground"))
        {
            speed *= -1; // 2*=-1 = -2
        }
    }
}
