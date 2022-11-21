using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntBehaviour : MonoBehaviour
{
    public AudioClip AlienHit;

    public int gruntHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gruntHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bullet1")
        {
            gruntHealth--;
            AudioManager.PlaySoundEffect(AlienHit);
        }

        
    }
}
