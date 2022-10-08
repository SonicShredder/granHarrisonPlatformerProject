using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerBehaviour : MonoBehaviour
{
    public Transform playerTrans;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = playerTrans.position;

        transform.position = Vector2.Lerp(transform.position,playerPos,Time.deltaTime * 3);

        transform.position += new Vector3(0, 0, -10);
    }
}
