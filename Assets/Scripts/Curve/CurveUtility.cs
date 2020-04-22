using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveUtility : MonoBehaviour
{
    public AnimationCurve axeX;
    public AnimationCurve axeY;
    public AnimationCurve axeZ;

    private Vector3 curve = Vector3.zero;

    private float movementTimerX = 0f;
    private float movementTimerY = 0f;
    private float movementTimerZ = 0f;

    private float movementDurationX = 0f;
    private float movementDurationY = 0f;
    private float movementDurationZ = 0f;

    public GameObject objectToAnimate;

    private void Update()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        movementTimerX += Time.deltaTime;
        movementTimerY += Time.deltaTime;
        movementTimerZ += Time.deltaTime;
        curve = new Vector3(objectToAnimate.transform.parent.position.x + axeX.Evaluate(movementTimerX), objectToAnimate.transform.parent.position.y + axeY.Evaluate(movementTimerY), objectToAnimate.transform.parent.position.z + axeZ.Evaluate(movementTimerZ));
        objectToAnimate.transform.position = curve;
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
        movementTimerX = 0f;
        movementDurationX = ComputeAnimCurveDuration(axeX);
        movementTimerY = 0f;
        movementDurationY = ComputeAnimCurveDuration(axeY);
        movementTimerZ = 0f;
        movementDurationZ = ComputeAnimCurveDuration(axeZ);
    }
}
