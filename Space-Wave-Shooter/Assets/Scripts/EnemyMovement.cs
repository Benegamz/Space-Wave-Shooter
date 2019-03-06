using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    public GameObject player;

    Transform enemyTR;

    void Start()
    {
        Transform enemyTR = GetComponent<Transform>();

    }

    void Update()
    {
        Vector3 playerPos = player.transform.position;

        Vector3 direction = player.transform.position - transform.position;
        
        Debug.DrawLine(transform.position,player.transform.position, Color.red);

    }
}
