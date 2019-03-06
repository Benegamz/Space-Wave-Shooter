using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 1;
    public int acceleration = 1;
    int CurrentSpeed = 0;
    public int maxSpeed = 10000;
    public float strafingSpeed = 1;
    Rigidbody rb;
    void Start()
    {
        InvokeRepeating ("SpeedManagement",0,1f/60f);
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKey("left alt")!= true)
        {
            Cursor.visible = false;
            if (Input.GetAxis("Mouse X")<0)
            {
                Debug.Log("Mouse moved left");
                transform.Rotate(0,-1*turnSpeed*-Input.GetAxis("Mouse X"),0,Space.Self);
            }
            if (Input.GetAxis("Mouse X")>0)
            {
                Debug.Log("Mouse moved right");
                transform.Rotate(0,1*turnSpeed*Input.GetAxis("Mouse X"),0,Space.Self);
            }
            if (Input.GetAxis("Mouse Y")<0)
            {
                Debug.Log("Mouse moved down");
                transform.Rotate(-2*turnSpeed*-Input.GetAxis("Mouse Y"),0,0,Space.Self);
            }
            if (Input.GetAxis("Mouse Y")>0)
            {
                Debug.Log("Mouse moved up");
                transform.Rotate(2*turnSpeed*Input.GetAxis("Mouse Y"),0,0,Space.Self);
            }
            if (Input.GetKey("q"))
            {
                transform.Rotate(0,0,2*turnSpeed,Space.Self);
            }
            if (Input.GetKey("e"))
            {
                transform.Rotate(0,0,-2*turnSpeed,Space.Self);
            }
        }
        else
        {
            Cursor.visible = true;
        }
        if (Input.GetKey("d"))
        {
            rb.AddRelativeForce(1*strafingSpeed,0,0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddRelativeForce(-1*strafingSpeed,0,0);
        }
        rb.velocity = transform.forward * CurrentSpeed;
    }
    void SpeedManagement ()
    {
        if (Input.GetKey("w"))
        {
            if (CurrentSpeed < maxSpeed)
            {
                CurrentSpeed = CurrentSpeed+acceleration;
                Debug.Log (CurrentSpeed);
            }
        }
        if (Input.GetKey("s"))
        {
            if (CurrentSpeed > -15)
            {
                CurrentSpeed = CurrentSpeed-acceleration;
                Debug.Log (CurrentSpeed);
            }
        }
    }
}
