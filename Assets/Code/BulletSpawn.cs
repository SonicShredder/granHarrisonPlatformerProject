using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject projectile;

    public AudioClip PlayerLaser;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            AudioManager.PlaySoundEffect(PlayerLaser);
        }
    }
}
