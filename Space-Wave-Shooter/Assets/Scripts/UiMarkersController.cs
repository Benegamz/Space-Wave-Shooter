using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMarkersController : MonoBehaviour
{
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
            if (OnCameraPosition.x >= 0 && OnCameraPosition.x <= 1 && OnCameraPosition.y >= 0 && OnCameraPosition.y <= 1)
            {
                currentRectTransform = currentMarker.gameObject.GetComponent<RectTransform>();
                currentRectTransform.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Left, OnCanvasPosition.x * 1326 - 25, 50);
                currentRectTransform.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Bottom, OnCanvasPosition.y * 636 - 25, 50);
                currentRectTransform.localEulerAngles = new Vector3 (0,0,0);

            }
    }
}
