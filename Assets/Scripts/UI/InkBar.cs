using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InkBar : MonoBehaviour
{
    public static InkBar Instance;
    public GameObject InkBarGO;

    private void Awake()
    {
        Instance = this;   
    }
    public void SetInkBar(int inkEffect)
    {
        Slider inkBar = InkBarGO.gameObject.GetComponent<Slider>();
        inkBar.value += inkEffect; 
    }
}
