using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    public GameObject player;

    public float speed;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {

        Vector3 direction = player.transform.position - transform.position;
        
        Debug.DrawRay(transform.position, direction, Color.red);
        
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward,direction,step,0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);
    }
}