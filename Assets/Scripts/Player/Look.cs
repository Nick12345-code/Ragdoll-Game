using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float minX = -60f;
    [SerializeField] private float maxX = 60f;
    [SerializeField] private float minY = -60f;
    [SerializeField] private float maxY = 60f;
    [SerializeField] private float sensitivity;
    private float rotY = 0f;
    private float rotX = 0f;

    private void Start()
    {
        // locks the cursor to the middle of the screen and makes it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        CameraLook();
    }

    // player can look around
    private void CameraLook() 
    {
        // movement speed along the X and Y axis is controlled by sensitivity
        rotY += Input.GetAxis("Mouse X") * sensitivity;
        rotX += Input.GetAxis("Mouse Y") * sensitivity;

        // restricts the X and Y axis movement to simulate the constraints of realistic head movement
        rotX = Mathf.Clamp(rotX, minX, maxX);
        rotY = Mathf.Clamp(rotY, minY, maxY);

        // moves the camera
        transform.localEulerAngles = new Vector3(0, rotY, 0);
        playerCamera.transform.localEulerAngles = new Vector3(-rotX, rotY, 0);
    }
}
