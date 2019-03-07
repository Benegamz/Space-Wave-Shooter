using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("PlayerPrefab");

    }

    void Update()
    {

        Vector3 direction = player.transform.position - transform.position;
        
        Debug.DrawRay(transform.position,direction, Color.red);
        

    }
}