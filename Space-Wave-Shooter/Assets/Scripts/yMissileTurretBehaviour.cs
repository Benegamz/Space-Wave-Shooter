using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yMissileTurretBehaviour : MonoBehaviour
{   
    public GameObject targeter;
    public GameObject Player;
    public GameObject Bullet;
    public float radius = 5;
    public float preFire = 0;
    public GameObject[] FirePoints;
    public float strength = 0.5f;
    float cooldownTimer = 0f;
    public float FireCooldown = 1f;
    public float missileAmount = 50;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Cooldown",preFire ,0.1f);
    }

    // Update is called once per frame
    void Update()
    {   
        Player = GameObject.Find("Player");
        targeter.transform.LookAt(Player.transform);
        Vector3 targeterEulerRotation = targeter.transform.rotation.eulerAngles;
        Vector3 currentEulerRotation = transform.rotation.eulerAngles;
        float yDifference = (targeterEulerRotation.z - currentEulerRotation.z);
        float step = yDifference * strength * Time.deltaTime;
        transform.Rotate(0 , 0, step);




        float distance = Vector3.Distance(transform.position,Player.transform.position);
        if (distance <= radius) {
            Debug.DrawLine(transform.position,Player.transform.position,Color.red);
            Fire();
        }
    }

    void Fire() {
        if (missileAmount > 0)
        {
            if (cooldownTimer <= 0) {
                foreach(GameObject point in FirePoints) {
                    Instantiate(Bullet, point.transform.position + (point.transform.forward * 20), point.transform.rotation);
                    Debug.Log("Fired");
                    cooldownTimer = FireCooldown;
                    missileAmount--;
                }
            }
        }
    }

    void Cooldown() {
        cooldownTimer--;
    }
}
