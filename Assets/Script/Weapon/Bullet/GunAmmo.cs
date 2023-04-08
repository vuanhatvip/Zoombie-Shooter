using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunAmmo : MonoBehaviour
{
    [Tooltip("magazineSize")]
    [SerializeField]
    private int m_magazineSize;

    [Tooltip("Shooting")]
    [SerializeField]
    private Shooting m_shooting;

    [Tooltip("Animator")]
    [SerializeField]
    private Animator m_anim;

    [Tooltip("AudioSource Reload 1")]
    [SerializeField]
    private AudioSource m_sfxReload1;
    [Tooltip("AudioSource Reload 2")]
    [SerializeField]
    private AudioSource m_sfxReload2;
    [Tooltip("AudioSource Reload 3")]
    [SerializeField]
    private AudioSource m_sfxReload3;
    [Tooltip("AudioSource Reload 4")]
    [SerializeField]
    private AudioSource m_sfxReload4;
    [Tooltip("AudioSource Reload 5")]
    [SerializeField]
    private AudioSource m_sfxReload5;
    [Tooltip("Event for Loaded Ammo")]
    [SerializeField]
    private UnityEvent m_loadedAmmoChanged;

    private int _loadedAmo;
    private bool _isReloading;


    public int LoadedAmo { 
        get => _loadedAmo; 
        set
        {
            _loadedAmo = value;
            UpdateGunlock();
            ReloadOnEmpty();
            m_loadedAmmoChanged.Invoke();
        }
    }

    private void Awake() => LoadedAmo = m_magazineSize;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void UpdateGunlock()
    {
        if (LoadedAmo <= 0)
        {
            LockShooting();
        }
        else
        {
            UnlockShooting();
        }
    }

    private void OnEnable()
    {
        //_isReloading = false;
        //UpdateGunlock();
        //ReloadOnEmpty();
        if (_isReloading)
        {
            _isReloading = false;
            Reload();
        }
    }

    private void ReloadOnEmpty()
    {
        if (LoadedAmo > 0) return;
        Reload();
    }

    void Reload()
    {
        if (_isReloading) return;

        m_anim.SetTrigger("Reload");
        _isReloading = true;
        LockShooting();
    }

    void LockShooting() => m_shooting.Lock();

    void UnlockShooting() => m_shooting.Unlock();

    public void SingleFireAmmoCounter() => LoadedAmo--;

    //public void AddAmmo()
    //{
    //    LoadedAmo = m_magazineSize;
    //    UnlockShooting();
    //}
    //public void Shooting_BulletShot() => LoadedAmo--;

    public void PlayReloadPart1Sound() => m_sfxReload1.Play();

    public void PlayReloadPart2Sound() => m_sfxReload2.Play();

    public void PlayReloadPart3Sound() => m_sfxReload3.Play();

    public void PlayReloadPart4Sound() => m_sfxReload4.Play();

    public void PlayReloadPart5Sound() => m_sfxReload5.Play();

    public void ReloadToIdle() { 
        _isReloading = false;
        LoadedAmo = m_magazineSize;
    }
}
