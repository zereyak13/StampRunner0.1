using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InkBar : MonoBehaviour
{
    public static InkBar Instance;
    public GameObject InkBarGO;

    private Transform sliderFillTF;
    private void Awake()
    {
        Instance = this;
        sliderFillTF = InkBarGO.transform.GetChild(1).Find("Fill").transform;
    }
    private void Start()
    {
     
    }
    public void SetInkBar(int inkEffect)
    {
        Slider inkBar = InkBarGO.gameObject.GetComponent<Slider>();
        inkBar.value += inkEffect; 
    }

    public void SetBarColor(Color barColor)
    {
        sliderFillTF.GetComponent<Image>().color = barColor;
    }
    
    public float GetInkBarValue()
    {
        Slider inkBar = InkBarGO.gameObject.GetComponent<Slider>();
        return inkBar.value;
    }

}
