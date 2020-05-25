using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100;

    public Transform playerBody;

    float m_XRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        m_XRotation -= mouseY;

        m_XRotation = Mathf.Clamp(m_XRotation, -80, 80);

        transform.localRotation = Quaternion.Euler(m_XRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
