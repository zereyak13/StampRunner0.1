using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalZone2 : MonoBehaviour
{
    Transform camPos;

    private void Start()
    {
        camPos = transform.parent.transform.Find("camPos");
    }
 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name);
            if (InkBar.Instance.GetInkBarValue() > 0)
            {
                //Karakteri x ekseninde sıfıra sabitle neden burada çalışmadı da player controllarda yazmak zorunda kaldım.

                //other.transform.position = new Vector3(0, other.transform.position.y, other.transform.position.z);

                other.gameObject.GetComponent<Animator>().SetBool("FinalStampActive", true); // final stamp animasyon

                other.transform.GetComponent<Rigidbody>().useGravity = false;
                other.transform.GetComponent<CapsuleCollider>().enabled = false;
                other.transform.GetChild(0).GetChild(0).GetComponent<CapsuleCollider>().enabled = true;

                CameraHandler.Instance.SetCamForFinal2(camPos);
            }
            else
            {
                //Buraya sadece ilk alandan giriyor kağit tetiklenmesi için Kağit final a bak.
                other.gameObject.transform.root.GetComponent<Animator>().SetTrigger("idle");
                other.transform.GetComponent<Rigidbody>().useGravity = false;
                other.transform.GetComponent<CapsuleCollider>().enabled = false;
                other.transform.GetChild(0).GetChild(0).GetComponent<CapsuleCollider>().enabled = true;

                CameraHandler.Instance.SetCamForFinal2(camPos);
                SceneManagement.Instance.LoadThisScene();

            }
        }
    }
}
