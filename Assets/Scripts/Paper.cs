using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Paper : MonoBehaviour
{
    Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Animator>();
    }

    [SerializeField] private int paperEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (InkBar.Instance.InkBarGO.GetComponent<Slider>().value != 0)//Sadece mürekkep varsa imza atar.
        {
            transform.GetChild(0).gameObject.SetActive(true);
            InkBar.Instance.SetInkBar(paperEffect);
            playerAnimator.SetTrigger("forwardFlip");
            NiceVibrationsCall.Instance.HeavyVibration();
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
