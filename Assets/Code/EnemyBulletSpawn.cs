using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour
{
    public GameObject enemyProjectile;

    public Vector2 bulletDirection;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Repeat());

    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator Repeat()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            GameObject bullet = Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            bullet.GetComponent<EnemyBulletBehaviour>().dir = bulletDirection;
        }

        
    }
}
