using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMissileTargeting : MonoBehaviour
{
    Rigidbody rb;
    public GameObject targeter;
    public int missileVelocity;
    public int rotationSpeed;
    public GameObject explosion;
    GameObject currentTarget;
    GameObject[] gos;
    bool followingPlayer = false;
    public int maxTargetingRotationDifference = 90;
    int positivemaxTargetingRotation;
    int negativemaxTargetingRotation;
    void Start()
    {
        positivemaxTargetingRotation = 180 + maxTargetingRotationDifference;
        negativemaxTargetingRotation = 180 - maxTargetingRotationDifference;
        Invoke ("Explode", 10);
        rb = GetComponent<Rigidbody>();
        InvokeRepeating ("MissileTargetFinding", 0, 0.1f);
        gos = GameObject.FindGameObjectsWithTag("Friendly");
        Destroy (gameObject,10);


        currentTarget = null;
        Vector3 position = transform.position;
        float distance = Mathf.Infinity;
        foreach (GameObject go in gos)
        {
            targeter.transform.LookAt(go.transform);
            Vector3 missileEulerRotation = transform.rotation.eulerAngles;
            Vector3 targeterEulerRotation = targeter.transform.rotation.eulerAngles;
            Vector3 rotationDifference = new Vector3 (Mathf.Abs(targeterEulerRotation.x - missileEulerRotation.x),Mathf.Abs(targeterEulerRotation.y - missileEulerRotation.y),Mathf.Abs(targeterEulerRotation.z - missileEulerRotation.z)); 
            if (rotationDifference.x < negativemaxTargetingRotation | rotationDifference.x > positivemaxTargetingRotation)
            {
                if (rotationDifference.y < negativemaxTargetingRotation | rotationDifference.y > positivemaxTargetingRotation)
                {
                    Vector3 diff = go.transform.position - position;
                    float curDistance = diff.sqrMagnitude;
                    if (curDistance < distance)
                    {
                        currentTarget = go;
                        distance = curDistance;
                    }
                }
            }
        }
    }

    void Update()
    {
        rb.velocity = transform.forward * missileVelocity;
        
        try {
            float predictedImpactTime = (Vector3.Distance(currentTarget.transform.position, transform.position) / (rb.velocity.x + rb.velocity.y + rb.velocity.z));
            Vector3 currentTargetVelocity = currentTarget.GetComponent<Rigidbody>().velocity;
            float targetPredictionx = currentTarget.transform.position.x + (currentTargetVelocity.x * predictedImpactTime);
            float targetPredictiony = currentTarget.transform.position.y + (currentTargetVelocity.y * predictedImpactTime);
            float targetPredictionz = currentTarget.transform.position.z + (currentTargetVelocity.z * predictedImpactTime);
            Vector3 targetPrediction = new Vector3 (targetPredictionx, targetPredictiony, targetPredictionz);
            Quaternion targetRotation = Quaternion.LookRotation (targetPrediction - transform.position);
            float str = Mathf.Min (rotationSpeed * Time.deltaTime, 1);
            transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);
        } catch (Exception e) {}
      
      
       

        if (currentTarget = GameObject.Find("SpaceFighterv3"))
        {
            followingPlayer = true;
            DataHandling.ChasingMissiles.Add(followingPlayer);
        }
        else
        {
            followingPlayer = false;
        }
    }
    void MissileTargetFinding ()
    {
        
        try {
            targeter.transform.LookAt(currentTarget.transform);
        } catch (Exception e) {}
        
        Vector3 missileEulerRotation = transform.rotation.eulerAngles;
        Vector3 targeterEulerRotation = targeter.transform.rotation.eulerAngles;
        Vector3 rotationDifference = new Vector3 (Mathf.Abs(targeterEulerRotation.x - missileEulerRotation.x),Mathf.Abs(targeterEulerRotation.y - missileEulerRotation.y),Mathf.Abs(targeterEulerRotation.z - missileEulerRotation.z)); 
        if (rotationDifference.x < negativemaxTargetingRotation | rotationDifference.x > positivemaxTargetingRotation)
        {
            if (rotationDifference.y < negativemaxTargetingRotation | rotationDifference.y > positivemaxTargetingRotation)
            {
                
            }
            else
            {
                currentTarget = null;
            }
        }
        else
        {
            currentTarget = null;
        }
        
    }
    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag != "Bullet")
        {
            Instantiate (explosion, transform.position, Quaternion.identity);
            Destroy (gameObject);
        }
    }
    void Explode ()
    {
        Instantiate (explosion, transform.position, Quaternion.identity);
        Destroy (gameObject);
    }
}
