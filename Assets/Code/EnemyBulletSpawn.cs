using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour
{
    public GameObject EnemyProjectile;

    public Vector2 BulletDirection;//f
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
            GameObject bullet = Instantiate(EnemyProjectile, transform.position, Quaternion.identity);
            bullet.GetComponent<EnemyBulletBehaviour>().Dir = BulletDirection;
        }

        
    }
}
