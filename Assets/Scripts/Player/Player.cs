using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speedMove = 0.20f;
    public float multiplyMove = 1;
    bool m_IsRunning = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        SimpleMovement();
    }

    // Système de déplacement
    public void SimpleMovement()
    {

        // Variable pour le sprint
        if (m_IsRunning) { multiplyMove = 3; }
        else { multiplyMove = 1; }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetAxis("Sprint") > 0)
        {
            m_IsRunning = true;
        }
        else
        {
            m_IsRunning = false;
        }


        // déplacement clavier
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(0, 0, multiplyMove * speedMove * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -0.5f * multiplyMove * speedMove * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(-0.75f * multiplyMove * speedMove * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.75f * multiplyMove * speedMove * Time.deltaTime, 0, 0);
        }

        // déplacement mannette 
        float translationX = Input.GetAxis("LeftJoystickX") * speedMove * multiplyMove * Time.deltaTime;
        float translationY = Input.GetAxis("LeftJoystickY") * speedMove * multiplyMove * Time.deltaTime;


        if (translationY > 0)
        {
            transform.Translate(0, 0, -translationY * 0.5f);
        }
        else
        {
            transform.Translate(0, 0, -translationY);
        }

        transform.Translate(0.75f * translationX, 0, 0);
    }
}
