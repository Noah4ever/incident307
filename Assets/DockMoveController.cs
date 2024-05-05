using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DockMoveController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject targetObject;
    public Image overlayImage;
    public Image loadingBar;
    public Sprite[] loadingBarSprites;

    public float speed = 1.0f;
    public float rotateSpeed = 0.8f;

    public float distanceThreshold = 0.5f;
    public float angleThreshold = 2.0f;
    public float timeThreshold = 2.0f;

    [SerializeField]
    private bool isLookingAtTarget = false;
    [SerializeField]
    private float timeLooking = 0f;

    void Update()
    {
        Vector3 targetPosition = targetObject.transform.position;
        Vector3 cameraPosition = mainCamera.transform.position;

        float distance = Vector3.Distance(targetPosition, cameraPosition);

        // Check if the camera is close enough to the target object
        if (distance < distanceThreshold)
        {
            Vector3 targetDirection = targetPosition - cameraPosition;
            Vector3 cameraForward = mainCamera.transform.forward;
            float angle = Vector3.Angle(cameraForward, targetDirection);

            // Check if the camera is facing the target object
            if (angle < angleThreshold)
            {
                // green
                overlayImage.color = new Color(0, 1, 0, 1f);
                isLookingAtTarget = true;
                timeLooking += Time.deltaTime;

                if(timeLooking <= timeThreshold * 0.25f)
                    loadingBar.sprite = loadingBarSprites[0];
                if(timeLooking >= timeThreshold * 0.25f && timeLooking <= timeThreshold * 0.5f)
                    loadingBar.sprite = loadingBarSprites[1];
                if(timeLooking >= timeThreshold * 0.5f && timeLooking <= timeThreshold * 0.75f)
                    loadingBar.sprite = loadingBarSprites[2];
                if(timeLooking >= timeThreshold * 0.75f && timeLooking <= timeThreshold)
                    loadingBar.sprite = loadingBarSprites[3];

                if (timeLooking >= timeThreshold)
                {
                    overlayImage.color = new Color(0, 1, 0, 1f);
                    loadingBar.sprite = loadingBarSprites[4];
                    Debug.Log("Docking complete");
                    SceneManager.LoadScene("End");
                }
            }
            else
            {
                // Reset the timer if the camera is not facing the target
                isLookingAtTarget = false;
                overlayImage.color = new Color(1, 1, 0, 1f);
                loadingBar.sprite = loadingBarSprites[0];
                timeLooking = 0f;
            }
        }
        else
        {
            // Reset the timer if the camera is not close enough to the target
            isLookingAtTarget = false;
            overlayImage.color = new Color(1, 1, 0, 1f);
            loadingBar.sprite = loadingBarSprites[0];
            timeLooking = 0f;
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        mainCamera.transform.Translate(movement * speed * Time.deltaTime);

        // Rotate camera with i, j , k, l
        float rotateHorizontal = 0.0f;
        float rotateVertical = 0.0f;

        // Move only one direction at a time

        //if (Input.GetKey(KeyCode.I))
        //{
        //    rotateVertical = rotateSpeed;
        //}
        //else if (Input.GetKey(KeyCode.K))
        //{
        //    rotateVertical = -rotateSpeed;
        //}
        //else if (Input.GetKey(KeyCode.J))
        //{
        //    rotateHorizontal = -rotateSpeed;
        //}
        //else if (Input.GetKey(KeyCode.L))
        //{
        //    rotateHorizontal = rotateSpeed;
        //}
         if (Input.GetMouseButton(1))
        {
            rotateHorizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            rotateVertical = -Input.GetAxis("Mouse Y") * rotateSpeed;
        }

        mainCamera.transform.Rotate(-rotateVertical, rotateHorizontal, 0.0f);
    }
}
