using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    public GameObject player;

    public float rotationSpeed;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {

        Vector3 direction = player.transform.position - transform.position;
        
        Debug.DrawRay(transform.position, direction, Color.red);
        
        float step = rotationSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward,direction,step,0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);

        RaycastHit hit;
        Ray playerRay = new Ray(transform.position, Vector3.forward);
        Debug.DrawRay(transform.position,Vector3.forward * 100,Color.blue);

        if(Physics.Raycast(playerRay,out hit)) {
            if(hit.collider.tag == "Player") {
                Debug.Log("Able to move");
            }
            else {
                Debug.Log("Not Player");
            }
        }
        else {
            Debug.Log("Unable to move");
        }
    }
}