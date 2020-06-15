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

    public GameObject deathParticles;

    private Vector3 basePosition;
    public float shakingValue;


    private void Awake()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
        m_AudioSource = GetComponent<AudioSource>();
        m_BoxCollider = GetComponent<BoxCollider>();
        basePosition = transform.position;
    }

    private void Update()
    {
        transform.LookAt(player.transform);
        transform.Rotate(0.0f, -90.0f,  45.0f - transform.rotation.z);
        transform.position = new Vector3(basePosition.x + Random.Range(-shakingValue, shakingValue), basePosition.y + Random.Range(-shakingValue, shakingValue), basePosition.z + Random.Range(-shakingValue, shakingValue));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Movable")
        {
            for (int i = 0; i < toActivate.Length; i++)
            {
                toActivate[i].GetComponent<Activable>().Interaction();
            }

            Instantiate(deathParticles, transform);
            m_MeshRenderer.enabled = false;
            m_BoxCollider.enabled = false;
            m_AudioSource.Play();
            Invoke("DestroyThis", 2.0f);
        }
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
