using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMarkersController : MonoBehaviour
{
    float Canvasx;
    float Canvasy;
    Camera cam;
    Vector3 OnCameraPosition;
    Image currentMarker;
    GameObject Enemy;
    RectTransform currentRectTransform;
    public int Identifier;


    void Start()
    {
        currentRectTransform = GetComponent<RectTransform>();
        currentMarker = gameObject.GetComponent<Image>();
        foreach (UITarget enemy in DataHandling.forIdentifing)
        {
            if (enemy.classIdentifier == Identifier)
            {
                Enemy = enemy.Target;
                cam = enemy.cam;
                Canvasx = enemy.classCanvasx;
                Canvasy = enemy.classCanvasy;
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Enemy == null)
        {
            Destroy(gameObject);
        }
        OnCameraPosition = cam.WorldToViewportPoint(Enemy.transform.position);
            Vector3 OnCanvasPosition = new Vector3(OnCameraPosition.x, OnCameraPosition.y, 0);
            if (OnCameraPosition.z >= 0 && OnCameraPosition.x >= 0 && OnCameraPosition.x <= 1 && OnCameraPosition.y >= 0 && OnCameraPosition.y <= 1)
            {
                currentRectTransform = currentMarker.gameObject.GetComponent<RectTransform>();
                currentRectTransform.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Left, OnCanvasPosition.x * Canvasx - 25, 50);
                currentRectTransform.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Bottom, OnCanvasPosition.y * Canvasy - 25, 50);
                currentRectTransform.localEulerAngles = new Vector3 (0,0,0);

            }
    }
}
