using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Insatance;

    private GameObject mainCam;

    [SerializeField] private GameObject confeti1GO;

    private bool onlyOnce;

    private void Awake()
    {
        Insatance = this;
    }

    private void Start()
    {
        mainCam = Camera.main.gameObject;
    }
    public void InstantiateParticleEffect()
    {
        if (!onlyOnce)
        {
            GameObject confeti = Instantiate(confeti1GO, mainCam.transform.position + new Vector3(0, 0, 3f), mainCam.transform.rotation);
            confeti.GetComponent<ParticleSystem>().Play();
            onlyOnce = true;
        }
              
    }
}
