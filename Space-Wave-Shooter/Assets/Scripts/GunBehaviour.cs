using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public GameObject Bullet;
    int cooldownTimer = 0;
    public int FireCooldown = 2;
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
                Instantiate(Bullet, transform.position + (transform.forward * 20), transform.rotation);
                cooldownTimer = FireCooldown;
            }
        }
    }
    void Cooldown ()
    {
        cooldownTimer--;
    }
    
}
