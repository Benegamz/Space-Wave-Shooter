using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetAxis("Mouse X")<0)
        {
            Debug.Log("Mouse moved left");
            transform.Rotate(0,-1,0,Space.Self);
        }
        if (Input.GetAxis("Mouse X")>0)
        {
            Debug.Log("Mouse moved right");
            transform.Rotate(0,1,0,Space.Self);
        }
        if (Input.GetAxis("Mouse Y")<0)
        {
            Debug.Log("Mouse moved down");
            transform.Rotate(-1,0,0,Space.Self);
        }
        if (Input.GetAxis("Mouse Y")>0)
        {
            Debug.Log("Mouse moved up");
            transform.Rotate(1,0,0,Space.Self);
        }
        if (Input.GetKey("q"))
        {
            transform.Rotate(0,0,1);
        }
        if (Input.GetKey("e"))
        {
            transform.Rotate(0,0,-1);
        }
    }
}
