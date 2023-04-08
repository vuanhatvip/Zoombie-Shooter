using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour
{
    [Tooltip("Camera transform")]
    [SerializeField]
    private Transform mainCamera;

    private void Update()
    {
        transform.forward = -mainCamera.forward;
    }
}
