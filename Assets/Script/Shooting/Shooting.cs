using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    [Tooltip("Bullet Shoot Events")]
    [SerializeField]
    private UnityEvent bulletShot;

    public virtual void Lock() => enabled = false;
    public virtual void Unlock() => enabled = true;

    public virtual void Shoot()
    {
        bulletShot.Invoke();
    }
}
