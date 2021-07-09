using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KagitFinal : MonoBehaviour
{
    [SerializeField] private float kagitFinalEffect;
    // Start is called before the first frame update

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.transform.root.CompareTag("Player"))
        {
            if (InkBar.Instance.GetInkBarValue() > 0)
            {
                GetComponent<Animator>().SetTrigger("kagitAnim");
                Destroy(gameObject, 0.41f);

                Debug.Log("true");
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
