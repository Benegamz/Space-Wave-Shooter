using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    Rigidbody rb;
    public int bulletSpeed = 600;

    void Start()
    {
        Destroy(gameObject, 60);
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = transform.forward * bulletSpeed;
    }
    void OnCollisionEnter ()
    {
        Destroy (gameObject);
    }
}
