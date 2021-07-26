using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraHandler : MonoBehaviour
{
    public static CameraHandler Instance;

    [SerializeField] private Transform finishPointTF;
    [SerializeField] private CinemachineVirtualCamera vcam;


    CinemachineTransposer transposer;
    private float finalCamPos;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();
        finalCamPos = 1000;
    }

    private void Update()
    {
        if (transposer.m_FollowOffset.z > finalCamPos+1)
        {
            //Debug.Log("Buyuk");
           
            Vector3 targetVec = new Vector3(transposer.m_FollowOffset.x, transposer.m_FollowOffset.y, -20f);
            transposer.m_FollowOffset = Vector3.Lerp(transposer.m_FollowOffset, targetVec, 10f * Time.deltaTime /5);

            //Quaternion targetRotation = new Quaternion(4f, vcam.gameObject.transform.rotation.y, vcam.gameObject.transform.rotation.z,1);
            //vcam.gameObject.transform.rotation = Quaternion.Lerp(vcam.gameObject.transform.rotation, targetRotation, 10f * Time.deltaTime / 5);
        }
    }
    public void SetCamForDance()
    {
        vcam.Follow = finishPointTF;
        vcam.LookAt = finishPointTF;
    }
    public void SetCamForFinal2(Transform camPos)
    {
        //CinemachineTransposer transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();
        vcam.Follow = camPos; //camPos
        vcam.LookAt = null;
        //transposer.m_FollowOffset = new Vector3(transposer.m_FollowOffset.x, transposer.m_FollowOffset.y, -19f);
        finalCamPos = -20f;
    }
  
}

