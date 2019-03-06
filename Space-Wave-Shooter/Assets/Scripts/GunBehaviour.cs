using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public GameObject Bullet;
    float cooldownTimer = 0f;
    void Start()
    {
     InvokeRepeating("Cooldown", 0, 0.1f);   
    }

    
    void Update()
    {
        if (cooldownTimer <= 0)
        {
            if (Input.GetKey("mouse 0"))
            {
                Instantiate(Bullet, transform.position + (transform.forward * 10), transform.rotation);
                cooldownTimer = 1.5f;
            }
        }
    }
    void Cooldown ()
    {
        cooldownTimer--;
    }
    
}
