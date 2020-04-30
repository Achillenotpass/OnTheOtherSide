using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveMonsterLight : MonoBehaviour
{
    public AnimationCurve distanceLightMin;

    public AnimationCurve distanceLightMax;

    private Vector3 m_Curve = Vector3.zero;

    public void ApplyBlinking(SpeLight light, float distance)
    {
        light.minTimerForReactivation = distanceLightMin.Evaluate(distance);
        light.maxTimerForReactivation = distanceLightMax.Evaluate(distance);
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
}
