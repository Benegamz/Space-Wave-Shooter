using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 1;
    public int acceleration = 1;
    public int CurrentSpeed = 0;
    public int maxSpeed = 10000;
    public float strafingSpeed = 1;
    public bool alternateKeymapping = false;
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
            Cursor.lockState = CursorLockMode.Locked;
            if (alternateKeymapping == false)
            {
                //mouse left
                if (Input.GetAxis("Mouse X")<0)
                {
                    transform.Rotate(0,-0.5f*turnSpeed*-Input.GetAxis("Mouse X"),0,Space.Self);
                }
                //mouse right
                if (Input.GetAxis("Mouse X")>0)
                {
                    transform.Rotate(0,0.5f*turnSpeed*Input.GetAxis("Mouse X"),0,Space.Self);
                }
                //mouse down
                if (Input.GetAxis("Mouse Y")<0)
                {
                    transform.Rotate(-2*turnSpeed*-Input.GetAxis("Mouse Y"),0,0,Space.Self);
                }
                //mouse up
                if (Input.GetAxis("Mouse Y")>0)
                {
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
            if (alternateKeymapping)
            {
                if (Input.GetKey("w"))
                {
                    transform.Rotate(2*turnSpeed,0,0,Space.Self);
                }
                if (Input.GetKey("s"))
                {
                    transform.Rotate(-2*turnSpeed,0,0,Space.Self);
                }
                if (Input.GetKey("a"))
                {
                    transform.Rotate(0,-0.5f*turnSpeed,0,Space.Self);
                }
                if (Input.GetKey("d"))
                {
                    transform.Rotate(0,0.5f*turnSpeed,0,Space.Self);
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
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        rb.velocity = transform.forward * CurrentSpeed;
    }
    void SpeedManagement ()
    {
        if (alternateKeymapping == false)
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
        if (alternateKeymapping)
        {
            if (Input.GetKey("left shift"))
            {
                if (CurrentSpeed < maxSpeed)
                {
                    CurrentSpeed = CurrentSpeed+acceleration;
                    Debug.Log ("Speed" + CurrentSpeed);
                }
            }
            if (Input.GetKey("left ctrl"))
            {
                if (CurrentSpeed > -15)
                {
                    CurrentSpeed = CurrentSpeed-acceleration;
                    Debug.Log ("Speed" + CurrentSpeed);
                }
            }
        }
    }
}
