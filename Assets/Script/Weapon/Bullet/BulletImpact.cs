using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    //[Tooltip("Hit Marker Prefab")]
    //[SerializeField]
    //private GameObject m_hitMarkerPrefab;

    [Tooltip("Transform of Camera")]
    [SerializeField]
    private Transform m_aimingCamera;

    [Tooltip("Damage per bullet")]
    [SerializeField]
    private int m_damage;

    [Tooltip("Effect Manager Impact")]
    [SerializeField]
    private HitEffectManager m_effectManager;

    public void PerformRaycasting()
    {
        var aimingRay = new Ray(m_aimingCamera.position, m_aimingCamera.forward);

        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo))
        {
            var healthPoint = 
                hitInfo.collider.GetComponentInParent<Health>();
            if (healthPoint)
            {
                healthPoint.TakeDamage(m_damage);
            }

            CreateHitEfect(hitInfo);
        }
    }

    private void CreateHitEfect(RaycastHit hitInfo)
    {
        var hittingSurface = hitInfo.collider.GetComponentInParent<HittingSurface>();
        if (hittingSurface != null)
        {
            m_effectManager.SpawnHitEffect(hitInfo, hittingSurface.surfaceId);
        }
    }

    //private void SpawnDirtImpact(RaycastHit hitInfo)
    //{
    //    Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
    //    Vector3 effecttPosition = hitInfo.point + hitInfo.normal * 0.01f;
    //    Instantiate(m_hitMarkerPrefab, effecttPosition, effectRotation, hitInfo.collider.transform);
    //}
}
