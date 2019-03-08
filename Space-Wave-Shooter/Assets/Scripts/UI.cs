using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerDamage playerDamage;
    public GunBehaviour missileStatus;
    public TextMeshProUGUI speedTextMesh;
    public TextMeshProUGUI hpTextMesh;
    public TextMeshProUGUI missileTextMesh;
    public TextMeshProUGUI missileWarningTextMesh;


    void Start()
    {
        
    }
    void Update()
    {
        DataHandling.CheckMissile();
        speedTextMesh.text = "Speed:" + playerMovement.CurrentSpeed;
        hpTextMesh.text = "Hp:" + playerDamage.currentHp;
        missileTextMesh.text = "Missiles:" + missileStatus.missileAmount;
        if (DataHandling.IsChasedByMissile)
        {
            missileWarningTextMesh.text = "WARNING";
        }
        else
        {
            missileWarningTextMesh.text = "";
        }
    }
}
