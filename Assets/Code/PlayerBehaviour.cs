using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;
public class PlayerBehaviour : MonoBehaviour
{
    public float Speed = 5;
    private Animator anim;
    private Rigidbody2D rb2d;
    private BoxCollider2D boxCollider2D;
    public static float Health;//f
    public bool IsTouching = false;
    public bool IsPressingSpace;
    public bool IsPressingE;
    public TextMeshProUGUI ScoreText;
    public int LevelNumber = 1;//f
    public bool IsFacingLeft = false;
    public SpriteRenderer PlayerImage;
    public float Horizontal;
    public LayerMask GroundLayer;

    //0 is right, 1 if left
    public int playerDir;//f

    //player sounds
    public AudioClip PlayerHit;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        Health = 10;
        playerDir = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            IsPressingSpace = true;
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            IsPressingSpace = false;
        }

        Horizontal = Input.GetAxis("Horizontal");

        if(Horizontal == 0)
        {
            anim.SetBool("IsRunning", false);
        }
        else if(Horizontal !=0)
        {
            anim.SetBool("IsRunning", true);
        }

       if(IsGrounded() != true)
        {
            anim.SetBool("IsJummping", true);
        }
       else if(IsGrounded() != false)
        {
            anim.SetBool("IsJummping", false);
        }
        FlipDirection();
    }

    public void FlipDirection()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
            PlayerImage.flipX = true;
        }
        
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform.localRotation = Quaternion.Euler(0, 0, 0);
            PlayerImage.flipX = false;
        }
    }

    void FixedUpdate()
    {
        //if(IsPressingSpace == true)
        //{
        //    Debug.Log("z has been pressed");
        //    IsPressingSpace = false;
       // }

        


        if(Horizontal > 0)
        {
            playerDir = 1;
        }
        else if(Horizontal < 0)
        {
            playerDir = -1;
        }

        rb2d.velocity = new Vector2(Horizontal * Time.deltaTime * Speed, rb2d.velocity.y);
        //Debug.Log("IsGrounded:"+ IsGrounded()+ ", IsPressingSpace:" + IsPressingSpace);

        if( IsGrounded() && IsPressingSpace)
        {
            float jumpVelocity = 10f;
            rb2d.velocity = Vector2.up * jumpVelocity;
        }

        if(IsTouching == true)
        {
            if(Input.GetKey(KeyCode.E))
            {
                LevelNumber++;
                UnityEngine.SceneManagement.SceneManager.LoadScene(LevelNumber);
                AudioManager.musicTimeStamp = AudioManager.music.time;
            }
        }

        if (Health <= 0)
        {
            AudioManager.musicTimeStamp = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene(5);
        }

        //float xmove = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        // Vector2 movement = new Vector2(xmove, rb2d.velocity.y);
        //rb2d.velocity = movement;
        //rb2d.velocity = new Vector2(xmove * Speed, rb2d.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, GroundLayer);
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            //Debug.Log("touching object");
        }

        if (collision.transform.tag == "grunt")
        {
            Health--;
            AudioManager.PlaySoundEffect(PlayerHit, 1.3f);
            ScoreText.text = "Life: " + Health.ToString();
            //Debug.Log(health);
        }

        if (collision.transform.tag == "Spike")
        {
            Health--;
            AudioManager.PlaySoundEffect(PlayerHit, 1.3f);
            ScoreText.text = "Life: " + Health.ToString();
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "console" )
        {
            IsTouching = true;
            //Debug.Log("console");
            
        }
        else
        {
            //Debug.Log("false");
            IsTouching = false;
        }

        if(collision.gameObject.tag == "bullet2")
        {
            Health--;
            AudioManager.PlaySoundEffect(PlayerHit, 1.3f);
            ScoreText.text = "Life: " + Health.ToString();
        }

        if (collision.gameObject.tag == "Health")
        {
            Health++;
            ScoreText.text = "Life: " + Health.ToString();
            Destroy(collision.gameObject);
        }
    }

}
