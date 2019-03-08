using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
   public int maxHP = 100;
   public bool regeneration = false;
   public int regenerationAmount = 1;
   public int currentHp;
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
                Debug.Log ("HP:" + currentHp);
                if (currentHp <= 0)
                {
                    Destroy(gameObject);
                    SceneManager.LoadScene("GameOver",LoadSceneMode.Additive);
                }
            }
            if (col.gameObject.tag == "Missile")
            {
                currentHp = currentHp - 50;
                Debug.Log ("HP:" + currentHp);
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
           Debug.Log ("HP:" + currentHp);
       }
   }
   public void ExplosionDamage (float Distance, int ExplosionRange, int maxExplosionDamage)
   {
       float Value = ExplosionRange / Distance;
       Debug.Log(Value);
   }
}
