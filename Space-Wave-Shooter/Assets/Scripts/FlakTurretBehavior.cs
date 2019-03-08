using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakTurretBehavior : MonoBehaviour
{   
    public GameObject Player;
    public GameObject Bullet;
    GameObject CurrentBullet;
    FlakBulletBehaviour flakBulletBehaviour;
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
        Quaternion targetRotation = Quaternion.LookRotation (Player.transform.position - transform.position);
        float str = Mathf.Min (strength * Time.deltaTime, 1);
        transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);




        float distance = Vector3.Distance(transform.position,Player.transform.position);
        if (distance <= radius) {
            Debug.DrawLine(transform.position,Player.transform.position,Color.red);
            Fire();
        }
    }

    void Fire() {
        if (cooldownTimer <= 0) {
            foreach(GameObject point in FirePoints) {
                CurrentBullet = Instantiate(Bullet, point.transform.position + (point.transform.forward * 20), point.transform.rotation);
                flakBulletBehaviour = CurrentBullet.GetComponent<FlakBulletBehaviour>();
                flakBulletBehaviour.target = Player;
                cooldownTimer = FireCooldown;
            }
        }
    }

    void Cooldown() {
        cooldownTimer--;
    }
}
