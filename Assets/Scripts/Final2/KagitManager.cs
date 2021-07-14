using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KagitManager : MonoBehaviour
{
    public static KagitManager Instance;
    public GameObject kagit;

    public GameObject finalMultiplier;
    private const float finalMultiplierMoveRange = 4.2f;
    //private float finalMultStartPosY;
    private float finalMultTargetPosY;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        finalMultTargetPosY = 1000f;
    }

    private void Update()
    {
        if (finalMultiplier.transform.position.y > finalMultTargetPosY)
        {
            //Debug.Log("Buyuk");
            Vector3 targetVec = new Vector3(finalMultiplier.transform.position.x, finalMultTargetPosY, finalMultiplier.transform.position.z);
            finalMultiplier.transform.position = Vector3.Lerp(finalMultiplier.transform.position, targetVec, 10f* Time.deltaTime);
        }
    }
    public void InstantiateKagit(Transform instantiatePos)
    {
        Instantiate(kagit, instantiatePos.position, kagit.transform.rotation);        
    }

    public void MovemeFinalMultiplier()
    {
        finalMultTargetPosY = finalMultiplier.transform.position.y - finalMultiplierMoveRange;
    }
}
