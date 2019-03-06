using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 1;
    public int acceleration = 100;
    public int maxSpeed = 1000;

    void Start()
    {
       
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
    }
}
