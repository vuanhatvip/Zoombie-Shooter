using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    [Tooltip("List of gun component")]
    [SerializeField]
    private GameObject[] m_guns;

    private int _currentIndex;

    private void Start() => _currentIndex = FindCurrentGun();

    private int FindCurrentGun() => Array.FindIndex(m_guns, m_guns => m_guns.activeSelf);

    // Update is called once per frame
    void Update()
    {
        UpdateSelectGun();
        UpdateSwitchGun();
    }

    private void UpdateSelectGun()
    {
        for (int i = 0; i < m_guns.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                ActivateGun(i);
            }
        }
    }

    private void UpdateSwitchGun()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _currentIndex = (_currentIndex + 1) % m_guns.Length;
            ActivateGun(_currentIndex);
        }
    }

    private void ActivateGun(int idx)
    {
        for (int i = 0; i < m_guns.Length; i++)
        {
            m_guns[i].SetActive(i == idx);
        }
    }
}
