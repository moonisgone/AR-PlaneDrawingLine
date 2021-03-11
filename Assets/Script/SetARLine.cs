using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class SetARLine : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject lineRendererPrefabs;
    public List<LineRenderer> lineList = new List<LineRenderer>();
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private LineRenderer lineRenderer;
    public Button clearBtn;
    public bool startLine;
    public bool _use;

    // Start is called before the first frame update
    void Start()
    {
        startLine = false;
        _use = false;

        clearBtn.onClick.AddListener(ClearLine);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Input.GetTouch(0).position;
            if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = hits[0].pose;
                if (!startLine)
                {
                    MakeLineRenderer(hitPose.position);
                }
                DrawLineContinue(hitPose.position);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                StopDrawLine();
            }
        }
       
    }

    public void MakeLineRenderer(Vector3 position)
    {
        GameObject tLine = Instantiate(lineRendererPrefabs);
        tLine.transform.position = Vector3.zero;
        tLine.transform.localScale = new Vector3(1, 1, 1);

        lineRenderer = tLine.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, position);
        startLine = true;
        lineList.Add(lineRenderer);
    }

    public void DrawLineContinue(Vector3 position)
    {
        lineRenderer.positionCount = lineRenderer.positionCount + 1;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);
        
    }

    public void StopDrawLine()
    {
        //_use = false;
        startLine = false;
        lineRenderer = null;
    }

    void ClearLine()
    {
        foreach (LineRenderer line in lineList)
        {
            line.positionCount = 0;
            //line. = null;
        }
        lineList.Clear();
    }
}
