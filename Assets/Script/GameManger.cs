using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public Button colorBtn1;
    public Button colorBtn2;
    public Button colorBtn3;
    public Button colorBtn4;
    //public Button clearBtn;
    public GameObject lineRendererPrefabs;
    private LineRenderer lineRenderer;
    public Slider setLineSize;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = lineRendererPrefabs.GetComponent<LineRenderer>();
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;

        colorBtn1.onClick.AddListener(SwitchColorBtn1);
        colorBtn2.onClick.AddListener(SwitchColorBtn2);
        colorBtn3.onClick.AddListener(SwitchColorBtn3);
        colorBtn4.onClick.AddListener(SwitchColorBtn4);

        //clearBtn.onClick.AddListener(ClearLine);

        setLineSize.onValueChanged.AddListener(setLineWidth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchColorBtn1()
    {
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
    }
    void SwitchColorBtn2()
    {
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
    }
    void SwitchColorBtn3()
    {
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
    }
    void SwitchColorBtn4()
    {
        lineRenderer.startColor = Color.green;
        lineRenderer.endColor = Color.green;
    }


    void setLineWidth(float value)
    {
        lineRenderer.startWidth = value;
        lineRenderer.endWidth = value;
    }

    /*void ClearLine()
    { 
    
    
    }*/
}
