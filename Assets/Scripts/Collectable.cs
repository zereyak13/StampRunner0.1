using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] int inkEffect;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InkBar.Instance.SetInkBar(inkEffect);
            Destroy(gameObject);
        }
    }
}
