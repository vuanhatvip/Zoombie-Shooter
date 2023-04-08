using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrassEjection : MonoBehaviour
{
    [Tooltip("Particple Sytem of brass shells")]
    [SerializeField]
    private ParticleSystem brassParticleSystem;

    [Tooltip("Sound effect of brass shells drop")]
    [SerializeField]
    private AudioSource sfxBrassShellDrop;

    [Tooltip("Shell Dropping Delay")]
    [SerializeField]
    private float shellDroppingDesign;

    public void EjectBrass()
    {
       brassParticleSystem.Emit(1);
       Invoke(nameof(PlaySFXShellDropping), shellDroppingDesign);
    }

    private void PlaySFXShellDropping() => sfxBrassShellDrop.Play();

    private void OnDisable() => CancelInvoke();
}
