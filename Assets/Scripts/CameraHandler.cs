using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraHandler : MonoBehaviour
{
    public static CameraHandler Instance;

    [SerializeField] private Transform finishPointTF;
    [SerializeField] private CinemachineVirtualCamera vcam;



    private void Awake()
    {
        Instance = this;
    }


    public void SetCamForDance()
    {
        vcam.Follow = finishPointTF;
        vcam.LookAt = finishPointTF;
    }
}
