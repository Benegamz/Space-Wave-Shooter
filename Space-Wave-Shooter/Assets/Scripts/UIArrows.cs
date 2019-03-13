using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UITarget
    {
        public GameObject Target;
        public Image uimarker;
        public Camera cam;
        public int classIdentifier;
    } 
public class UIArrows : MonoBehaviour
{

    List<GameObject> EnemiesList = new List<GameObject>();
    List<UITarget> uIMarkers = new List<UITarget>();
    public Camera cam;
    public Canvas Parent;
    Vector3 OnCameraPosition;
    public Image uIMarker;
    Image currentMarker;
    RectTransform currentRectTransform;
    int counter;

    void Start()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in Enemies)
        {
            EnemiesList.Add(enemy);
        }




        foreach(GameObject enemy in EnemiesList)
        {
            OnCameraPosition = cam.WorldToViewportPoint(enemy.transform.position);
            Vector3 OnCanvasPosition = new Vector3(OnCameraPosition.x, OnCameraPosition.y, 0);
            if (OnCameraPosition.x >= 0 && OnCameraPosition.x <= 1 && OnCameraPosition.y >= 0 && OnCameraPosition.y <= 1)
            {
                counter++;
                currentMarker = (Instantiate(uIMarker, Parent.transform, false));
                currentMarker.GetComponent<UiMarkersController>().Identifier = counter;
                UITarget currentUITarget = new UITarget();
                currentUITarget.uimarker = currentMarker;
                currentUITarget.Target = enemy;
                currentUITarget.cam = cam;
                currentUITarget.classIdentifier = counter;
                uIMarkers.Add(currentUITarget);
                currentRectTransform = currentMarker.gameObject.GetComponent<RectTransform>();
                currentRectTransform.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Left, OnCanvasPosition.x * 1425 - 25, 50);
                currentRectTransform.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Bottom, OnCanvasPosition.y * 636 - 25, 50);
                currentRectTransform.localEulerAngles = new Vector3 (0,0,0);

            }
        }
        DataHandling.forIdentifing = uIMarkers;
    }
}
