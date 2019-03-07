using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    public GameObject player;
    public GameObject point;
    public float rotationSpeed;
    public float flySpeed;

    Rigidbody rb;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        Vector3 direction = player.transform.position - transform.position;
        
        Debug.DrawRay(transform.position, direction, Color.red);
        
        float step = rotationSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward,direction,step,0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);

        RaycastHit hit;
        Ray playerRay = new Ray(point.transform.position, transform.TransformDirection(Vector3.forward));
        Debug.DrawRay(point.transform.position,transform.TransformDirection(Vector3.forward) * 50,Color.blue);

        if(Physics.Raycast(playerRay,out hit)) {
            if(hit.collider.tag == "Player") {
                rb.velocity = transform.TransformDirection(Vector3.forward) * flySpeed * Time.deltaTime;
            }
        }
    }
}