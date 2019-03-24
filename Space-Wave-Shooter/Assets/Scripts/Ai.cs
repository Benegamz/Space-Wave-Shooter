using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{   
    public GameObject player;

    public float movementSpeed;
    public float rotaionalDamp;
    Rigidbody rb;
    public float rayCastOffset;
    public float detectionDistance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Pathfinding();
        Move();
    }

    void Move() {
        rb.velocity = transform.forward * movementSpeed;
    }

    void Turn() {
        Vector3 pos = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation,rotation,rotaionalDamp * Time.deltaTime);
    }  

    void Pathfinding() {

        Vector3 direction = player.transform.position - transform.position;
        Debug.DrawRay(transform.position, direction, Color.red);

        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero;

        Vector3 left = transform.position - transform.right * rayCastOffset;
        Vector3 right = transform.position + transform.right * rayCastOffset;
        Vector3 up = transform.position + transform.up * rayCastOffset;
        Vector3 down = transform.position - transform.up * rayCastOffset;

        Debug.DrawRay(left, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(right, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(up, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(down, transform.forward * detectionDistance, Color.cyan);

        if(Physics.Raycast(left,transform.forward,out hit,detectionDistance))
            raycastOffset += Vector3.right;
        else if(Physics.Raycast(right,transform.forward,out hit,detectionDistance))
            raycastOffset -= Vector3.right;

        if(Physics.Raycast(up,transform.forward,out hit,detectionDistance))
            raycastOffset -= Vector3.up;
        else if(Physics.Raycast(down,transform.forward,out hit,detectionDistance))
            raycastOffset += Vector3.up;

        if(raycastOffset != Vector3.zero)
            transform.Rotate(raycastOffset * Time.deltaTime);
        else
            Turn();
    }
}