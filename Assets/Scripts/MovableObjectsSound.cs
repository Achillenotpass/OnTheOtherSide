using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectsSound : MonoBehaviour
{
    private AudioSource m_AudioSource;
    public AudioClip collisionSound;

    private Player m_Player;
    
    public Monster monster;

    void Awake()
    {
        m_Player = FindObjectOfType<Player>();
        m_AudioSource = gameObject.AddComponent<AudioSource>();
        m_AudioSource.spatialBlend = 1;
        m_AudioSource.clip = collisionSound;
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        m_AudioSource.pitch = Random.Range(0.7f, 1.2f);
        m_AudioSource.Play();

        if (monster != null)
        {
            if ((Vector3.Distance(transform.position, monster.transform.position) <= monster.monsterHearingDistance) && (Vector3.Distance(transform.position, monster.transform.position) >= monster.monsterMinHearingDistance))
            {
                monster.FollowSounds(transform.position);
            }
        }
        
    }
}
