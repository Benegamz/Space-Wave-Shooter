using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{   

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        float distance = Vector3.Distance(transform.position,Player.transform.position);
        if(distance <=5) {
            Fire();
            Debug.Log("In Range");
        }        
    }

    void Fire() {

    }

}
