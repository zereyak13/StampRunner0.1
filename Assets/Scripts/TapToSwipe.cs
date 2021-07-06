using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TapToSwipe : MonoBehaviour
{
    private Slider tapToSwipe;
    private PlayerController playerController;

    private bool swipeLeftRight;
    private int slideSpeed = 60;
    void Start()
    {
        tapToSwipe = gameObject.GetComponent<Slider>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
       
    }

    void Update()
    {
        SlideMovement();
        HideTapToSwipeGO();
    }

    private void SlideMovement()
    {
        if(playerController.isGameStarted == false)
        {
            if (swipeLeftRight == false)
            {
                tapToSwipe.value += slideSpeed * Time.deltaTime;
                if (tapToSwipe.value >= 80)
                    swipeLeftRight = !swipeLeftRight;
            }
            else if (swipeLeftRight == true)
            {
                tapToSwipe.value -= slideSpeed * Time.deltaTime;
                if (tapToSwipe.value <= 20)
                    swipeLeftRight = !swipeLeftRight;
            }
        }  
    }

    private void HideTapToSwipeGO()
    {
        if(playerController.isGameStarted == true)
        {
            gameObject.SetActive(false);
        }
    }


}
