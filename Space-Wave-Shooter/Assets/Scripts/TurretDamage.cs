using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDamage : MonoBehaviour
{

    public int currentHp = 50;
    public GameObject explosion;
    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            currentHp = currentHp - 10;
            Debug.Log("TurretHp" + currentHp);
            if (currentHp <= 0)
            {
                Instantiate (explosion, transform.position, Quaternion.identity);
                Destroy (gameObject);
            }
        }
        if (col.gameObject.tag == "Missile")
        {
            currentHp = currentHp - 50;
            Debug.Log("TurretHp" + currentHp);
            if (currentHp <= 0)
            {
                Instantiate (explosion, transform.position, Quaternion.identity);
                Destroy (gameObject);
            }
        }
    }
}
