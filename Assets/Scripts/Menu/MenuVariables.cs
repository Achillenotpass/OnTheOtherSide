using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingVariables", menuName = "ScriptableObjects/MenuSettings", order = 1)]
public class MenuVariables : ScriptableObject
{
    public Vector4 brightness;

    public float sensitivity = 5.0f;

    public float effectVolume;
    public float musicVolume;

    public int resolutionIndex;

    public int qualityIndex;

    public bool isFullscreen;
}
