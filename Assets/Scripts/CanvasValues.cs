using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasValues : MonoBehaviour
{
    public static CanvasValues Instance;

    //[SerializeField] GameObject canvasGO;

    //private RectTransform canvasRect;
 
    private void Awake()
    {
        Instance = this;
    }
 
    void Start()
    {
        //canvasRect = canvasGO.gameObject.GetComponent<RectTransform>();
    }



    public float CalculatePercentForCanvasX(float percentRate)
    {
        float percent = Screen.width * percentRate / 100;
        return percent;
    }

    public float GetCanvasPercentage(float deltaX) {
        return deltaX / Screen.width;
    }
}
