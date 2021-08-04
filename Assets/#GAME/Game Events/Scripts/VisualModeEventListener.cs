using System;
using UnityEngine;
using UnityEngine.Events;

public class VisualModeEventListener : MonoBehaviour
{
    public VisualModeEvent action;
    public UnityEvent<VisualModeEvent.VisualMode> response;

    private void OnEnable()
    { action.RegisterListener(this); }

    private void OnDisable()
    { action.UnregisterListener(this); }

    public void OnEventRaised(VisualModeEvent.VisualMode mode)
    { response.Invoke(mode); }
}


