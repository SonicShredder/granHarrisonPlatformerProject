using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Vector2 spawnDir = Vector2.right;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        PlayerBehaviour pB = GameObject.FindObjectOfType<PlayerBehaviour>();
        transform.rotation = Quaternion.Euler(0, 0, pB.playerDir * 90);
        rb.velocity = SetSpawnDirection(pB.playerDir) * 7;
        Invoke("Despawn", 2);
    }

    public Vector2 SetSpawnDirection(int dir)
    {
        if(dir == -1)
        {
            return -Vector2.right;
            
        }
        else
        {
            return Vector2.right;
        }
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

        if(collision.transform.tag == "Platform")
        {
            Destroy(gameObject);
        }
    }

}
