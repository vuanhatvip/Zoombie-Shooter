using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
    [Tooltip("Collections of rigidbody of bone")]
    [SerializeField]
    private Rigidbody[] m_bones;

    [Tooltip("Animator")]
    [SerializeField]
    private Animator m_animator;

    [ContextMenu("Collect Bones")]
    private void CollectBones() => m_bones = GetComponentsInChildren<Rigidbody>();

    [ContextMenu("Enable Ragdoll")]
    public void EnableRagDoll() => SetRagdollState(true);

    [ContextMenu("Disbale Ragdoll")]
    public void DisableRagdoll() => SetRagdollState(false);

    private void SetRagdollState(bool isRagdollEnabled)
    {
        m_animator.enabled = !isRagdollEnabled; 
        for (int i = 0; i < m_bones.Length; i++)
        {
            m_bones[i].isKinematic = !isRagdollEnabled;
        }
    }
}
