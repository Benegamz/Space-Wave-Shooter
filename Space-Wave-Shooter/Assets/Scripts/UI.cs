using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerDamage playerDamage;
    public Text speedText;
    public Text hpText;

    // Update is called once per frame
    void Update()
    {
        speedText.text = "Speed:" + playerMovement.CurrentSpeed;
        hpText.text = "Hp:" + playerDamage.currentHp;
    }
}
