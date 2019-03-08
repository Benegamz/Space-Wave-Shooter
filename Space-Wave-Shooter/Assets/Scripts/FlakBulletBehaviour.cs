using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakBulletBehaviour : MonoBehaviour
{
    public GameObject target;
    float targetDistance;
    float explosionTimer;
    Rigidbody rigidbody;
    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Vector3 difference = target.transform.position - transform.position;
        targetDistance = difference.sqrMagnitude;
        explosionTimer = targetDistance / (rigidbody.velocity.x + rigidbody.velocity.y + rigidbody.velocity.z);
        InvokeRepeating("Explosion",explosionTimer ,0 );
    }


    void Explosion()
    {
        target.
    }
}
