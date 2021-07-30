using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score Event", menuName = "ScriptableObjects/Score Event", order = 1)]

public class ScoreEvent : ScriptableObject
{
	private List<ScoreEventListener> listeners =
		new List<ScoreEventListener>();

	public void Raise(int score)
	{
		for (int i = listeners.Count - 1; i >= 0; i--)
			listeners[i].OnEventRaised(score);
	}

	public void RegisterListener(ScoreEventListener listener)
	{ listeners.Add(listener); }

	public void UnregisterListener(ScoreEventListener listener)
	{ listeners.Remove(listener); }
}

