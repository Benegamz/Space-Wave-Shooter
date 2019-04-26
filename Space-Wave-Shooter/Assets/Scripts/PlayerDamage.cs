using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
   public int maxHP = 100;
   public bool regeneration = false;
   public int regenerationAmount = 1;
   public float currentHp;
   public bool godMode = false;
   void Start()
   {
       currentHp = maxHP;
       InvokeRepeating("Regeneration",1,1);
   }
   void OnCollisionEnter (Collision col)
   {
       if (godMode == false)
       {
            if (col.gameObject.tag == "Bullet")
            {
                currentHp = currentHp - 10;
                if (currentHp <= 0)
                {
                    Destroy(gameObject);
                    SceneManager.LoadScene("GameOver",LoadSceneMode.Additive);
                }
            }
            if (col.gameObject.tag == "Missile")
            {
                currentHp = currentHp - 50;
                if (currentHp <= 0)
                {
                    Destroy(gameObject);
                    SceneManager.LoadScene("GameOver",LoadSceneMode.Additive);
                }
            }
            if (col.gameObject.tag == "Death")
            {
                Destroy(gameObject);
                SceneManager.LoadScene("GameOver",LoadSceneMode.Additive);
            }
       }
       
   }
   void Regeneration ()
   {
       if (currentHp < maxHP)
       {
           currentHp = currentHp + regenerationAmount;
       }
   }
   public void ExplosionDamage (float Distance, int ExplosionRange, int maxExplosionDamage)
   {
       if (Distance <= ExplosionRange)
       {
       currentHp = currentHp - maxExplosionDamage;
       if (currentHp <= 0)
                {
                    Destroy(gameObject);
                    SceneManager.LoadScene("GameOver",LoadSceneMode.Additive);
                }
       }
   }
}
