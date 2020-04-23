using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveUtility : MonoBehaviour
{
    public AnimationCurve axeX;
    public AnimationCurve axeY;
    public AnimationCurve axeZ;

    private Vector3 m_Curve = Vector3.zero;

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
        m_Curve = new Vector3(objectToAnimate.transform.parent.position.x + axeX.Evaluate(m_MovementTimerX), objectToAnimate.transform.parent.position.y + axeY.Evaluate(m_MovementTimerY), objectToAnimate.transform.parent.position.z + axeZ.Evaluate(m_MovementTimerZ));
        objectToAnimate.transform.position = m_Curve;
    }

    private float ComputeAnimCurveDuration(AnimationCurve curve)
    {
        if (curve.keys.Length > 0)
        {
            float maxTime = curve.keys[0].time;
            for (int i = 1; i < curve.keys.Length; i++)
            {
                // Je récupère la valeur la plus haute entre le dernier timing récupéré, et le timing de la keyframe 
                maxTime = Mathf.Max(maxTime, curve.keys[i].time);
            }
            return maxTime;
        }

        return 0f;
    }
    public void BeginMovement()
    {
        m_MovementTimerX = 0f;
        m_MovementDurationX = ComputeAnimCurveDuration(axeX);
        m_MovementTimerY = 0f;
        m_MovementDurationY = ComputeAnimCurveDuration(axeY);
        m_MovementTimerZ = 0f;
        m_MovementDurationZ = ComputeAnimCurveDuration(axeZ);
    }
}
