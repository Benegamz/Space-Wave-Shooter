using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDamage : MonoBehaviour
{

    public int currentHp = 50;
    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            currentHp = currentHp - 10;
            if (currentHp <= 0)
            {
                Destroy (gameObject);
            }
        }
    }
}
