using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoFading : MonoBehaviour
{
    [Tooltip("Image")]
    [SerializeField]
    private Image image;

    [Tooltip("Duration")]
    [SerializeField]
    private float duration;

    private float _currentAlpha;
    public float Alpha
    {
        get => _currentAlpha;
        set
        {
            _currentAlpha = value;
            SetAlpha(_currentAlpha);
        }
    }

    private void SetAlpha(float alpha)
    {
        Color newColor = image.color;
        newColor.a = alpha;
        image.color = newColor;
    }

    public void Show() => Alpha = 1;

    public void Hide() => Alpha = 0;

    private void Update() => Alpha = Mathf.MoveTowards(
            Alpha, 0, Time.deltaTime / duration);
}
