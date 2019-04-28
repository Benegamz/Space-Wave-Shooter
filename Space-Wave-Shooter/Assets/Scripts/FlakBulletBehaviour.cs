using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakBulletBehaviour : MonoBehaviour
{
    public GameObject target;
    public int explosionRange;
    public int maxExplosionDamage;
    public int bulletSpeed;
    float startTargetDistance;
    float currentTargetDistance;
    float explosionTimer;
    public GameObject explosion;
    Rigidbody rigidbody;
    PlayerDamage playerDamage;
    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * bulletSpeed;
        startTargetDistance = Vector3.Distance(target.transform.position, transform.position);
        explosionTimer = startTargetDistance / (rigidbody.velocity.x + rigidbody.velocity.y + rigidbody.velocity.z);



        InvokeRepeating("Explosion",explosionTimer ,0 );
    }
    void Update()
    {
        rigidbody.velocity = transform.forward * bulletSpeed;
    }


    void Explosion()
    {
        
        playerDamage = target.GetComponent<PlayerDamage>();
        currentTargetDistance = Vector3.Distance(target.transform.position, transform.position);
        playerDamage.ExplosionDamage(currentTargetDistance, explosionRange, maxExplosionDamage);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }
    void OnCollisionEnter()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
