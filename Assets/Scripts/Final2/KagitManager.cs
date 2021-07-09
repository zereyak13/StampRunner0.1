using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KagitManager : MonoBehaviour
{
    public static KagitManager Instance;
    public GameObject kagit;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update

    public void InstantiateKagit(Transform instantiatePos)
    {
        Instantiate(kagit, instantiatePos.position, kagit.transform.rotation);        
    }
}
