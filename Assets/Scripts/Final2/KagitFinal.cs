using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KagitFinal : MonoBehaviour
{
    [SerializeField] private int kagitFinalEffect;
    // Start is called before the first frame update

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.root.CompareTag("Player"))
        {
            if (Var.Instance.gameScore > 1) //InkBar.Instance.GetInkBarValue() > 10
            {
                //InkBar.Instance.SetInkBar(kagitFinalEffect);
                Var.Instance.gameScore -= 1;
                GetComponent<Animator>().SetTrigger("kagitAnim");
                ParticleManager.Instance.CallBigSplashEffect(other.gameObject.transform.root.position);
                Destroy(gameObject, 0.6f);
                transform.Find("isaret_giris").GetComponent<SkinnedMeshRenderer>().enabled = true;
                StartCoroutine(AddDelay());
            }
            else if(Var.Instance.gameScore == 1)
            {
                Var.Instance.gameScore -= 1;
                //InkBar.Instance.SetInkBar(kagitFinalEffect);
                GetComponent<Animator>().SetTrigger("kagitAnim");
                ParticleManager.Instance.CallFinalStampEfect2();
                other.gameObject.transform.root.GetComponent<Animator>().SetBool("FinalStampActive", false);
                transform.Find("isaret_giris").GetComponent<SkinnedMeshRenderer>().enabled = true;
                Destroy(gameObject, 0.45f);
                NiceVibrationsCall.Instance.SuccesVibration();
                SceneManagement.Instance.LoadNextLevel();
                StartCoroutine(AddDelay());
            }
        }
    }
    
    IEnumerator AddDelay()
    {
        yield return new WaitForSeconds(0.4f);
        KagitManager.Instance.InstantiateKagit(transform);
    }


}
