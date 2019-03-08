using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHandling
{
    public static bool IsChasedByMissile;
    public static int chasingAmount;
    public static List <bool> ChasingMissiles = new List<bool>();
    public static void CheckMissile()
    {
        chasingAmount = ChasingMissiles.Count; 
        Debug.Log(chasingAmount);
        if (chasingAmount > 0)
        {
            IsChasedByMissile = true;
        }
        else
        {
            IsChasedByMissile = false;
        }
        ChasingMissiles.Clear();
    }
}
