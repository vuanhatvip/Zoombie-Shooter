using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMuzzle : MonoBehaviour
{
    [Tooltip("GameObject Contain muzzle image")]
    [SerializeField]
    private GameObject m_muzzleImage;

    [Tooltip("GameObject Contain muzzle light")]
    [SerializeField]
    private GameObject m_muzzleLight;

    [Tooltip("Game Component Automatic Shooting")]
    [SerializeField]
    private AutomaticShooting automaticShooting;

    private float _duration;


    private void Start()
    {
        HideMuzzle();
        Debug.Log(automaticShooting.interval);
        Debug.Log(_duration);
    }
    //public void AddSingleFireEffects() => ShowMuzzle();

    public void ShowMuzzle()
    {
        m_muzzleImage.SetActive(true);
        m_muzzleLight.SetActive(true);
        _duration = automaticShooting.interval * 1.0f;
        RotateMuzzle();
        CancelInvoke();
        Invoke(nameof(HideMuzzle), _duration);
    }

    private void RotateMuzzle()
    {
        float zAngle = Random.Range(0, 360);
        float scale = Random.Range(1f, 2f);
        m_muzzleImage.transform.localEulerAngles = new Vector3(0, 0, zAngle);
        m_muzzleImage.transform.localScale = Vector3.one * scale;
    }

    public void HideMuzzle()
    {
        m_muzzleImage.SetActive(false);
        m_muzzleLight.SetActive(false);
    }
}
