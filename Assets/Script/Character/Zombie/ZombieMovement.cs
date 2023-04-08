using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZombieMovement : MonoBehaviour
{
    [Tooltip("Chasing target Transform component")]
    [SerializeField]
    private Transform m_chasingTarget;

    //[Tooltip("Zombie movement speed")]
    //[SerializeField]
    //private float m_speed;

    [Tooltip("Animator of Zombie")]
    [SerializeField]
    private Animator m_animator;

    [Tooltip("Nav Mesh Agent of Zombie")]
    [SerializeField]
    private NavMeshAgent m_agent;

    [Tooltip("Reaching Radius")]
    [SerializeField]
    private float m_reachingRadius;

    [Tooltip("List event run when chasing target is reachable")]
    [SerializeField]
    private UnityEvent m_onTargetReached;

    [Tooltip("List event when zombie start chasing")]
    [SerializeField]
    private UnityEvent m_onStartChasing;

    private Vector3 _velocity;
    private bool _isChasing;

    public bool IsChasing
    {
        set
        {
            if (_isChasing != value)
            {
                _isChasing = value;
                SetChasingState(value);
                NotifyChasingState();
            }
        }
        get => _isChasing;
    }

    private void NotifyChasingState()
    {
        if (IsChasing)
        {
            m_onStartChasing.Invoke();
        }
        else
        {
            m_onTargetReached.Invoke();
        }
    }

    private void Start()
    {
        //m_animator.SetBool("IsChasing", true);
        m_agent.transform.SetParent(null);
        _isChasing = false;
    }

    private void Update()
    {
        UpdateMovement();
        //UpdateFacing();
    }

    private void UpdateMovement()
    {
        float distance = Vector3.Distance(transform.position, m_chasingTarget.position);
        if (distance < m_reachingRadius)
        {
            IsChasing = false;
        }
        else
        {
            IsChasing = true;
            m_agent.SetDestination(m_chasingTarget.position);
        }

        ChaseAgent();
    }

    private void ChaseAgent()
    {
        //Vector3 desiredPosition = m_agent.transform.position;

        //if (Vector3.Distance(transform.position, desiredPosition) >= 0.05f)
        //{
        //}
        UpdateFacing();
        transform.position = Vector3.SmoothDamp(
            transform.position,
            m_agent.transform.position,
            ref _velocity,
            0.2f
        );
    }

    private void SetChasingState(bool isChasing)
    {
        m_agent.isStopped = !isChasing;
        m_animator.SetBool("IsChasing", isChasing);
        m_animator.SetFloat("ZombieChasingSpeed", m_agent.speed);
    }

    private void UpdateFacing()
    {
        Vector3 lookingPos = m_agent.transform.position;
        lookingPos.y = transform.position.y;
        transform.LookAt(lookingPos);
    }

    public void Disable()
    {
        enabled = false;
        m_agent.isStopped = true;
    }
}
