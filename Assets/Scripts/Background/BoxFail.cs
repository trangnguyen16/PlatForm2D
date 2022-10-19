using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFail : MonoBehaviour
{
    public float time;
    public Rigidbody2D rb;

    IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(time);
        //cach truy cap vao bodytype
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitForSecond());
        }
    }
}
