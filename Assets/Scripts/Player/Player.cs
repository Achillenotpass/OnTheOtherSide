using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioSource footSteps;
    public float m_TimeBetweenStepSounds;
    private float m_CurrentTimerStepSounds;

    public float speedMove = 0.20f;
    public float multiplyMove = 1;
    bool m_IsRunning = false;

    public float speed = 5;

    public float maxVelocityChange = 10.0f;

    private Rigidbody m_Rigidbody;

    private bool grounded = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        { 
            PlayStepSounds();
        }
        SimpleMovement();
    }

    // Système de déplacement
    public void SimpleMovement()
    {

        // Variable pour le sprint
        if (m_IsRunning) { multiplyMove = 2; }
        else { multiplyMove = 1; }

        if (Input.GetButtonDown("Sprint"))
        {
            m_IsRunning = true;
        }
        if (Input.GetButtonUp("Sprint"))
        {
            m_IsRunning = false;
        }

        // Calculate how fast we should be moving
        if (grounded)
        {
            // Calculate how fast we should be moving
            Vector3 targetVelocity;
            targetVelocity.x = Input.GetAxis("Horizontal") * 0.75f;
            targetVelocity.y = 0;
            if (Input.GetAxis("Vertical") < 0)
                targetVelocity.z = Input.GetAxis("Vertical") * 0.5f;
            else
                targetVelocity.z = Input.GetAxis("Vertical");
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;
            targetVelocity *= multiplyMove;

            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = m_Rigidbody.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            m_Rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

        }

        grounded = false;
    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    private void PlayStepSounds()
    {
        if (m_CurrentTimerStepSounds <= m_TimeBetweenStepSounds)
        {
            m_CurrentTimerStepSounds = m_CurrentTimerStepSounds + Time.deltaTime * speedMove * multiplyMove;
        }
        else
        {
            footSteps.pitch = Random.Range(0.8f, 1.2f);
            footSteps.Play();
            m_CurrentTimerStepSounds = 0.0f;
        }
    }
}
