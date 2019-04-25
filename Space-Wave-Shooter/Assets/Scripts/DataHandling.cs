using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHandling
{
    static List <UITarget> temp = new List <UITarget>();
    public static bool IsChasedByMissile;
    public static int chasingAmount;
    public static List <bool> ChasingMissiles = new List<bool>();
    public static List <UITarget> forIdentifing = new List<UITarget>();
    public static void CheckMissile()
    {
        chasingAmount = ChasingMissiles.Count; 
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
    public static void UIMarkersRelist ()
    {
        temp.Clear();
        foreach (UITarget marker in forIdentifing)
        {
            temp.Add(marker);
        }
        forIdentifing.Clear();
        foreach (UITarget marker in temp)
        {
            if(marker.isActive == true)
            {
                UiMarkersController uiMarkersController = marker.uimarker.GetComponent<UiMarkersController>();
                uiMarkersController.Relist();
            }
        }
    }
}
