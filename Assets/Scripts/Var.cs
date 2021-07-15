using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Var : MonoBehaviour
{
    public static Var Instance;

    [HideInInspector] public int gameScore;
    [HideInInspector] public bool isStampReady;

    private float stampTimer;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //isStampReady = true;
        stampTimer = 0.65f;
    }

    private void Update()
    {
        //Debug.Log(isStampReady);
        if (isStampReady == false)
        {
            stampTimer -= Time.deltaTime;
            if (stampTimer <= 0)
            {
                isStampReady = true;
                stampTimer = 0.65f;
            }
        }
    }
}
