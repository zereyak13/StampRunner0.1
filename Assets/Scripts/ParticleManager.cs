using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Insatance;

    private GameObject mainCam;

    [SerializeField] private GameObject confeti1GO;
    [SerializeField] private GameObject waterSplashGO;

    private bool onlyOnce;

    private void Awake()
    {
        Insatance = this;
    }

    private void Start()
    {
        mainCam = Camera.main.gameObject;
    }
    public void CallFinalStampEfect()
    {
        if (!onlyOnce)
        {
            GameObject confeti = Instantiate(confeti1GO, mainCam.transform.position + new Vector3(0, 0, 3f), mainCam.transform.rotation);
            confeti.GetComponent<ParticleSystem>().Play();

            //Water Splash
            //Vector3 waterSplashPos = GameObject.FindGameObjectWithTag("Player").transform.position - Vector3.up;
            //GameObject waterSplash = Instantiate(waterSplashGO, waterSplashPos, Quaternion.identity);
            //waterSplash.GetComponent<ParticleSystem>().Play();
            onlyOnce = true;
        }
              
    }
    public void CallSplashEffect(Vector3 SplashPos)
    {
        GameObject waterSplash = Instantiate(waterSplashGO, SplashPos, Quaternion.identity);
        waterSplash.GetComponent<ParticleSystem>().Play();
    }
}
