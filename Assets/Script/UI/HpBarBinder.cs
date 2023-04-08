using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarBinder : MonoBehaviour
{
    [SerializeField]
    private Health health;

    [SerializeField]
    private ProgressBar progressBar;

    [SerializeField]
    private float duration;

    [SerializeField]
    private bool isPersistent;

    private void Start()
    {
        if (!isPersistent)
        {
            HideProgressBar();
        }
    }

    public void Health_HpChanged()
    {
        float progress = (float)health.HealthPoint / health.Max_healthPoint;
        progressBar.SetProgress(progress);
    }

    public void Health_Hit()
    {
        if (!isPersistent)
        {
            ShowProgressBar();
        }
    }

    private void ShowProgressBar()
    {
        progressBar.gameObject.SetActive(true);
        CancelInvoke();
        Invoke(nameof(HideProgressBar), duration);
    }

    public void HideProgressBar() => progressBar.gameObject.SetActive(false);
}
