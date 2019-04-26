using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TargetingDistance
    {
        public float distance;
        public GameObject ForTargeting;
        public Image targetMarker;
    }


public class UITarget
    {
        public bool isActive;
        public GameObject Target;
        public Image uimarker;
        public Camera cam;
        public int classIdentifier;
        public float classCanvasx;
        public float classCanvasy;
        public Sprite standardSprite;
        public Sprite empty;
        public Sprite red;
    } 
public class UIArrows : MonoBehaviour
{
    Image previousMarker;
    List <TargetingDistance> Distances = new List <TargetingDistance>();
    List<GameObject> EnemiesList = new List<GameObject>();
    List<UITarget> uIMarkers = new List<UITarget>();
    public Camera cam;
    public Canvas Parent;
    Vector3 OnCameraPosition;
    public Image uIMarker;
    public Sprite normal;
    public Sprite emptySprite;
    public Sprite redSprite;
    Image currentMarker;
    RectTransform currentRectTransform;
    int counter;
    float Canvasx;
    float Canvasy;

    void Start()
    {
        Canvasx = Parent.GetComponent<RectTransform>().rect.width;
        Canvasy = Parent.GetComponent<RectTransform>().rect.height;


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
                currentUITarget.isActive = true;
                currentUITarget.standardSprite = normal;
                currentUITarget.uimarker = currentMarker;
                currentUITarget.empty = emptySprite;
                currentUITarget.red = redSprite;
                currentUITarget.Target = enemy;
                currentUITarget.cam = cam;
                currentUITarget.classCanvasx = Canvasx;
                currentUITarget.classCanvasy = Canvasy;
                currentUITarget.classIdentifier = counter;
                uIMarkers.Add(currentUITarget);
                currentRectTransform = currentMarker.gameObject.GetComponent<RectTransform>();
                currentRectTransform.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Left, OnCanvasPosition.x * Canvasx - 25, 50);
                currentRectTransform.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Bottom, OnCanvasPosition.y * Canvasy - 25, 50);
                currentRectTransform.localEulerAngles = new Vector3 (0,0,0);

            }
        }
        DataHandling.forIdentifing = uIMarkers;
    }
    void Update ()
    {
        Image closestMarker = GetClosestToCenter().targetMarker;
        if(previousMarker == null)
        {
            closestMarker.GetComponent<UiMarkersController>().SwitchSprites();
            previousMarker = closestMarker;
        }
        else if (closestMarker.GetComponent<UiMarkersController>().Identifier != previousMarker.GetComponent<UiMarkersController>().Identifier)
        {
            closestMarker.GetComponent<UiMarkersController>().SwitchSprites();
            previousMarker.GetComponent<UiMarkersController>().SwitchSprites();
            previousMarker = closestMarker;
        }
    }
    int CompareByDistance(TargetingDistance x, TargetingDistance y)
    {
        if (x.distance == null)
        {
            if (y.distance == null)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        else
        {
            if (y.distance == null)
            {
                return 1;
            }
            else
            {
                if (x.distance > y.distance)
                {
                    return 1;
                }
                else if (x.distance < y.distance)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
    public TargetingDistance GetClosestToCenter ()
    {
        Distances.Clear();
        foreach (UITarget uITarget in DataHandling.forIdentifing)
        {
            UiMarkersController controller = uITarget.uimarker.GetComponent<UiMarkersController>();
            float xPos = controller.GetXPos();
            float yPos = controller.GetYPos();
            TargetingDistance targetingDistance = new TargetingDistance();
            targetingDistance.distance = Pythagoras(xPos, yPos);
            targetingDistance.ForTargeting = uITarget.Target;
            targetingDistance.targetMarker = uITarget.uimarker;
            Distances.Add (targetingDistance); 
        }
        Distances.Sort(CompareByDistance);
        return Distances[0];
    }

    float Pythagoras (float a, float b)
    {
        a = System.Math.Abs(a - 0.5f);
        b = System.Math.Abs(b - 0.4f);
        float c2 = Mathf.Pow(a, 2f) + Mathf.Pow(b, 2f);
        float c = Mathf.Pow(c2, 0.5f);
        return c;
    }

}
