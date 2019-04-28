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
   public GameObject smokeEmitter;
   public GameObject sparkEmitter;
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
                ChangeStatus();
                if (currentHp <= 0)
                {
                    gameObject.SetActive(false);
                    SceneManager.LoadScene("GameOver",LoadSceneMode.Additive);
                }
            }
            if (col.gameObject.tag == "Missile")
            {
                currentHp = currentHp - 50;
                ChangeStatus();
                if (currentHp <= 0)
                {
                    gameObject.SetActive(false);
                    SceneManager.LoadScene("GameOver",LoadSceneMode.Additive);
                }
            }
            if (col.gameObject.tag == "Death")
            {
                gameObject.SetActive(false);
                SceneManager.LoadScene("GameOver",LoadSceneMode.Additive);
            }
       }
       
   }
   void Regeneration ()
   {
       if (currentHp < maxHP)
       {
           currentHp = currentHp + regenerationAmount;
           ChangeStatus();
       }
   }
   public void ExplosionDamage (float Distance, int ExplosionRange, int maxExplosionDamage)
   {
       if (Distance <= ExplosionRange)
       {
       currentHp = currentHp - maxExplosionDamage;
       ChangeStatus();
       if (currentHp <= 0)
                {
                    gameObject.SetActive(false);
                    SceneManager.LoadScene("GameOver",LoadSceneMode.Additive);
                }
       }
   }
   void ChangeStatus ()
   {
       if (currentHp > 70)
       {
           sparkEmitter.SetActive(false);
           smokeEmitter.SetActive(false);
       }
       if (currentHp <= 70)
       {
           sparkEmitter.SetActive(true);
           smokeEmitter.SetActive(false);
       }
       if (currentHp <= 40 )
       {
           sparkEmitter.SetActive(true);
           smokeEmitter.SetActive(true);
       }
   }
}
