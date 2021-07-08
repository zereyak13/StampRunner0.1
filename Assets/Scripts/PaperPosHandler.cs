using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPosHandler : MonoBehaviour
{
    public static PaperPosHandler Instance;

    [SerializeField] private Transform[] totalCubePoints;


    [SerializeField] private Transform[] cubePoints1;
    [SerializeField] private Transform[] cubePoints2;
    [SerializeField] private Transform[] cubePoints3;
    [SerializeField] private Transform[] cubePoints4;

    [SerializeField] private Transform finalPaperBlokPivotTF;

   
    [SerializeField] private Transform paperCreationPos1;
    [SerializeField] private Transform paperCreationPos2;
    [SerializeField] private Transform paperCreationPos3;
    [SerializeField] private Transform paperCreationPos4;

    [SerializeField] private GameObject paperForFinalBlokGO;

    [SerializeField] private float paperDistance;
    private float curDistance;

    private GameObject[] instantiatedPapers;
    private int paperIndex;

    private bool inFinalZone;

private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        instantiatedPapers = new GameObject[totalCubePoints.Length];
        curDistance = paperDistance;
    }

 

    public void SetCubePoints() //CubePoints and PaperList
    {
        foreach (Transform cubeTF in totalCubePoints)
        {
            cubeTF.transform.position += new Vector3(0,curDistance, 0);
            curDistance += paperDistance;
        }
        //CreatePaperList();
        for (int i = 0; i < totalCubePoints.Length; i+=4)
        {
            GameObject instantiatedPaperGO = Instantiate(paperForFinalBlokGO, paperCreationPos1.position, paperForFinalBlokGO.transform.rotation);
            instantiatedPapers[i] = instantiatedPaperGO;
            instantiatedPaperGO = Instantiate(paperForFinalBlokGO, paperCreationPos2.position, paperForFinalBlokGO.transform.rotation);
            instantiatedPapers[i+1] = instantiatedPaperGO;
            instantiatedPaperGO = Instantiate(paperForFinalBlokGO, paperCreationPos3.position, paperForFinalBlokGO.transform.rotation);
            instantiatedPapers[i+2] = instantiatedPaperGO;
            instantiatedPaperGO = Instantiate(paperForFinalBlokGO, paperCreationPos4.position, paperForFinalBlokGO.transform.rotation);
            instantiatedPapers[i+3] = instantiatedPaperGO;
        }
        inFinalZone = true;

    }

    private void FixedUpdate()
    {
        SetPaperPositions();
  
    }

    [SerializeField] private float paperFloatSpeed;
    private void SetPaperPositions()
    {
        if (inFinalZone)
        {
            Vector3 dir = (totalCubePoints[paperIndex].transform.position - instantiatedPapers[paperIndex].transform.position);

            float distance = dir.sqrMagnitude;

            //dir = new Vector3(dir.z, dir.y, -dir.x); //karakter yönüne göre hareket// x = z ,   z = -x , y=y

            instantiatedPapers[paperIndex].transform.position = Vector3.MoveTowards(instantiatedPapers[paperIndex].transform.position, totalCubePoints[paperIndex].transform.position, paperFloatSpeed);
            instantiatedPapers[paperIndex+1].transform.position = Vector3.MoveTowards(instantiatedPapers[paperIndex+1].transform.position, totalCubePoints[paperIndex+1].transform.position, paperFloatSpeed);
            instantiatedPapers[paperIndex+2].transform.position = Vector3.MoveTowards(instantiatedPapers[paperIndex+2].transform.position, totalCubePoints[paperIndex+2].transform.position, paperFloatSpeed);
            instantiatedPapers[paperIndex+3].transform.position = Vector3.MoveTowards(instantiatedPapers[paperIndex+3].transform.position, totalCubePoints[paperIndex+3].transform.position, paperFloatSpeed);

            //Debug.Log(distance);
            //Debug.Log(paperIndex);
            //Debug.Log(instantiatedPapers.Length + "lengt");
            //Debug.Log(instantiatedPapers.Length + "papercount");
            if (distance < 2f && paperIndex < instantiatedPapers.Length -4 )
            {
                paperIndex+=4;
               /* Debug.Log(paperIndex + "paper ýndex")*/;
            }
        }
    }

}
