using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [HideInInspector] public bool isGameStarted;
    //FlayingValues
    [HideInInspector] public bool isFlying;

    [SerializeField] Transform[] floatingPoints;

    private int floatingIndex;
    private float flyingSpeed = 13f;

    //MosueSwipeControl()  //MobileSwipeControl()
    [SerializeField] private float speed = 8f;

    private Rigidbody playerRB;
    private float speedHor = 0.1f;
    private bool mouseDown, fingerDown;
    private Vector3 startPos;
    private Vector3 targetPosA, targetPosD;
    private float platformLimit = 2f;


    //Animator
    Animator playerAnimator;

    private void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
        playerAnimator = gameObject.GetComponent<Animator>();

    }

    void Update()
    {
        //MouseSwipeControl();
        MobileSwipeControl();

        PlayerFloating();
        Dancing();
    }

    #region Swipes
    private void MouseSwipeControl() //Baþlangýç konumundan farklý ise
    {
        Vector3 dir = Vector3.forward * speed;
        dir.y = playerRB.velocity.y;
        dir.x = playerRB.velocity.x;
        //Vectoral movement
        playerRB.velocity = dir;
        //transform.Translate(dir * Time.deltaTime);

        //Mouse swipe 
        if (mouseDown == false && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            mouseDown = true;
        }
        if (mouseDown)
        {
            //Swipe Movements
            if (Input.mousePosition.x > startPos.x + 3 && playerRB.position.x < platformLimit)
            {
                //Debug.Log("dif" + ( Input.mousePosition.x - startPos.x));
                Debug.Log("Swipe right");
                targetPosA = new Vector3(platformLimit, playerRB.position.y, playerRB.position.z);
                playerRB.position = Vector3.MoveTowards(playerRB.position, targetPosA, speedHor);

                startPos = Input.mousePosition;

            }
            else if (Input.mousePosition.x < startPos.x - 3 && playerRB.position.x > -platformLimit)
            {
                //Debug.Log("difeksi" + (Input.mousePosition.x - startPos.x));
                Debug.Log("Swipe left");
                targetPosD = new Vector3(-platformLimit, playerRB.position.y, playerRB.position.z);
                playerRB.position = Vector3.MoveTowards(playerRB.position, targetPosD, speedHor);

                startPos = Input.mousePosition;
            }
            //MouseDown default false.
            if (Input.GetMouseButtonUp(0))
            {
                mouseDown = false;
                Debug.Log("girdi");
            }
        }
    }

    private void MobileSwipeControl() //Baþlangýç konumundan farklý ise
    {
        if (!isFlying)
        {
            if (isGameStarted)
            {
                playerAnimator.SetTrigger("gameStarted");
                Vector3 dir = Vector3.forward * speed;
                dir.y = playerRB.velocity.y;
                dir.x = playerRB.velocity.x;
                //Vectoral movement
                playerRB.velocity = dir;
                //transform.Translate(dir * Time.deltaTime);
            }
            //Mouse swipe 
            if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                startPos = Input.touches[0].position;

                fingerDown = true;
            }
            if (fingerDown)
            {
                isGameStarted = true;
                //Swipe Movements
                if (Input.touches[0].position.x > startPos.x + CanvasValues.Instance.CalculatePercentForCanvasX(6) && playerRB.position.x < platformLimit)
                {
                    Debug.Log("Swipe right");
                    targetPosA = new Vector3(platformLimit, playerRB.position.y, playerRB.position.z);
                    playerRB.position = Vector3.MoveTowards(playerRB.position, targetPosA, speedHor * 5f);

                    startPos = Input.touches[0].position;
                }
                else if (Input.touches[0].position.x > startPos.x + CanvasValues.Instance.CalculatePercentForCanvasX(1.5f) && playerRB.position.x < platformLimit) //else
                {

                    Debug.Log("Swipe right");
                    targetPosA = new Vector3(platformLimit, playerRB.position.y, playerRB.position.z);
                    playerRB.position = Vector3.MoveTowards(playerRB.position, targetPosA, (speedHor * 8f / 5));

                    startPos = Input.touches[0].position;
                }
                else if (Input.touches[0].position.x < startPos.x - CanvasValues.Instance.CalculatePercentForCanvasX(6) && playerRB.position.x > -platformLimit)
                {
                    Debug.Log("Swipe left");
                    targetPosD = new Vector3(-platformLimit, playerRB.position.y, playerRB.position.z);
                    playerRB.position = Vector3.MoveTowards(playerRB.position, targetPosD, speedHor * 5f);

                    startPos = Input.touches[0].position;
                }
                else if (Input.touches[0].position.x < startPos.x - CanvasValues.Instance.CalculatePercentForCanvasX(1.5f) && playerRB.position.x > -platformLimit)
                {
                    Debug.Log("Swipe left");
                    targetPosD = new Vector3(-platformLimit, playerRB.position.y, playerRB.position.z);
                    playerRB.position = Vector3.MoveTowards(playerRB.position, targetPosD, (speedHor* 8f /5));

                    startPos = Input.touches[0].position;
                }
                //MouseDown default false.
                if (Input.touchCount == 0)
                {
                    fingerDown = false;
                }
            }    
        }
    }

    #endregion


    public void PlayerFloating()
    {
        if (isFlying)
        {
            fingerDown = false;
            playerRB.velocity = Vector3.zero;
            speed = 0;
            playerRB.useGravity = false;

            playerAnimator.SetBool("isFlying", isFlying);

            Vector3 dir = (floatingPoints[floatingIndex].position - playerRB.position);

            float distance = dir.sqrMagnitude;
            //dir = new Vector3(dir.z, dir.y, -dir.x); //karakter yönüne göre hareket// x = z ,   z = -x , y=y
            //transform.Translate(dir.normalized * flyingSpeed * 3 / 2 *  Time.deltaTime);
            playerRB.position = Vector3.MoveTowards(playerRB.position, floatingPoints[floatingIndex].position, flyingSpeed * (3 / 2 * Time.deltaTime));

            //Debug.Log(distance);
            if (distance < 0.3f && floatingIndex < floatingPoints.Length - 1)
            {
                floatingIndex++;
            }

            if (floatingIndex == floatingPoints.Length - 1)
            {
                isFlying = false;

                playerRB.useGravity = true;

                //SetAnim
                playerAnimator.SetBool("isFlying", isFlying);

                SceneManagement.Instance.LoadNextLevel();

            }

            //playerAnimator.SetBool("isFlying", isFlying);

        }
    }

    private void Dancing()
    {
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Dans 0"))
        {
            // Set Cam
            CameraHandler.Instance.SetCamForDance();
            //transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }


}
