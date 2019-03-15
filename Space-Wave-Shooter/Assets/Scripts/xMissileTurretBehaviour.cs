using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xMissileTurretBehaviour : MonoBehaviour
{   
    public GameObject targeter;
    public GameObject Player;
    public GameObject Bullet;
    public float radius = 5;
    public GameObject[] FirePoints;
    public float strength = 0.5f;
    float cooldownTimer = 0f;
    public float FireCooldown = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Cooldown",0,0.1f);
    }

    // Update is called once per frame
    void Update()
    {   
        Player = GameObject.Find("SpaceFighterv3");
        targeter.transform.LookAt(Player.transform);
        Vector3 targeterEulerRotation = targeter.transform.rotation.eulerAngles;
        Vector3 currentEulerRotation = transform.rotation.eulerAngles;
        float xDifference = (targeterEulerRotation.y - currentEulerRotation.y);
        float step = xDifference * strength * Time.deltaTime;
        transform.Rotate(0, step, 0);




        float distance = Vector3.Distance(transform.position,Player.transform.position);
        if (distance <= radius) {
            Debug.DrawLine(transform.position,Player.transform.position,Color.red);
            Fire();
        }
    }

    void Fire() {
        if (cooldownTimer <= 0) {
            foreach(GameObject point in FirePoints) {
                Instantiate(Bullet, point.transform.position + (point.transform.forward * 20), point.transform.rotation);
                cooldownTimer = FireCooldown;
            }
        }
    }

    void Cooldown() {
        cooldownTimer--;
    }
}
