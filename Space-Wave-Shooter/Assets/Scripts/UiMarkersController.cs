using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMarkersController : MonoBehaviour
{
    UITarget forRelist;
    float Canvasx;
    float Canvasy;
    Camera cam;
    Vector3 OnCameraPosition;
    public Vector3 OnCanvasPosition;
    Image currentMarker;
    Sprite markerImage;
    Sprite emptyUISprite;
    Sprite redUISprite;
    Sprite currentUISprite;
    GameObject Enemy;
    RectTransform currentRectTransform;
    public int Identifier;


    void Start()
    {
        currentRectTransform = GetComponent<RectTransform>();
        currentMarker = gameObject.GetComponent<Image>();
        markerImage = currentMarker.sprite;
        currentUISprite = markerImage;
        foreach (UITarget enemy in DataHandling.forIdentifing)
        {
            if (enemy.classIdentifier == Identifier)
            {
                markerImage = enemy.standardSprite;
                currentMarker.sprite = markerImage;
                forRelist = enemy; 
                Enemy = enemy.Target;
                cam = enemy.cam;
                Canvasx = enemy.classCanvasx;
                Canvasy = enemy.classCanvasy;
                emptyUISprite = enemy.empty;
                redUISprite = enemy.red;
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Enemy == null)
        {
            foreach (UITarget enemy in DataHandling.forIdentifing)
            {
                if(enemy.classIdentifier == Identifier)
                {
                    enemy.isActive = false;
                }
            }
            DataHandling.UIMarkersRelist();
            Destroy(gameObject);
        }
        OnCameraPosition = cam.WorldToViewportPoint(Enemy.transform.position);
            Vector3 OnCanvasPosition = new Vector3(OnCameraPosition.x, OnCameraPosition.y, 0);
            if (OnCameraPosition.z >= 0 && OnCameraPosition.x >= 0 && OnCameraPosition.x <= 1 && OnCameraPosition.y >= 0 && OnCameraPosition.y <= 1)
            {
                currentMarker.sprite = currentUISprite;
                currentRectTransform.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Left, OnCanvasPosition.x * Canvasx - 25, 50);
                currentRectTransform.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Bottom, OnCanvasPosition.y * Canvasy - 25, 50);
                currentRectTransform.localEulerAngles = new Vector3 (0,0,0);

            }
            else
            {
                currentMarker.sprite = emptyUISprite;
            }
    }
    public float GetXPos ()
    {
        return cam.WorldToViewportPoint(Enemy.transform.position).x;
    }
    public float GetYPos ()
    {   
        return cam.WorldToViewportPoint(Enemy.transform.position).y;
    }
    public void Relist ()
    {
        DataHandling.forIdentifing.Add(forRelist);
    }
    public void SwitchSprites ()
    {
        if (currentUISprite == markerImage)
        {
            currentUISprite = redUISprite;
        }
        else
        {
            currentUISprite = markerImage;
        }
    }
}
