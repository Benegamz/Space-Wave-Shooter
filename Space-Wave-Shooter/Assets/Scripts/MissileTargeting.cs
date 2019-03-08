using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MissileTargeting : MonoBehaviour
{
    Rigidbody rb;
    public GameObject targeter;
    public int missileVelocity;
    public int rotationSpeed;
    GameObject currentTarget;
    GameObject[] gos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating ("MissileTargetFinding", 0, 0.1f);
        gos = GameObject.FindGameObjectsWithTag("Enemy");
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
            if (rotationDifference.x < 55 | rotationDifference.x > 305)
            {
                if (rotationDifference.y < 55 | rotationDifference.y > 305)
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
        float predictedImpactTime = (Vector3.Distance(currentTarget.transform.position, transform.position) / (rb.velocity.x + rb.velocity.y + rb.velocity.z));
        Vector3 currentTargetVelocity = currentTarget.GetComponent<Rigidbody>().velocity;
        float targetPredictionx = currentTarget.transform.position.x + (currentTargetVelocity.x * predictedImpactTime);
        float targetPredictiony = currentTarget.transform.position.y + (currentTargetVelocity.y * predictedImpactTime);
        float targetPredictionz = currentTarget.transform.position.z + (currentTargetVelocity.z * predictedImpactTime);
        Vector3 targetPrediction = new Vector3 (targetPredictionx, targetPredictiony, targetPredictionz);
        Quaternion targetRotation = Quaternion.LookRotation (targetPrediction - transform.position);
        float str = Mathf.Min (rotationSpeed * Time.deltaTime, 1);
        transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);

    }
    void MissileTargetFinding ()
    {
        
        targeter.transform.LookAt(currentTarget.transform);
        Vector3 missileEulerRotation = transform.rotation.eulerAngles;
        Vector3 targeterEulerRotation = targeter.transform.rotation.eulerAngles;
        Vector3 rotationDifference = new Vector3 (Mathf.Abs(targeterEulerRotation.x - missileEulerRotation.x),Mathf.Abs(targeterEulerRotation.y - missileEulerRotation.y),Mathf.Abs(targeterEulerRotation.z - missileEulerRotation.z)); 
        if (rotationDifference.x < 55 | rotationDifference.x > 305)
        {
            if (rotationDifference.y < 55 | rotationDifference.y > 305)
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
        Destroy (gameObject);
        }
    }
}
