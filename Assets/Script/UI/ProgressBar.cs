using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [Tooltip("Mask RectTransform")]
    [SerializeField]
    private RectTransform m_mask;

    [SerializeField]
    private Vector2 _originalSize;

    private void OnValidate() => _originalSize = m_mask.sizeDelta;

    public void SetProgress(float progress) => m_mask.sizeDelta = new Vector2(_originalSize.x * progress, _originalSize.y);
}
