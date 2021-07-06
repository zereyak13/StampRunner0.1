using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableTongue : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("lick", true);
            Debug.Log("lick animation");
        }
    }
}
