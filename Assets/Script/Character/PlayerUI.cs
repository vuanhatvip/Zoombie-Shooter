using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [Header("Scratch Component")]
    [Tooltip("Left Scracth")]
    [SerializeField]
    private AutoFading m_leftScratch;

    [Tooltip("Right Scratch")]
    [SerializeField]
    private AutoFading m_rightScractch;

    public void ShowLeftScratch() => m_leftScratch.Show();

    public void ShowRightScratch() => m_rightScractch.Show();
}
