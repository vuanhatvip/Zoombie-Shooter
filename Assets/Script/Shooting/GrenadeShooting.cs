using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeShooting : Shooting
{
    [Tooltip("The prefab of the Bullet")]
    [SerializeField]
    private GameObject m_bulletPrefab;

    [Tooltip("The posisition firePoint")]
    [SerializeField]
    private Transform m_firingPosition;

    [Tooltip("The launching force")]
    [SerializeField]
    private float launchingForce;

    [Tooltip("The shooting animator")]
    [SerializeField]
    private Animator m_shootingAnim;

    [Tooltip("Shooting Audio Source")]
    [SerializeField]
    private AudioSource m_sfxShooting;

    private void OnValidate() => m_shootingAnim = GetComponent<Animator>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    public void AddProjectile()
    {
        GameObject bullet = Instantiate(m_bulletPrefab, m_firingPosition.position, m_firingPosition.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * launchingForce;
    }

    public override void Shoot()
    {
        m_shootingAnim.SetTrigger("Shoot");
        base.Shoot();
    }

    public void PlayFireSound() => m_sfxShooting.Play();
}
