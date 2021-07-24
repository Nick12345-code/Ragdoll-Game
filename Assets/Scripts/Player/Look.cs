using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    [SerializeField] private float minX = -60f;
    [SerializeField] private float maxX = 60f;
    [SerializeField] private float minY = -60f;
    [SerializeField] private float maxY = 60f;
    [SerializeField] private float sensitivity;
    private float rotY = 0f;
    private float rotX = 0f;

    private void Start()
    {
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
        rotY += Input.GetAxis("Mouse X") * sensitivity;
        rotX += Input.GetAxis("Mouse Y") * sensitivity;

        rotX = Mathf.Clamp(rotX, minX, maxX);
        rotY = Mathf.Clamp(rotY, minY, maxY);

        transform.localEulerAngles = new Vector3(0, rotY, 0);
        Camera.main.transform.localEulerAngles = new Vector3(-rotX, rotY, 0);
    }
}
