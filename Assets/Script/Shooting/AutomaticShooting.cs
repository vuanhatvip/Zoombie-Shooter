using UnityEngine;
using UnityEngine.Events;
public class AutomaticShooting : Shooting
{
    [Tooltip("animator")]
    [SerializeField]
    private Animator m_animator;

    [Tooltip("Round per minute")]
    [SerializeField]
    private int m_rpm;

    [Tooltip("Animation CLip")]
    [SerializeField]
    private AnimationClip m_animClip;

    //[Tooltip("Hit Marker Prefab")]
    //[SerializeField]
    //private Transform m_hitMarkerPrefab;

    //[Tooltip("Transform of Camera")]
    //[SerializeField]
    //private Transform m_aimingCamera;

    [Tooltip("Shooting Sound")]
    [SerializeField]
    private AudioSource m_sfxShooting;

    public float interval;

    private float firingAnimSpeed;
    private float lastShotTime;
    private bool allowShooting;

    private void Start()
    {
        allowShooting = true;
        interval = 60f / m_rpm;
        Debug.Log("Automatic " + interval);
        firingAnimSpeed = Mathf.Max(1f, m_animClip.length/ 2 / interval);
        m_animator.SetFloat("FiringSpeed", firingAnimSpeed);
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            UpdateFirring();
        }   
    }

    public override void Lock()
    {
        base.Lock();
        allowShooting = false;
    }

    public override void Unlock()
    {
        base.Unlock();
        allowShooting = true;
    }

    private void UpdateFirring()
    {
        if (Time.time >= lastShotTime + interval)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

     public override void Shoot()
     {
        if (!allowShooting) return;

        m_animator.Play("Fire", -1, 0);
        //PerformRaycasting();
        m_sfxShooting.Play();

        base.Shoot();
     }
}
