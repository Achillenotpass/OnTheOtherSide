using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveRotation : MonoBehaviour
{
    public AnimationCurve axeX;
    public AnimationCurve axeY;
    public AnimationCurve axeZ;

    private Quaternion m_Curve = Quaternion.Euler(0, 0, 0);

    private float m_MovementTimerX = 0f;
    private float m_MovementTimerY = 0f;
    private float m_MovementTimerZ = 0f;

    private float m_MovementDurationX = 0f;
    private float m_MovementDurationY = 0f;
    private float m_MovementDurationZ = 0f;

    public GameObject objectToAnimate;

    private void Update()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        m_MovementTimerX += Time.deltaTime;
        m_MovementTimerY += Time.deltaTime;
        m_MovementTimerZ += Time.deltaTime;
        m_Curve = Quaternion.Euler(transform.parent.rotation.x + axeX.Evaluate(m_MovementTimerX), transform.parent.rotation.y + axeY.Evaluate(m_MovementTimerY), transform.parent.rotation.z + axeZ.Evaluate(m_MovementTimerZ));
        transform.rotation = m_Curve;
    }
    public void BeginMovement()
    {
        m_MovementTimerX = 0f;
        m_MovementTimerY = 0f;
        m_MovementTimerZ = 0f;
    }
}
