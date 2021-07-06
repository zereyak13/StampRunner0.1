using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dil : MonoBehaviour
{

    Animator dilAnimator;
    // Start is called before the first frame update
    void Start()
    {
        dilAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {
            dilAnimator.SetTrigger("dil");
        } 
    }
}
