using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


public class Move : MonoBehaviour
{
    #region //variable
    [Header("Variable")]
    public bool input;
    public LayerMask ground;
    public BoxCollider2D boxCollider;
    public Rigidbody2D rb;
    public Animator anm;

    public SpriteRenderer colorPlayer;
    public enum State { idle, running, jumpping, failling, hurtting};
    public State state = State.idle;

    [Header("Audio")]

    public AudioSource audioJump;
    public AudioSource audioCatCoin;

    [Header("GameObject")]

    public GameObject fx;
    public GameObject bullet;
    public Joystick joystick;
    

    [Header("Speed")]

    public int speed;
    public int jump;

    [Header("Attack")]

    public float attackSpeed;
    public float nextAttackTime;
    private bool m_FacingRight;


    #endregion // variable

    public void Start()
    {
        GetComponent<AudioSource>().Play();
    }
    void Update()
    {
        //new
        if(state != State.hurtting)
        {
            Movement();
        }
        
        Animation();
        anm.SetInteger("state", (int)state);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    #region // movement
    public void Movement()
    {
        float hDirection = joystick.Horizontal*speed;
        if (hDirection < 0 || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector2(-1, 1);
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (hDirection > 0 || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localScale = new Vector2(1, 1);
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
   
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        //if (Time.time >= nextAttackTime)
        //{
          // if (Input.GetKeyDown(KeyCode.Mouse0))
            //{
                //    Instantiate(bullet, this.transform.position, Quaternion.identity);
              // nextAttackTime = Time.time + 1f / attackSpeed;
                
          //  }
        //}
        
        if (Input.GetMouseButton(1))
        {
            state = State.hurtting;
        }
    }

    #endregion #movement
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump);
        state = State.jumpping;
        audioJump.Play();
    }
    #region //Animation


    void Animation()
  
    {
        
        if(state == State.jumpping) // state == 2
        {

            if(rb.velocity.y < 0.1f)
            {
                state = State.failling; // state == 3
            }
        }
        else if (state == State.failling) 
        {
            if (boxCollider.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        // new
        else if (state == State.hurtting)
        {
            if(Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }




    }
    #endregion //Animation
    #region //physic
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Thorns"))
        {
            SceneManager.LoadScene(1);
        }
        Buff(other);
        LoadScence(other);
        

    }
    #endregion //physic
    public void ResetPower()
    {
        Manager m = new Manager();
            m.cherryScore++;
        jump = 20;
        colorPlayer.color = Color.white;
    }

    public void Buff(Collider2D other)
    {
        Manager m = new Manager();
        if (other.tag == "Thorns")
        {
            SceneManager.LoadScene(1);
        }
        if (other.tag == "Cherry")
        {
            //goi point tu ben manager qua
            Manager.instance.cherryScore++;
            Manager.instance.textCherry.text = Manager.instance.cherryScore.ToString();
            Destroy(other.gameObject);
            Instantiate(fx, other.gameObject.transform.position, Quaternion.identity);
            audioCatCoin.Play();
        }
        if (other.tag == "Gem")
        {
            Manager.instance.gemScore++;
            Manager.instance.textGem.text = Manager.instance.gemScore.ToString();
            jump += 10;
            Destroy(other.gameObject);
            Instantiate(fx, other.gameObject.transform.position, Quaternion.identity);
            colorPlayer.color = Color.red;
            Invoke("ResetPower", 10f);
            audioCatCoin.Play();
        }
    }
    public void LoadScence(Collider2D other)
    {
        if (other.tag == "NextScene")
        {
            SceneManager.LoadScene(1);
        }
        if (other.tag == "Die")
        {
            SceneManager.LoadScene(1);
            //boxCollider.enabled = false;
            //rb.velocity = Vector2.zero;
            //this. = false;
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        //new
        if (other.gameObject.CompareTag("Enemy"))
        {
            // neu ma dap tren dau , chet voi nhay
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
           if(state == State.failling)
            {
                enemy.JumpOn();
                Jump();
            }
            else
            {
                // vang nguoi choi
                state = State.hurtting;
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    rb.velocity = new Vector2(-13, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(13, rb.velocity.y);
                }
            }
        }
        if (other.gameObject.CompareTag("Thorns"))
        {
            
            {
                // vang nguoi choi
                state = State.hurtting;
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    rb.velocity = new Vector2(-13, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(13, rb.velocity.y);
                }
            }
        }
    }
}
