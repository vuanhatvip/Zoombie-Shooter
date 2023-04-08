using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoBinder : MonoBehaviour
{
    [Tooltip("ammo")]
    [SerializeField]
    private GunAmmo m_ammo;

    [Tooltip("TMP")]
    [SerializeField]
    private TMP_Text ammoValueText;

    public void UpdateAmmoChange()
    {
        ammoValueText.text = $"{m_ammo.LoadedAmo}";
    }

}
