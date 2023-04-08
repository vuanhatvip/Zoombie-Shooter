using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HitSurfaceId
{
    None = 0,
    Dirt = 1,
    Blood = 2,
}

[System.Serializable]
public class EffectMapper
{
    public HitSurfaceId hitSurface;
    public GameObject effectPrefab;
}

public class HitEffectManager : MonoBehaviour
{
    [SerializeField]
    private EffectMapper[] m_effectMapper;

    private GameObject GetEffectPrefab(HitSurfaceId hitSurfaceId)
    {
        //for (int i = 0; i < m_effectMapper.Length; i++)
        //{
        //    if (m_effectMapper[i].hitSurface == hitSurfaceId)
        //    {
        //        return m_effectMapper[i].effectPrefab;
        //    }

        //    return null;
        //}

        EffectMapper result = Array.Find(m_effectMapper, mapper => mapper.hitSurface == hitSurfaceId);

        return result?.effectPrefab;
    }

    public void SpawnHitEffect(RaycastHit hitInfo, HitSurfaceId surfaceId)
    {
        GameObject hitMarkerPrefab = GetEffectPrefab(surfaceId);
        Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
        Vector3 effecttPosition = hitInfo.point + hitInfo.normal * 0.01f;
        Instantiate(hitMarkerPrefab, effecttPosition, effectRotation, hitInfo.collider.transform);
    }
}
