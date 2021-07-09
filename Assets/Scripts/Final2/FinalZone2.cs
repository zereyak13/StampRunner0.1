using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalZone2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.CompareTag("Player"))
        {
            if (InkBar.Instance.GetInkBarValue() > 0)
            {
                other.gameObject.transform.root.GetComponent<Animator>().SetBool("FinalStampActive", true);
                CameraHandler.Instance.SetCamForFinal2();
            }
            else
            {
                other.gameObject.transform.root.GetComponent<Animator>().SetBool("FinalStampActive", false);
            }
        }
    }
}
