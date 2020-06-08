using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    public GameObject[] toActivate;
    public Player player;

    private MeshRenderer m_MeshRenderer;
    private AudioSource m_AudioSource;
    private BoxCollider m_BoxCollider;


    private void Awake()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
        m_AudioSource = GetComponent<AudioSource>();
        m_BoxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        transform.LookAt(player.transform);
        transform.Rotate(0.0f, -90.0f,  45.0f - transform.rotation.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < toActivate.Length; i++)
        {
            toActivate[i].GetComponent<Activable>().Interaction();
        }

        if (collision.gameObject.tag == "Movable")
        {
            m_MeshRenderer.enabled = false;
            m_BoxCollider.enabled = false;
            m_AudioSource.Play();
            Invoke("DestroyThis", 2.0f);
        }
    }
}
