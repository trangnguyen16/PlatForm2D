using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource audioDie;
    public GameObject fx;
    public GameObject bullet;
    public float nextAttackTime;
    public float attackSpeed = 2f;

    public void Die()
    {
        Destroy(gameObject);

    }
    public void JumpOn()
    {
        Die();
        audioDie.Play();

        Instantiate(fx, this.transform.position, Quaternion.identity);

    }
    public void Update()
    {
        //Time.time la thoi gian tinh tu khi an play
        //khi thoi gian lon hon nextattacktime cho chay
        if (Time.time >= nextAttackTime)
        {
            {
                Debug.Log(Time.time);
                // co the dieu chinh vt o day dc hay ko?
                Instantiate(bullet, this.transform.position, Quaternion.identity);
                //den 1 khoang thoi gian nao se sinh ra bullet moi
                nextAttackTime = Time.time + 1f / attackSpeed;

            }
        }
    }

}
