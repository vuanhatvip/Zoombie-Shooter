using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [Tooltip("Impact particle")]
    [SerializeField]
    private GameObject m_impactParticle;

    [Tooltip("Explosion Radius")]
    [SerializeField]
    private float m_explosionRadius;

    [Tooltip("Explosion Force")]
    [SerializeField]
    private float m_explosionForce;

    [Tooltip("Damage per bullet")]
    [SerializeField]
    private int m_damage;

    private readonly List<Health> _victims = new();
    private bool _isExploded;

    private void OnCollisionEnter(Collision collision)
    {
        if (_isExploded) return;

        CreateExplosion();
        FindAndKill();
        _isExploded = true;
    }

    void CreateExplosion()
    {
        Instantiate(m_impactParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void FindAndKill()
    {
        _victims.Clear();
        Collider[] victims = Physics.OverlapSphere(transform.position, m_explosionRadius);

        for (var i = 0; i < victims.Length; i++)
        {
            var healthPoint = victims[i].GetComponentInParent<Health>();
            if (healthPoint && !_victims.Contains(healthPoint))
            {
                healthPoint.TakeDamage(m_damage);
                _victims.Add(healthPoint);
            }

            BlowVictim(victims[i]);
        }
    }

    void BlowVictim(Collider victim)
    {
        if (victim.TryGetComponent<Rigidbody>(out var rigid))
        {
            rigid.AddExplosionForce(m_explosionForce, transform.position, m_explosionRadius, 1f, ForceMode.Impulse);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, m_explosionRadius);
    }
}
