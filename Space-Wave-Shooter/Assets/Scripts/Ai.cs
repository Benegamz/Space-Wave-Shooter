using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{   
    private GameObject player;
    private Rigidbody rb;

    public GameObject point;

    public float movementSpeed;
    public float rotationSpeed;
    public float checkingAngle;
    public float detectionRange;
    public float stopDistance;

    void Start()
    {   
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {   
        Pathfinding();
    }

    void Move()
    {
        rb.velocity = transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
    }

    void Stop()
    {
        rb.velocity = Vector3.zero; 
    }

    void Turn() 
    {
        Vector3 direction = player.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, direction, rotationSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void Pathfinding() 
    {
        Vector3 direction = player.transform.position - transform.position;
        float distance = Vector3.Distance(transform.position, player.transform.position);

        Debug.DrawRay(transform.position, direction, Color.red);

        Debug.DrawRay(point.transform.position, transform.TransformDirection(Vector3.forward * checkingAngle + new Vector3(1,0,0)) * detectionRange, Color.cyan);
        Debug.DrawRay(point.transform.position, transform.TransformDirection(Vector3.forward * checkingAngle + new Vector3(-1,0,0)) * detectionRange, Color.cyan);
        Debug.DrawRay(point.transform.position, transform.TransformDirection(Vector3.forward * checkingAngle + new Vector3(0,1,0)) * detectionRange, Color.cyan);
        Debug.DrawRay(point.transform.position, transform.TransformDirection(Vector3.forward * checkingAngle + new Vector3(0,-1,0)) * detectionRange, Color.cyan);
       
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * detectionRange, Color.blue);

        RaycastHit hit;

        if (distance <= stopDistance){
            Stop();
            Turn();
        }
        else if(Physics.Raycast(point.transform.position, transform.TransformDirection(Vector3.forward * checkingAngle + new Vector3(1,0,0)), out hit, detectionRange)) {
            if(hit.collider.tag != "Player") {
                Move();
            }
            else {
                Move();
                Turn();
            }
        }
        else if(Physics.Raycast(point.transform.position, transform.TransformDirection(Vector3.forward * checkingAngle + new Vector3(-1,0,0)), out hit, detectionRange)) {
            if(hit.collider.tag != "Player") {
                Move();
            }
            else {
                Move();
                Turn();
            }
        }
        else if(Physics.Raycast(point.transform.position, transform.TransformDirection(Vector3.forward * checkingAngle + new Vector3(0,1,0)), out hit, detectionRange)) {
            if(hit.collider.tag != "Player") {
                Move();
            }
            else {
                Move();
                Turn();
            }
        }
        else if(Physics.Raycast(point.transform.position, transform.TransformDirection(Vector3.forward * checkingAngle + new Vector3(0,-1,0)), out hit, detectionRange)) {
            if(hit.collider.tag != "Player") {
                Move();
            }
            else {
                Move();
                Turn();
            }
        }
        else {
            Move();
            Turn();
        }      
    }
}