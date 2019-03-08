using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerDamage playerDamage;
    public GunBehaviour missileStatus;
    public Text speedText;
    public Text hpText;
    public Text missileText;

    // Update is called once per frame
    void Update()
    {
        speedText.text = "Speed:" + playerMovement.CurrentSpeed;
        hpText.text = "Hp:" + playerDamage.currentHp;
        missileText.text = "Missiles:" + missileStatus.missileAmount;
    }
    void Start()
    {
        Debug.Log (playerDamage);
    }
}
