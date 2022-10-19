using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFx : MonoBehaviour
{
    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
