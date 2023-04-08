using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeadAction : MonoBehaviour
{
    [Header("Attached Component")]
    [Tooltip("Ragdoll of Zombie")]
    [SerializeField]
    private RagdollSwitcher m_ragdollSwitcher;
    [Tooltip("Movement Component of ZOmbie")]
    [SerializeField]
    private ZombieMovement m_movement;
    [Tooltip("Zombie Attacking Component of Zombie")]
    [SerializeField]
    private ZombieAttacking m_attacking;
    [Tooltip("Hp Bar Binder Component of Zombie")]
    [SerializeField]
    private HpBarBinder m_hpBarBinder;

    private void OnValidate()
    {
        m_ragdollSwitcher = GetComponent<RagdollSwitcher>();
        m_movement = GetComponent<ZombieMovement>();
        m_attacking = GetComponent<ZombieAttacking>();
        m_hpBarBinder = GetComponentInChildren<HpBarBinder>();
    }

    public void Zombie_Dead()
    {
        m_ragdollSwitcher.EnableRagDoll();
        m_movement.Disable();
        m_attacking.StopAttack();
        m_hpBarBinder.HideProgressBar();
    }
}
