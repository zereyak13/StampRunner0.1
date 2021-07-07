using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstackle : MonoBehaviour
{
    [Header("BrushID = 0 || TongueID = 1 || WallID = 2 || BoyaliFircaID = 3")]

    [SerializeField] int obstackleID;

    private Animator anim;
    private Slider inkSlider;
    void Start()
    {
        anim = GetComponent<Animator>();
        inkSlider = InkBar.Instance.InkBarGO.GetComponent<Slider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {
            switch (obstackleID)
            {
                case 0:  //Brush ID = 0                 
                    inkSlider.value -= 30;   //SetSlider            
                    anim.SetBool("brushAnim", true);    //play animation
                    break;

                case 1://Dil
                    inkSlider.value -= 50;
                    anim.SetBool("dil", true);
                    break;

                case 2://Wall
                    inkSlider.value -= 20;
                    //Player Dead
                    //SceneManagement.Instance.LoadThisScene();
                    break;

                case 3://BoyaliFirca
                    inkSlider.value += 50;
                    anim.SetBool("brushAnim", true);
                    //Player Dead
                    //SceneManagement.Instance.LoadThisScene();
                    break;
            }
        }    
    }


}
