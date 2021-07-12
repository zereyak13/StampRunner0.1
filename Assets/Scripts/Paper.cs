using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Paper : MonoBehaviour
{
    [SerializeField] private GameObject sicrama;
    [SerializeField] private int paperEffect;

    Animator playerAnimator;

    private int score =10;
    private void Start()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Animator>();

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (InkBar.Instance.InkBarGO.GetComponent<Slider>().value != 0)//Sadece m�rekkep varsa imza atar.
            {
                playerAnimator.SetTrigger("forwardFlip");
                StartCoroutine(AddDelayForStamp(0.1f));
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

        if (InkBar.Instance.InkBarGO.GetComponent<Slider>().value != 0)//Sadece m�rekkep varsa imza atar.
        {
            GameObject stampedPaper = transform.GetChild(0).gameObject;
            //stamped paper
            stampedPaper.SetActive(true);
            //Set Ink bar
            InkBar.Instance.SetInkBar(paperEffect);
            //Vibration
            NiceVibrationsCall.Instance.HeavyVibration();
            //Call Splash Effect
            ParticleManager.Instance.CallSplashEffect(stampedPaper.transform.position);
            //Add Score
            string scoreText =InkBar.Instance.InkBarGO.transform.Find("Score").GetComponent<TextMeshProUGUI>().text;
            InkBar.Instance.InkBarGO.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = ""+(int.Parse(scoreText) + score);
        }
    }



}
