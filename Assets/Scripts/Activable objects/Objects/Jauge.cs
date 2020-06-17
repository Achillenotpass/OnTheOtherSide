using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jauge : Activable
{
    private MeshRenderer m_MeshRenderer;
    private int m_FillingState = 0;

    public Material[] materials;


    private void Start()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
    }

    public override void Interaction()
    {
        m_FillingState = m_FillingState + 1;
        m_MeshRenderer.material = materials[m_FillingState];
    }
}
