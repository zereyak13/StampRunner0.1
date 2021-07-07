using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Paper : MonoBehaviour
{
    [SerializeField] private GameObject sicrama;
    [SerializeField] private int paperEffect;

    Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Animator>();

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (InkBar.Instance.InkBarGO.GetComponent<Slider>().value != 0)//Sadece mürekkep varsa imza atar.
            {
                GameObject stampedPaper = transform.GetChild(0).gameObject;
                //stamped paper
                stampedPaper.SetActive(true);
                //Set Ink bar
                InkBar.Instance.SetInkBar(paperEffect);
                playerAnimator.SetTrigger("forwardFlip");
                //Vibration
                NiceVibrationsCall.Instance.HeavyVibration();
                //Call Splash Effect
                ParticleManager.Insatance.CallSplashEffect(stampedPaper);
   
            }
        }


        //if (other.gameObject.CompareTag("Player"))
        //{
        //    StartCoroutine(AddDelayForStamp(0.190f));
        //    playerAnimator.SetTrigger("forwardFlip");
        //}
    }

    IEnumerator AddDelayForStamp(float time)
    {
        yield return new WaitForSeconds(time);

        if (InkBar.Instance.InkBarGO.GetComponent<Slider>().value != 0)//Sadece mürekkep varsa imza atar.
        {
            transform.GetChild(0).gameObject.SetActive(true);
            InkBar.Instance.SetInkBar(paperEffect);
        }
    }

}
