using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour
{
    public GameObject enemyProjectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("Reapeat", 1, 1);
    }

    void Repeat()
    {
        Instantiate(enemyProjectile, transform.position, Quaternion.identity);
    }
}
