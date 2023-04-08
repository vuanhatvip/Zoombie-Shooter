using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttacking : MonoBehaviour
{
    [Tooltip("Animator attacking")]
    [SerializeField]
    private Animator m_animator;

    [Tooltip("Health Point of attacked Target")]
    [SerializeField]
    private Health m_attackingTarget;

    [Tooltip("Damage of zombie")]
    [SerializeField]
    private int m_damage;

    //[Tooltip("Scartch Auto Fading")]
    //[SerializeField]
    //private AutoFading m_scratch;

    private PlayerUI _playerUI;

    private bool IsAttacking
    {
        set
        {
            enabled = value;
            m_animator.SetBool(_IsAttackingState, value);
        }
    }

    private void Start()
    {
        _playerUI = m_attackingTarget.GetComponentInChildren<PlayerUI>();
        StopAttack();
    }
    private int _IsAttackingState = Animator.StringToHash("IsAttacking");

    public void StarAttack() => IsAttacking = true;

    public void StopAttack() => IsAttacking = false;

    private void Update()
    {
        LookAtTarget();
    }

    private void LookAtTarget()
    {
        Vector3 lookingPos = m_attackingTarget.transform.position;
        lookingPos.y = transform.position.y;
        transform.LookAt(lookingPos);
    }

    public void OnAttack(int turn)
    {
        m_attackingTarget.TakeDamage(m_damage);
        if (turn == 0)
        {
            _playerUI.ShowLeftScratch();
        }
        else
        {
            _playerUI.ShowRightScratch();
        }
    }
}
