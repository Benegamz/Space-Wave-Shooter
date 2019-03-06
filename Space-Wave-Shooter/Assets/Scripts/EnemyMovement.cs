using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    public GameObject player;

    void Start()
    {

    }

    void Update()
    {

        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        
        Debug.DrawRay(transform.position, direction, Color.red);

    }
}