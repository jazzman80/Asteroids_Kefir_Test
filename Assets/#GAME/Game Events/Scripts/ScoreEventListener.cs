using System;
using UnityEngine;
using UnityEngine.Events;

public class ScoreEventListener : MonoBehaviour
{
    public ScoreEvent action;
    public UnityEvent<int> response;

    private void OnEnable()
    { action.RegisterListener(this); }

    private void OnDisable()
    { action.UnregisterListener(this); }

    public void OnEventRaised(int score)
    { response.Invoke(score); }
}

