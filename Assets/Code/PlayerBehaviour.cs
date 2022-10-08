using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    public float Speed = 5;
    private Rigidbody2D rb2d;
    private BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(horizontal * Time.deltaTime * Speed, 0f, 0f);


        if( IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 10f;
            rb2d.velocity = Vector2.up * jumpVelocity;
        }


        //float xmove = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
       // Vector2 movement = new Vector2(xmove, rb2d.velocity.y);
        //rb2d.velocity = movement;
        //rb2d.velocity = new Vector2(xmove * Speed, rb2d.velocity.y);
    }

    private bool IsGrounded()
    {
       RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f);
       return raycastHit2D.collider != null;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform");
        {
            Debug.Log("touching object");
        }
    }
    
}