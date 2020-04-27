using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public bool hasApparitionTarget = false;
    public GameObject apparitionTarget = null;
    public List<GameObject> movementTargets;
    private GameObject m_CurrentTarget;
    private NavMeshAgent m_NavmeshAgent;

    private Player m_Player;
    public float detectionRange;

    private bool m_CanSeePlayer = false;
    public float timeBeforeLosingAggro = 1.0f;
    private float m_CurrentTimeBeforeLosingAggro;

    public bool hasSurvivalTime = false;
    public float survivalTime = 0.0f;


    private void Awake()
    {
        m_NavmeshAgent = GetComponent<NavMeshAgent>();
        m_Player = FindObjectOfType<Player>();
    }

    
    void Start()
    {
        if (hasApparitionTarget)
        {
            m_CurrentTarget = apparitionTarget;
            m_NavmeshAgent.SetDestination(m_CurrentTarget.transform.position);
        }
        else
        {
            SetRandomTarget();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasSurvivalTime)
        {
            if (survivalTime <= 0.0f)
            {
                Disappear();
            }
            else
            {
                survivalTime = survivalTime - Time.deltaTime;
            }
        }

        if (Vector3.Distance(m_Player.transform.position, transform.position) <= detectionRange)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, m_Player.transform.position - transform.position, out hitInfo, detectionRange))
            {
                if (hitInfo.transform.gameObject == m_Player.gameObject)
                {
                    m_CanSeePlayer = true;
                    m_CurrentTimeBeforeLosingAggro = timeBeforeLosingAggro;
                }
                else
                {
                    LosingPlayerAggro();
                }
            }
            else
            {
                LosingPlayerAggro();
            }
        }
        else
        {
            LosingPlayerAggro();
        }


        if (m_CanSeePlayer)
        {
            SetTarget(m_Player.gameObject);
        }


        if (Vector3.Distance(m_CurrentTarget.transform.position, transform.position) <= 2.0f)
        {
            SetRandomTarget();
        }
    }

    private void Disappear()
    {
        Destroy(this.gameObject);
    }

    private void SetTarget(GameObject target)
    {
        m_CurrentTarget = target;
        m_NavmeshAgent.SetDestination(m_CurrentTarget.transform.position);
    }

    private void SetRandomTarget()
    {
        SetTarget(movementTargets[UnityEngine.Random.Range(0, movementTargets.Count)]);
    }

    private void LosingPlayerAggro()
    {
        if (m_CurrentTarget == m_Player.gameObject)
        {
            m_CurrentTimeBeforeLosingAggro = m_CurrentTimeBeforeLosingAggro - Time.deltaTime;
            if (m_CurrentTimeBeforeLosingAggro <= 0)
            {
                SetRandomTarget();
                m_CanSeePlayer = false;
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Death>().Die();
        }
    }
}
