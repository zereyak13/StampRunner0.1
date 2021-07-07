using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPosHandler : MonoBehaviour
{
    public static PaperPosHandler Instance;

    [SerializeField] private Transform[] cubePoints;
    [SerializeField] private Transform finalPaperBlokPivotTF;

    [SerializeField] private GameObject paperForFinalBlokGO;
    [SerializeField] private Transform paperCreationPos;

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
        instantiatedPapers = new GameObject[cubePoints.Length];
        curDistance = paperDistance;
    }

 

    public void SetCubePoints() //CubePoints and PaperList
    {
        foreach (Transform cubeTF in cubePoints)
        {
            cubeTF.transform.position += new Vector3(0,curDistance, 0);
            curDistance += paperDistance;
        }
        //CreatePaperList();
        for (int i = 0; i < cubePoints.Length; i++)
        {
            GameObject instantiatedPaperGO = Instantiate(paperForFinalBlokGO, paperCreationPos.position, paperForFinalBlokGO.transform.rotation);
            instantiatedPapers[i] = instantiatedPaperGO;
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
            Vector3 dir = (cubePoints[paperIndex].transform.position - instantiatedPapers[paperIndex].transform.position);

            float distance = dir.sqrMagnitude;

            //dir = new Vector3(dir.z, dir.y, -dir.x); //karakter yönüne göre hareket// x = z ,   z = -x , y=y

            instantiatedPapers[paperIndex].transform.position = Vector3.MoveTowards(instantiatedPapers[paperIndex].transform.position, cubePoints[paperIndex].transform.position, paperFloatSpeed);

            //Debug.Log(distance);
            //Debug.Log(paperIndex);
            //Debug.Log(instantiatedPapers.Length + "lengt");
            if (distance < 1f && paperIndex < instantiatedPapers.Length - 1)
            {
                paperIndex++;
            }
        }
    }






}
