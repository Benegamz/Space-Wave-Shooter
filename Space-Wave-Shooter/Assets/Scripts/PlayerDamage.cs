using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
   public int maxHP = 100;
   public bool regeneration = false;
   public int regenerationAmount = 1;
   int currentHp;
   public bool godMode = false;
   void Start()
   {
       currentHp = maxHP;
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
                    SceneManager.LoadScene("GameOver");
                }
            }
            else
            {
                SceneManager.LoadScene("GameOver");
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
}
