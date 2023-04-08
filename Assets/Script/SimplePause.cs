using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimplePause : MonoBehaviour, IPausable
{
    public UnityEvent onPause;
    public UnityEvent onResume;
    public void Pause() => onPause.Invoke();

    public void Resume() => onResume.Invoke();
}
