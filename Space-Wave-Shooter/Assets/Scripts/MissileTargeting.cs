using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MissileTargeting : MonoBehaviour
{
    Rigidbody rb;
    public int missileVelocity;
    public int rotationSpeed;
    GameObject currentTarget;
    float angle = 0.0f;
    GameObject[] gos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating ("MissileTargetFinding", 0, 2);
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        Destroy (gameObject,10);
    }

    void Update()
    {
        rb.velocity = transform.forward * missileVelocity;
        Quaternion targetRotation = Quaternion.LookRotation (currentTarget.transform.position - transform.position);
        float str = Mathf.Min (rotationSpeed * Time.deltaTime, 1);
        transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);

    }
    void MissileTargetFinding ()
    {
        Vector3 position = transform.position;
        float distance = Mathf.Infinity;
        foreach (GameObject go in gos)
        {

            Vector3 targRotation = Quaternion.LookRotation(go.transform.position - transform.position).eulerAngles;
            Debug.Log (targRotation.x - transform.rotation.x);
            Debug.Log (targRotation.y - transform.rotation.y);
            Debug.Log (targRotation.z - transform.rotation.z);
            
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                currentTarget = go;
                distance = curDistance;
            }
        }
    }
    void OnCollisionEnter ()
    {
        Destroy (gameObject);
    }
}
