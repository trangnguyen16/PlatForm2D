using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCherry : MonoBehaviour
{
    public float spawnCherrySpeed;
    public GameObject [] cherryAndGem; //cheryandgem [random.rang(0,1]]
    private int minX;
    public int maxX;
    public int minY;
    public int maxY;
    [HideInInspector] public float nextTime;
    [HideInInspector] public float randomX;
    [HideInInspector] public Vector2 whereToSpawn;
    [HideInInspector] public float randomY;
    



    void Update()
    {
        if(Time.time >= nextTime)
        {
           // if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GameObject cherryAndGemPrefab = (cherryAndGem[Random.Range(0, cherryAndGem.Length)]);
                randomX = Random.Range(minX,maxX);
                randomY = Random.Range(minY,maxY);
                whereToSpawn = new Vector2(randomX, randomY);
                Instantiate(cherryAndGemPrefab, whereToSpawn, Quaternion.identity);
           
                nextTime = Time.time + 1f / spawnCherrySpeed;
        }
        }
        
    }
}
