using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalZone : MonoBehaviour
{
    PlayerController playerController;

    string objectName;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        objectName = gameObject.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (objectName)
            {
                case "FinalZone (1)":
                    playerController.isFlying = true;
                    break;
                case "startPaperMovement":
                    PaperPosHandler.Instance.SetCubePoints();
                    break;
            }
           
        }
    }
}
