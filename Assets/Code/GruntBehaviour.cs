using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntBehaviour : MonoBehaviour
{
    public AudioClip AlienHit;

    public int GruntHealth = 3;//f
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GruntHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bullet1")
        {
            GruntHealth--;
            AudioManager.PlaySoundEffect(AlienHit, 1.3f);
        }

        
    }
}
