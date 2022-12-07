using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;
public class PlayerBehaviour : MonoBehaviour
{
    public float Speed = 5;
    private Rigidbody2D rb2d;
    private BoxCollider2D boxCollider2D;
    public static float health;
    public bool isTouching = false;
    public bool IsPressingSpace;
    public bool IsPressingE;
    public TextMeshProUGUI scoreText;
    public int levelNumber = 1;
    public bool isFacingLeft = false;
    public SpriteRenderer playerImage;
    public float Horizontal;
    public LayerMask groundLayer;

    //0 is right, 1 if left
    public int playerDir;

    //player sounds
    public AudioClip PlayerHit;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        health = 10;
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


        FlipDirection();
    }

    public void FlipDirection()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
            playerImage.flipX = true;
        }
        
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform.localRotation = Quaternion.Euler(0, 0, 0);
            playerImage.flipX = false;
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

        if(isTouching == true)
        {
            if(Input.GetKey(KeyCode.E))
            {
                levelNumber++;
                UnityEngine.SceneManagement.SceneManager.LoadScene(levelNumber);
                
            }
        }

        if (health <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(5);
        }

        //float xmove = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        // Vector2 movement = new Vector2(xmove, rb2d.velocity.y);
        //rb2d.velocity = movement;
        //rb2d.velocity = new Vector2(xmove * Speed, rb2d.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, groundLayer);
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            //Debug.Log("touching object");
        }

        if (collision.transform.tag == "grunt")
        {
            health--;
            AudioManager.PlaySoundEffect(PlayerHit);
            scoreText.text = "Life: " + health.ToString();
            //Debug.Log(health);
        }

        if (collision.transform.tag == "Spike")
        {
            health--;
            AudioManager.PlaySoundEffect(PlayerHit);
            scoreText.text = "Life: " + health.ToString();
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "console" )
        {
            isTouching = true;
            //Debug.Log("console");
            
        }
        else
        {
            //Debug.Log("false");
            isTouching = false;
        }

        if(collision.gameObject.tag == "bullet2")
        {
            health--;
            AudioManager.PlaySoundEffect(PlayerHit);
            scoreText.text = "Life: " + health.ToString();
        }

        if (collision.gameObject.tag == "Health")
        {
            health++;
            scoreText.text = "Life: " + health.ToString();
            Destroy(collision.gameObject);
        }
    }

}
