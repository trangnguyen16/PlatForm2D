using System.Collections;
using UnityEngine;

public class TimeDelay : MonoBehaviour
{
    public float time = 5f;

    void Start()
    {
        StartCoroutine(AfterSecond());
      
   
    }

    IEnumerator AfterSecond() // void timedelay
    {
        yield return new WaitForSeconds(time);
        
    }
    
    
    
}
