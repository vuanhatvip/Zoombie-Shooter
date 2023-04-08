using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
    [Tooltip("Camera Holder Component")] [SerializeField] Transform m_cameraHolder;
    [Tooltip("Pitch Angle")]
    [Range(-80f, 80f)]
    [SerializeField] float m_pitch;
    [SerializeField] float m_minAngle;
    [SerializeField] float m_maxAngle;

    public float rotateSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateYaw();
        UpdatePitch();
    }

    private void UpdateYaw()
    {
        float hTnput = Input.GetAxis("Mouse X");
        transform.Rotate(0, hTnput * rotateSpeed, 0);
    }

    private void UpdatePitch()
    {
        float vInput = Input.GetAxis("Mouse Y");

        m_pitch = Mathf.Clamp((vInput * rotateSpeed) + m_pitch, m_minAngle, m_maxAngle);
        m_cameraHolder.localRotation = Quaternion.Euler(m_pitch, 0, 0);
    }
}
