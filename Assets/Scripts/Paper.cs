using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Paper : MonoBehaviour
{
    [HideInInspector] public int gameScore;

    [SerializeField] private GameObject sicrama;
    [SerializeField] private int paperEffect;

    Animator playerAnimator;

    private int scorePoint =10;

    private void Start()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Animator>();

        
    }

    private void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Var.Instance.isStampReady)
        {
            if (InkBar.Instance.InkBarGO.GetComponent<Slider>().value != 0)//Sadece mürekkep varsa imza atar.
            {
                playerAnimator.SetTrigger("forwardFlip");
                StartCoroutine(AddDelayForStamp(0.1f));
                Var.Instance.isStampReady = false;
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
            InkBar.Instance.InkBarGO.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = ""+(int.Parse(scoreText) + scorePoint);
            Var.Instance.gameScore += 1;
            //Debug.Log(Var.Instance.gameScore);

        }
    }
}
