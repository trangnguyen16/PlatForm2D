using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFail : MonoBehaviour
{
    // Start is called before the first frame update

  
    public Rigidbody2D rb;
    void Start()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        
    }

    
}
