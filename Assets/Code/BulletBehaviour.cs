using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(0, 0, -90);
        rb.velocity = Vector2.right * 7;
        Invoke("Despawn", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Despawn()
    {
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "grunt")
        {
            Debug.Log("touching object");
            Destroy(gameObject);
        }
    }

}