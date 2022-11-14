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

    public LayerMask groundLayer;

    //0 is right, 1 if left
    public int playerDir;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        health = 10;
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
    }

    void FixedUpdate()
    {
        //if(IsPressingSpace == true)
        //{
        //    Debug.Log("z has been pressed");
        //    IsPressingSpace = false;
       // }

        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(horizontal * Time.deltaTime * Speed, 0f, 0f);

        if(horizontal > 0)
        {
            playerDir = 1;
        }
        else if(horizontal < 0)
        {
            playerDir = -1;
        }

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

        if (health == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelNumber);
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
            scoreText.text = "Life: " + health.ToString();
            //Debug.Log(health);
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
            scoreText.text = "Life: " + health.ToString();
        }
    }

}
