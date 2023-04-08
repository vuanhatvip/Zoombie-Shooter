using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int Max_healthPoint;

    [Tooltip("On Dead Event")]
    [SerializeField]
    private UnityEvent m_onDead;

    [Tooltip("On Health Change Event")]
    [SerializeField]
    private UnityEvent m_onHealthChange;

    [Tooltip("On Hit Event")]
    [SerializeField]
    private UnityEvent m_onHit;

    private int _healthPoint;
    public int HealthPoint
    {
        get => _healthPoint;
        set
        {
            _healthPoint = value;
            m_onHealthChange.Invoke();
        }
    }

    private void Start()
    {
        HealthPoint = Max_healthPoint;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        HealthPoint -= damage;
        m_onHit.Invoke();
        if (IsDead)
        {
            Die();
        }
    }

    public bool IsDead => HealthPoint <= 0;

    private void Die() => m_onDead.Invoke();
}
